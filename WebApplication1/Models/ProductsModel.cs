using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MagazinData.Entity;
namespace MagazinWeb.Models
{
    public class ProductsModel
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public string TipProdus { get; set; }
        
        public enumtype Typee { get; set; }
        public Tip Tip { get; set; }
        public string UserId { get; set; }
        public bool Avalability { get; set; }
        [Required(ErrorMessage = "Field Required")]

        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationNumber { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public int Cantitate { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public int Price { get; set; }
        
        

    }
}
