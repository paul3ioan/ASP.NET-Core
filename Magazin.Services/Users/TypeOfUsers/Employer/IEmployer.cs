using System;
using System.Collections.Generic;
using System.Text;
using Magazin.Services.Product;
using MagazinData.Entity;
namespace Magazin.Services.Users.TypeOfUsers
{
    public interface IEmployer
    {
        //  AddProduct;
        //    RemoveProduct;
        void RemoveProduct(string name, int id);
        void AddProduct(enumtype type,ProductDto product, string name);
    }
}
