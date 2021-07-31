using System;
using System.Collections.Generic;
using System.Text;
using MagazinData.Entity;
using System.Linq;
//using Magazin.Services.Product;
namespace Magazin.Services.General
{
    public interface IGeneralServices
    {
         Tip GetTip123(enumtype type, int ProductID);

    }
}
