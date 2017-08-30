using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrazyBull.WebFramework;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;

namespace CrazyBull.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly JWTTokenOptions _tokenOptions;
        public AccountController(JWTTokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }
        [Route("login")]
        [HttpGet]
        public string Login()
        {
            return CreateToken(new Controllers.User { Id = 1, UserName = "lynton", Password = "123" }, DateTime.Now.AddDays(1), "TestAudience");
        }
        /// <summary>
        /// 生成一个新的 Token
        /// </summary>
        /// <param name="user">用户信息实体</param>
        /// <param name="expire">token 过期时间</param>
        /// <param name="audience">Token 接收者</param>
        /// <returns></returns>
        private string CreateToken(User user, DateTime expire, string audience)
        {
            var handler = new JwtSecurityTokenHandler();
            string jti = audience + user.UserName + expire.Millisecond;
            //jti = jti.GetMd5(); // Jwt 的一个参数，用来标识 Token
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, "1"), // 添加角色信息
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // 用户 Id ClaimValueTypes.Integer32),
                new Claim("jti",jti,ClaimValueTypes.String) // jti，用来标识 token
            };
            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user.UserName, "TokenAuth"), claims);
            var token = handler.CreateEncodedJwt(new SecurityTokenDescriptor
            {
                Issuer = "TestIssuer", // 指定 Token 签发者，也就是这个签发服务器的名称
                Audience = audience, // 指定 Token 接收者
                SigningCredentials = _tokenOptions.Credentials,
                Subject = identity,
                Expires = expire
            });
            return token;
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}