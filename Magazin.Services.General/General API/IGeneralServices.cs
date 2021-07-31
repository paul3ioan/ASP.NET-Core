using System;
using System.Collections.Generic;
using System.Text;
using MagazinData.Entity;
using System.Linq;
namespace Magazin.Services.General
{
    public interface IGeneralServices
    {
         Tip GetTip(enumtype type, int ProductID);

    }
}
