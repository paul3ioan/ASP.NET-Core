using System;
using MagazinData.Users;
using System.Collections.Generic;
using System.Text;
using Magazin.Services.Users;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
namespace Magazin.Services.Users.TypeOfUsers
{
    public interface IManager
    {
        void AddEmployer(User user);
        void ChangeProfile(string name);
        void RemoveUser(string Name);
        //void SeeProducts();
        void ChangePrice(string name, int price);
        IList<UserDto> AllEmployer();
        List<Transaction> SeeEmployActivity(string userName);
       // SeeTransactions(in last hours);
        int SeeProfit();
            
    }
}
