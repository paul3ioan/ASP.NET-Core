using MagazinData.Entity;
using MagazinData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MagazinData.Users;
using Omu.ValueInjecter;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Magazin.Services.Product;
namespace Magazin.Services.Users
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<Transaction> _repository;
        private readonly IRepository<User> _user;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductServices productServices;

        public User CreateUser()
        {
            string username;
            while (true)
            {
                Console.WriteLine($"Username:");
                username = Console.ReadLine();
                var checkuser = GetUserById(username);
                if (checkuser == null)
                    break;
                if (checkuser.UserName == username)
                {
                    Console.WriteLine($"This username is already taken, Try another one\n");
                    continue;
                }
            }
            Console.WriteLine($"Firstname:");
            var firstname = Console.ReadLine();
            Console.WriteLine($"Lastname: ");
            var lastname = Console.ReadLine();
            Console.WriteLine($"Password: ");
            var password = Console.ReadLine();
            Console.WriteLine($"Number: ");
            var number = Console.ReadLine();
            Console.WriteLine($"Adress: ");
            var adress = Console.ReadLine();
            var user = new User
            {
                Password = password,
                Number = number,
                Adress = adress,
                UserName = username,
                FirstName = firstname,
                LastName = lastname,
                Balance =0
            };
            return user;
        }
        public UserServices(IProductServices productservices,IRepository<Transaction> repository,IUnitOfWork unitOfWork, IRepository<User> user)
        {
            this.productServices = productservices;
            _repository = repository;
            _user = user;
            _unitOfWork = unitOfWork;
        }
        public List<ProductDto> ShowProducts(enumtype type, int Instance)
        {
            var list = productServices.GetProductByTip(type);
            list= productServices.ShowProducts(list, Instance);
            return list;
        }
        public  UserDto GetUserById(string Name)
        {
        
            if (Name == null) throw new ArgumentNullException();
            var user = _user.GetByName(Name);
            if (user == null)
                return null;
            var userDto = new UserDto
            {
                UserName = user.UserName,
                Rank = user.Rank,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Balance = user.Balance,
                Adress = user.Adress,
                Number = user.Number,
                Password = user.Password

            };
            return userDto;
            
        }
        public IList<UserDto> GetAllEmployers()
        {
            var user=  _user.Query(x => x.Rank == rank.employer).ToList();
            var allUser = new List<UserDto>();
            foreach(var item in user)
            {
                var aux = new UserDto();
                aux.InjectFrom(item);
                allUser.Add(aux); 
            }
            return allUser;
        }
        public rank GetRank(string username)
        {
            var user = _user.GetByName(username);
            return user.Rank;
        }
        public void ChangeInfo(string name)
        {
            var info = _user.GetByName(name);
            Console.WriteLine($"FirstName:{info.FirstName}\nLastName:{info.LastName}\nAdrees:{info.Adress}\n" +
                $"Number:{info.Number}\nPassword:{info.Password}");
            // ????? interfata web
        }

        public User AddUser(User user, rank adder)
        {
            var ___user = _user.Query(x => x.UserName == user.UserName);
            var __user = new User();
            if (___user != null)
            {
                __user.InjectFrom(user);
            };      
            switch(adder)
            {
                case rank.manager: __user.Rank = rank.employer;
                    break;
                default: __user.Rank = rank.consumer; break;
            }
            _user.Add(__user);
            _unitOfWork.Commit();
            return __user;
        }
    }
}
