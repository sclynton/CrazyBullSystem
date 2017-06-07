using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
//using Autofac;
//using Autofac.Extensions.DependencyInjection;

namespace CrazyBull.Web
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
            //DI
            //services.AddDbContext<NovelBookDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Conn")));
            //services.AddScoped<IBookRepository, BookRepository>();
            //services.AddScoped<NovelBookDbContext>();

            // Add framework services.
            services.AddMvc();

        }
        //public IServiceProvider ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //    services.AddDbContext<NovelBookDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Conn")));

        //    var builder = new ContainerBuilder();
        //    //builder.RegisterGeneric<Data.Repositrories.Repository>().As<IRepository>();
        //    builder.RegisterType<NovelBookDbContext>();

        //    builder.Populate(services);

        //    return new AutofacServiceProvider(builder.Build());
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
