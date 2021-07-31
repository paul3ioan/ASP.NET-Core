using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;

namespace MagazinData.Entity
{
    public class Aliment : Tip
    {
        [Key]
        public int AlimentId { get; set; }

        public int ProdusId { get; set; }
        public DateTime expirationDate { get; set; }
        public string CountryProduction { get; set; }

    }

}
   