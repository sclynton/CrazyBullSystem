using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CrazyBull.MySql.EntityFramework;
using Dora.Interception;
using CrazyBull.Application;
using CrazyBull.Core;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using CrazyBull.WebFramework;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using CrazyBull.Sqlserver.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CrazyBull.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CrazyBullDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Conn")));
            services.AddScoped<CrazyBullDbContext>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Add framework services.
            services.AddMvc();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                //添加header过滤器
                c.OperationFilter<HttpHeaderOperation>();
                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "CrazyBull.Api.xml");
                c.IncludeXmlComments(xmlPath);
            });

            #region 发放Token
            // 从文件读取密钥
            string keyDir = PlatformServices.Default.Application.ApplicationBasePath;

            if (RSAUtils.TryGetKeyParameters(keyDir, true, out RSAParameters keyParams) == false)
            {
                keyParams = RSAUtils.GenerateAndSaveKey(keyDir);
            }
            var _key = new RsaSecurityKey(keyParams);
            var _options = new JWTTokenOptions()
            {
                Key = _key,
                Audience = "TestAudience",
                Issuer = "TestIssuer", // 签发者名称
                Credentials = new SigningCredentials(_key, SecurityAlgorithms.RsaSha256Signature)
            };
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build());
            });
            #endregion
            //.net core 2.0 鉴权和1.1写法不一样，参数JwtBearerOption是一样的，之前写在Configure方法里，现在只需要在Configurez方法中写一句app.UseAuthentication()
            #region 鉴权Token
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = _options.Key,
                    ValidAudience = _options.Audience, // 设置接收者必须是 TestAudience
                    ValidIssuer = _options.Issuer, // 设置签发者必须是 TestIssuer
                    ValidateLifetime = true
                };
            });
            #endregion
            //services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });
            services.AddSingleton(_options);

            //添加允许跨域
            services.AddCors(options =>
               options.AddPolicy("AllowSameDomain",
               builder => builder.WithOrigins("*").WithHeaders("date").
               AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials())
            );
            //return services.BuilderInterceptableServiceProvider(builder=>builder.SetDynamicProxyFactory());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();

            app.UseAuthentication();


            Mapper.Initialize(x=>x.CreateMap<Category, CategoryOutput>());

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Host = httpReq.Host.Value);
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.ShowRequestHeaders();
            });
        }
    }
}
