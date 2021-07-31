using Magazin.Services.Product;
using MagazinData.Entity;
using System;
using System.Collections.Generic;
using System.Text;
namespace Magazin.Services.Users.TypeOfUsers
{
    public interface ICostumer
    {
        void AddCostumer();
        void ChangeProfile(string name);
        List<ProductDto> GetShowProducts(enumtype type, int Instance);
        void BuyProduct(string name, List<ProductDto> Items);
        void AddCash(string name,int amount);
        void TakeCash(string name, int amount);
        
        
       // SeeTransactions              x =0 + 30*n
            // OrderDecending RegistrationDate Skip(x) Next(xx)
         //       xx = 0 + 30*(n + 1)
    }
}
