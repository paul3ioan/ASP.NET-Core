using System;
using System.Collections.Generic;
using System.Text;
using MagazinData.Entity;
using System.Linq;
using Magazin.Services.Product;
namespace Magazin.Services.General1
{
    public interface IGeneralServices
    {
        Aliment GetAliment(int ProductId);
         Tip GetTip(enumtype type, int ProductID);
        int GetProductBySame(Produs produs, enumtype type);
        void Update(ProductDto list);
        void AddBooks(Books books);
        void AddAliment(Aliment aliment);
        void AddJucarie(Jucarii jucarii);

    }
}
