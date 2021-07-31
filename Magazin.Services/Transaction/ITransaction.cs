using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin.Services.Transaction1
{
    public interface ITransaction
    {
        void CreateTransaction(string username, bool type, int ProductId);
    }
}
