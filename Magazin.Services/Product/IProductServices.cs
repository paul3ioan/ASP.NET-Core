using MagazinData.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin.Services.Product
{
    public interface IProductServices
    {
        //void Update(List<ProductDto> items);
        List<ProductDto> ShowProducts(List<ProductDto> produse, int Instance);
         List<ProductDto> GetProductByTip(enumtype type);
        void AddProduct(enumtype type,ProductDto product,  string name);
        void RemoveProduct(int id, string name);
        ProductDto GetProductById(int ID); // asta folosesc la user products
    }
}
