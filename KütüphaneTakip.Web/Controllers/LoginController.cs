using KütüphaneTakip.Core.Entites;
using KütüphaneTakip.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace KütüphaneTakip.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public LoginController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            var check = _appDbContext.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (check != null && check.UserRole.ToString().Equals("Admin"))
            {
                var userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
                userClaims.Add(new Claim(ClaimTypes.UserData, check.Email));
                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Admin");
            }
            if (check != null && check.UserRole.ToString().Equals("User"))
            {
                var userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.Role, "User"));
                userClaims.Add(new Claim(ClaimTypes.UserData, check.Email));
                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }

        }
    }
}
