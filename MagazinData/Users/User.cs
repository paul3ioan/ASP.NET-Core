using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace MagazinData.Users
{
    public enum rank
    {
        manager,
        employer,
        consumer,
        wrong
    }
    public class User : DbContext
    {
        [Key]
        public string UserName { get; set; }
        //public int ID { get; set; }
        public rank Rank { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Balance { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
     
    }
}
