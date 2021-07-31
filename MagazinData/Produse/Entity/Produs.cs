using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace MagazinData.Entity
{
    public enum enumtype
    {
        aliment,
        jucarii,
        books,
        all
    }
    public class Produs
    {
        [Key]
        public int ProductID { get; set; }
        public enumtype Typee { get; set; }
       // public Tip Tip { get; set; }
        public string UserId { get; set; }
        public bool Avalability { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationNumber { get; set; }
        public int Cantitate { get; set; }
        public int Price { get; set; }
        // price is dollar
    }
}
