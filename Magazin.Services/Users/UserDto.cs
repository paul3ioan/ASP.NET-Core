using System;
using System.Collections.Generic;
using System.Text;
using MagazinData.Users;
namespace Magazin.Services.Users
{
    public class UserDto
    {
        public string UserName{get;set ;}
        public rank Rank { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Balance { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        


    }
}
