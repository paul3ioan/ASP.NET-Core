using System;
using System.Collections.Generic;
using System.Text;
using MagazinData.Entity;
namespace Magazin.Services.Product
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public enumtype Typee { get; set; }
        public Tip Tip { get; set; }
        public string UserId { get; set; }
        public bool Avalability { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationNumber { get; set; }
        public int Cantitate { get; set; }
        public int Price { get; set; }
    }
}
