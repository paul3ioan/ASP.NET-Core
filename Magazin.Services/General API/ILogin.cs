using System;
using System.Collections.Generic;
using System.Text;
using MagazinData.Users;
namespace Magazin.Services.General1
{
    public interface ILogin
    {
        User Getuser(string username);
        User Authentification(string username, string password);
        public void UpdateProfile(User user);
        bool Instancy();
    }
}
