using System;
using System.Collections.Generic;
using System.Text;
namespace Magazin.Services.Product
{
    public class ProductDetailsDto
    {
        public string Name { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int Cantitate { get; set; }
        public int Price { get; set; }

    }
}
