using MagazinData;
using MagazinData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Magazin.Services.General1;
using Omu.ValueInjecter;
using Microsoft.Extensions.Caching.Memory;
using MagazinData.Users;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace Magazin.Services.Product
{
    public class ProductServices : IProductServices
    {
        
        private readonly IRepository<Aliment> _repoAliment;
        private readonly IRepository<Produs> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGeneralServices _generalServices;
        private readonly IRepository<Transaction> _repoTransaction;
        public ProductServices(IRepository<Transaction>  repoTransaction, IRepository<Aliment> repoAliment,IGeneralServices general, IRepository<Produs> repo, IUnitOfWork unitOfWork)
        {
            
            _repo = repo;
            _repoAliment = repoAliment;
            _generalServices = general;
            _unitOfWork = unitOfWork;
            _repoTransaction = repoTransaction;
        }
        public void RemoveProduct(int  id,string name)
        {
            var product = _repo.GetById(id);
            var aliment = _repoAliment.Query(x => x.ProdusId == product.ProductID).ToList();
            _repoAliment.Delete(aliment[0]);
            _repo.Delete(product);
            _unitOfWork.Commit();
            Console.WriteLine($"Produsul a fost sters");
        }
        public void AddProduct(enumtype type,ProductDto product ,string name)
        {
            switch(type)
            {
                case enumtype.aliment:
                    {
                        int randomvalue;
                        using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
                        {
                            byte[] rno = new byte[5];                            
                            rg.GetBytes(rno);                            
                            randomvalue = BitConverter.ToInt32(rno, 0);                        
                        }
                        
                        var produs = new Produs
                        {
                            
                            Name = product.Name,
                            Typee = enumtype.aliment,
                            UserId = name,
                            Avalability = true,
                            RegistrationDate = DateTime.Now,
                            RegistrationNumber = randomvalue,
                            Price = product.Price,
                            Cantitate = product.Cantitate,
                        };
                       
                        _repo.Add(produs);
                        _unitOfWork.Commit();
                        var aliment = new Aliment(); 
                        aliment.ProdusId = _generalServices.GetProductBySame(produs, type);
                        aliment.CountryProduction = "Romania";
                        var transaction = new Transaction
                        {
                            UserId = name,
                            Valid = enumvalid.Stoc,
                            data = DateTime.Now,
                            ProductId = product.ProductID,
                            Price = produs.Price
                        };
                        _repoTransaction.Add(transaction);
                        _generalServices.AddAliment(aliment);
                        Console.WriteLine($"The product was added succesfully");
                        break;
                    }
            }
        }      
        public ProductDto GetProductById(int ID)
        {
            if (ID < 1) throw new ArgumentException();
            var Product = _repo.GetById(ID);
            if (Product.Avalability == false)
                return null;
            var productDto = new ProductDto{
                ProductID = Product.ProductID,
                Typee = Product.Typee,
                Tip = null,
                UserId = Product.UserId,
                Avalability = Product.Avalability,
                Name = Product.Name,
                RegistrationDate = Product.RegistrationDate,
                RegistrationNumber = Product.RegistrationNumber,
                Cantitate = Product.Cantitate,
                Price = Product.Price
            };
            productDto.Tip = _generalServices.GetTip(productDto.Typee, productDto.ProductID);
            return productDto;
        }
        public List<ProductDto> ShowProducts(List<ProductDto> produse, int Instance)
        {
            int contor = 0;
            
            if (Instance < 0 || Instance > produse.Count()) { Console.WriteLine($"Invalid input"); return null; }
            var showProducts = new List<ProductDto>();
            if (produse[0].Typee == enumtype.aliment)
            {
                string valabil;
                var aliment = new Aliment();
                var produs = new Produs();
                contor = 0;
                //foreach (var item in produse)
                //{              
                    //aliment = _generalServices.GetAliment(item.ProductID);
                    //if (aliment.expirationDate <= DateTime.Now)
                   // {
                        //Console.WriteLine($"{produs.ProductID} -{aliment.expirationDate} - {DateTime.Now}");
                      //  _repo.Delete(produs);
                    //    _repoAliment.Delete(aliment);
                  //      produse.Remove(item);
                //        _unitOfWork.Commit();
              //      }

         //       }

                 showProducts = produse.Skip(Instance).Take(Instance + 5).ToList();
                foreach(var item in showProducts)
                {
                    contor++;
                    if (item.Avalability == true)
                        valabil = "It's available";
                    else
                        valabil = "It's not available";
                    Console.WriteLine($"[{contor}] -{item.Name} - {item.Price} - {item.Cantitate} - {valabil}");
                }
            }
            if (produse[0].Typee == enumtype.jucarii)
            {       
                 showProducts = produse.Skip(Instance).Take(Instance + 5).ToList();
                var jucarie = new Jucarii();
                contor  = 0;
                foreach (var item in showProducts)
                {
                    contor++;
                    jucarie.InjectFrom(item.Tip);
                    Console.WriteLine($"[{contor}] -{item.Name} - {jucarie.MinimumAge} - {item.Price} - {item.Avalability}");
                }
            }
            if (produse[0].Typee == enumtype.books)
            {
                contor = 0;
                 showProducts = produse.Skip(Instance).Take(Instance + 5).ToList();
                var book = new Books();
                foreach (var item in showProducts)
                {
                    contor++;
                    book.InjectFrom(item.Tip);
                    Console.WriteLine($"[{contor}] -{item.Name} - {book.Author} - {item.Price} - {book.Style} - {item.Avalability}");
                }
            }
            return showProducts;
        }
        public List<ProductDto> GetProductByTip(enumtype type)
        {
            List<Produs> product;
            switch(type)
            {
                case enumtype.aliment: product = _repo.Query(x => x.Typee == enumtype.aliment && x.Avalability==true).ToList();
                    break;
                case
                    enumtype.jucarii: product = _repo.Query(x => x.Typee == enumtype.jucarii).ToList();
                    break;
                case
                    enumtype.books: product = _repo.Query(x => x.Typee == enumtype.books).ToList();
                    break;
                default: product = _repo.Query().ToList();break;
            }
            //Tip tip;
            var FinalProduct = new List<ProductDto>();
           foreach(var item in product)
            {
                var productDto =new ProductDto ();
                productDto.InjectFrom(item);
                FinalProduct.Add(productDto);
            }
            foreach (var item in FinalProduct)
            {
                item.Tip =_generalServices.GetTip(item.Typee, item.ProductID);
                //Console.WriteLine($"{item.Name}!!!");
            }
            return FinalProduct;
        } 
    }
}
