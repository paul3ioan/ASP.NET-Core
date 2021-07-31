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
using Magazin.Services.Users.TypeOfUsers;
//using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
namespace MagazinWeb.Controllers
{
    public class ManagerController : Controller
    {
        private IManager manager;
        public ManagerController(IManager manager)
        {
            this.manager = manager;
        }
        public IActionResult Index(string returnUrl= null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpGet]
        public IActionResult AddEmployer(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();

        }
        [HttpPost]
        public IActionResult AddEmployer(RegisterModel aux, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            Console.WriteLine($"{aux.UserName} - {aux.LastName}");
            if (ModelState.IsValid)
            {
                var User = new User();
                User.InjectFrom(aux);
                manager.AddEmployer(User);//CalculateHash(aux.Password)
            }
            else
            {
                //Login failure
                ModelState.AddModelError(string.Empty, "Invalid register attempt.");
                return View(aux);
            }
            return RedirectToAction(returnUrl);
        }
        [HttpGet]
        public IActionResult RemoveEmployer(string returnUrl)
        {
            var allEmployer = manager.AllEmployer();
            var Employers = new List<UserModel>();
            
            foreach(var item in allEmployer)
            {
                var employ = new UserModel();
                employ.InjectFrom(item);
                Employers.Add(employ);
            }    
            ViewData["ReturnUrl"] = returnUrl;
            return View(Employers);
        }
        [HttpGet]
        public IActionResult RemoveEmploy(string id, string returnUrl)
        {
            manager.RemoveUser(id);
            return RedirectToAction("Index");

        }
    }
}