using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazinData.Users;
namespace MagazinWeb.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public rank Rank { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Balance { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public int Amount { get; set; }
        public string Operation { get; set; }
    }
}
