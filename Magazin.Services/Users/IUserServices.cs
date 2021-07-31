using System;
using System.Collections.Generic;
using System.Text;
using Magazin.Services.Product;
using MagazinData.Users;
using MagazinData.Entity;
namespace Magazin.Services.Users
{
    public interface IUserServices
    {
        rank GetRank(string name);
        void ChangeInfo(string name);
        List<ProductDto> ShowProducts(enumtype type, int Instance);
        //User CreateUser();
        UserDto GetUserById(string Name);
        User AddUser(User user, rank rank);
        IList<UserDto> GetAllEmployers();
    }
}
