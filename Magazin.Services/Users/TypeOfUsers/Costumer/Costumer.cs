using MagazinData.Entity;
using MagazinData;
using System;
using System.Collections.Generic;
using System.Text;
using MagazinData.Users;
using Omu.ValueInjecter;
using Magazin.Services.Product;
using Magazin.Services.General1;
using System.Dynamic;

namespace Magazin.Services.Users.TypeOfUsers
{
    public class Costumer :ICostumer
    {
        
        private readonly IRepository<Transaction> _transaction;
        private readonly IRepository<Produs> _repoProduct;
        private readonly IRepository<User> _repository;
        private readonly IProductServices _productServices;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserServices userServices;
        private readonly IGeneralServices generalServices;
        private readonly IEmployer employer;
        public Costumer (IEmployer employer,IGeneralServices generalServices, IRepository <Produs> repoProduct,IUserServices userServices,IRepository<Transaction> transaction, IProductServices productServices, IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            this.userServices = userServices;
            this.employer = employer;
            this.generalServices = generalServices;
            _repository = repository;
            _transaction = transaction;
            _productServices = productServices;
            _unitOfWork = unitOfWork;
            _repoProduct = repoProduct;
        }
        public List<ProductDto>  GetShowProducts(enumtype type, int Instance)
        {
                var list = _productServices.GetProductByTip(type);
                list = _productServices.ShowProducts(list, Instance);
            return list;
            
        }
        //public ProductDto BuyProduct()
        public void BuyProduct(string username, List <ProductDto > Items)
        {
           User user = _repository.GetByName(username);
            int cost = 0;
          foreach(var item in Items)
            {
                if (user.Balance >= cost + item.Price)
                    cost += item.Price;
                else
                {
                    Console.WriteLine($"You don't have enough money to buy all of this.");
                    return;
                }
            }
            
            foreach (var item in Items)
            {
                var product = new Produs();

                item.Avalability = false;
                _transaction.Add(new Transaction
                {
                    UserId = user.UserName,
                    Valid = enumvalid.NStoc,
                    data = DateTime.Now,
                    ProductId = item.ProductID,
                    Price = item.Price
                });
                    product.InjectFrom(item);
                employer.RemoveProduct(user.UserName, item.ProductID);
            }           
            
            user.Balance -= cost;
            _repository.Update(user);
            _unitOfWork.Commit();
            
        }

        public void AddCostumer()
        {
         //   var user = userServices.CreateUser();
          //  userServices.AddUser(user, rank.consumer);
           // Console.WriteLine($"The account is accessed");
           // _unitOfWork.Commit();
        }
        public void ChangeProfile(string name)
        {
            userServices.ChangeInfo(name);
        }
        public void AddCash(string UserName,int amount)
        {
            var user = _repository.GetByName(UserName);
            user.Balance += amount;
            _repository.Update(user);
            _unitOfWork.Commit();
        }
        public void TakeCash(string UserName, int amount)
        {
            var user = _repository.GetByName(UserName);
            if (user.Balance >= amount)
            {
                user.Balance -= amount;
                _repository.Update(user);
                _unitOfWork.Commit();
            }
            else throw new ArgumentOutOfRangeException();
        }
       /* public void BuyProduct(string UserName ,int ProductId)
        {
            var user = _repository.GetByName(UserName);
            var product = _productServices.GetProductById(ProductId);
            if (user.Balance < product.Price)
                throw new ArgumentOutOfRangeException();
            user.Balance -= product.Price;
            var transaction = new Transaction
            {
                UserId = user.UserName,
                Valid = enumvalid.NStoc,
                data = DateTime.Now,
                ProductId = product.ProductID,
                Price = product.Price
            };
            _transaction.Add(transaction);
            _unitOfWork.Commit();
            _productServices.RemoveProduct(product);
            )
        }*/
    }
}
