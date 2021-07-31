using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using MagazinWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Magazin.Services.General1;
using MagazinWeb.Models;
using Microsoft.AspNetCore.Http;
using Omu.ValueInjecter;
using MagazinData;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Magazin.Services.Users;
using MagazinData.Users;
using WebApplication1.Controllers;
//using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace MagazinWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogin login;
        private readonly IUserServices userServices;
        public AccountController(ILogin login ,IUserServices userServices)
        {
            this.userServices = userServices;
            this.login = login;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = login.Authentification(model.UserName, model.Password);//CalculateHash(aux.Password),
                if (user != null)
                {
                    LoginMethod(model.UserName);
                    var userModel = new UserModel();
                    userModel.InjectFrom(user);
                    HttpContext.Session.SetUser(userModel);
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }                
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterModel aux, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Console.WriteLine($"{aux.UserName} - {aux.LastName}");
            if (ModelState.IsValid)
            {
                var User = new User();
             
                User.InjectFrom(aux);               
                var user = userServices.AddUser(User,rank.consumer );//CalculateHash(aux.Password)
                if (user != null)
                {
                    LoginMethod(aux.UserName);
                    var userModel = new UserModel();
                    userModel.InjectFrom(user);
                    HttpContext.Session.SetUser(userModel);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                //Login failure
                ModelState.AddModelError(string.Empty, "Invalid register attempt.");
                return View(aux);
            }
            return View(aux);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details()
        {
            var user = HttpContext.Session.GetUser();
            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.ClearUserSession();
            return RedirectToAction(nameof(HomeController.Index), "Home") ;
        }
        private async void LoginMethod(string email, bool isPersistent = false)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Email, email)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = isPersistent,
            };

            await HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity),
               authProperties);
        }
        private string CalculateHash(string input)
        {
            using (var algorithm = SHA512.Create())
            {
                var hashedBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}

