using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using Omu.ValueInjecter;
using Magazin.Services.Product;
using Magazin.Services.General1;
using Magazin.Services.Users;
using MagazinData.Entity;
using MagazinWeb.Models;
using Magazin.Services.Users.TypeOfUsers;
using MagazinData;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Controllers;
namespace MagazinWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly string name = "Anca";
        private readonly string password = "Anca";
        private readonly int Instance = 0;
        private readonly ICostumer costumer;
        private readonly IUserServices userServices;
        private readonly IProductServices productServices;
        public ProductsController(ICostumer costumer, IUserServices userServices, IProductServices productServices)
        {
            this.productServices = productServices;
            this.costumer = costumer;
            this.userServices = userServices;
        }
        
       
       
        [HttpGet]
        public IActionResult Products(string returnUrl)
        {
            var product = new List<ProductsModel>();
            var productsDto = userServices.ShowProducts(enumtype.aliment, Instance);
            foreach(var item in productsDto)
            {
                var productModel = new ProductsModel();
                productModel.InjectFrom(item);
                product.Add(productModel);
            }
                           
                ViewData["ReturnUrl"] = returnUrl;
                return View(product);
            
        }
        [HttpGet]
        public IActionResult AddCash()
        {
            var user = userServices.GetUserById("Anca");
            var aux = new UserModel();
            aux.InjectFrom(user);
            return View(aux);
        }
        [HttpPost]
        public IActionResult AddCash(UserModel user, string url)
        {
            var user1 = userServices.GetUserById("Anca");
            user.InjectFrom(user1);
            Console.WriteLine(user.UserName);
            ViewData["ReturnUrl"] = url;
            if (user.Operation == "add")
                costumer.AddCash(user.UserName, user.Amount);
            if (user.Operation == "substract" && user.Balance > user.Amount)
                costumer.AddCash(user.UserName, -user.Amount);
            else
            {
                ModelState.AddModelError(string.Empty, "Not enough money.");
                return View(user);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        [HttpGet]
        public IActionResult Products1(int id,string url = null)
        {
            ViewData["ReturnUrl"] = url;
            var products = new List<ProductDto>();
            var product = productServices.GetProductById(id);
            products.Add(product);
            Console.WriteLine(products[0].Name);
             costumer.BuyProduct(name, products);
            

         //   if (valid == null)
           // {
             //   ModelState.AddModelError(string.Empty, "Not enough founds.");
               // return RedirectToAction("Products");
           // }
           // else
                return RedirectToAction("Products");
        }
    }
}