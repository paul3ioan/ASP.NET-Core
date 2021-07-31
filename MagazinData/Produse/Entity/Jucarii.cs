using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace MagazinData.Entity
{
    public class Jucarii : Tip
    {
        [Key]
        public int JucariiId { get; set; }
        public int ProductId { get; set; }
        public int MinimumAge { get; set; }
        public string Producter { get; set; }
        
    }
}
