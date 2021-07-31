using System;
using System.Collections.Generic;
using System.Text;
using MagazinData.Users;
using MagazinData;
using System.Linq;
using Magazin.Services.Users;
using Omu.ValueInjecter;
using MagazinData.Entity;
using Magazin.Services.General1;
using Magazin.Services.Product;

namespace Magazin.Services.Users.TypeOfUsers
{
    public class Employer : IEmployer
    {
        private readonly IRepository<User> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserServices _userServices;
        private readonly IGeneralServices _generalServices;
        private readonly IProductServices productServices;
        public Employer(IProductServices productServices, IRepository<User> repo, IUserServices us,IGeneralServices generalServices ,IUnitOfWork unitOfWork)
        {
            this.productServices = productServices;
            _repo = repo;
            _unitOfWork = unitOfWork;
            _userServices = us;
            _generalServices = generalServices;
        }
        public void RemoveProduct( string name, int id)
        {
             productServices.RemoveProduct(id, name);           
        }
        public void AddProduct(enumtype type,ProductDto product,string name)
        {
            productServices.AddProduct(type,product ,name);

        }
    }
}
