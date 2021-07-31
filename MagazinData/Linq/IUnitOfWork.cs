using System;
using System.Collections.Generic;
using System.Text;

namespace MagazinData
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
