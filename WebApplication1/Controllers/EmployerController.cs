using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazinWeb.Models;
using Magazin.Services.Users;
using MagazinData.Entity;
using Omu.ValueInjecter;
using System.Security.Cryptography;
using Magazin.Services.Users.TypeOfUsers;
using Magazin.Services.Product;
namespace MagazinWeb.Controllers
{
    public class EmployerController : Controller
    {
        private readonly string name = "Radu";
        private readonly string password= "Radu";
        private int Instance = 0;
        private readonly IUserServices userServices;
        private readonly IEmployer employer;
        public EmployerController(IUserServices userServices, IEmployer employer)
        {
            this.userServices = userServices;
            this.employer = employer;
        }
        public IActionResult Index()
        {
            return View();
        }
  
        [HttpGet]
        public IActionResult RemoveProduct(string returnUrl)
        {
            var product = new List<ProductsModel>();
            var productsDto = userServices.ShowProducts(enumtype.aliment, Instance);
            foreach (var item in productsDto)
            {
                var productModel = new ProductsModel();
                productModel.InjectFrom(item);
                product.Add(productModel);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(product);
        }
        [HttpGet]
        public IActionResult emoveProduct(string name, int id)
        {
            employer.RemoveProduct(name, id);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            //ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductsModel aux, string returnUrl)
        {
           // switch (aux.TipProdus) {
             //   case "food":
                   aux.Typee = enumtype.aliment;
                //    var info =  RedirectToAction("Aliment");
                  //  break;
               // case "book":
                 //   aux.Typee = enumtype.books;
                   // var info = RedirectToAction("Book");
                    //break;
                //case "toy":
                  //  aux.Typee = enumtype.jucarii;
                   // var info = RedirectToAction("Jucarie");
                   // break;
                        
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var product = new ProductDto();
                product.InjectFrom(aux);

                Console.WriteLine($"{product.Name}");
                employer.AddProduct(aux.Typee,product, name);
            }
            else
            {
            
                ModelState.AddModelError(string.Empty, "Invalid register attempt.");
                return View(aux);
            }
            return RedirectToAction("Index");
        }

    }
}