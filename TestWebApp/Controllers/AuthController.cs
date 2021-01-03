using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TestWebApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoAuthorize()
        {
            await AuthorizeRequest(false);
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public async Task<IActionResult> DoAuthorizeAdmin()
        {
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            await AuthorizeRequest(true);
            return RedirectToAction("index", "home");
        }

        async Task AuthorizeRequest(bool isAdmin)
        {
            string token = GetJSONWebToken(isAdmin);
            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.Name, Guid.NewGuid().ToString()),
              new Claim("access_token", token),
              new Claim(ClaimTypes.Role, isAdmin?"Admin":"User")
            };

            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            //, "Role", isAdmin ? "Admin" : "User"
            var authProperties = new AuthenticationProperties();

            //await HttpContext.SignInAsync(
            //    JwtBearerDefaults.AuthenticationScheme,
            //    new ClaimsPrincipal(claimsIdentity),
            //    authProperties);
            await Task.CompletedTask;
            HttpContext.Response.Headers.Add("Authorization", "Bearer " + token);
        }

        private string GetJSONWebToken(bool isAdmin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] { new Claim(JwtRegisteredClaimNames.Sub, "testUser") };

            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            return RedirectToAction("index", "home");
        }
    }
}
