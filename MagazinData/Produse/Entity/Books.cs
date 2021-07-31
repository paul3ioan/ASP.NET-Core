using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace MagazinData.Entity
{
    public class Books : Tip
    {
        [Key]
        public int BooksId { get; set; }
        public int ProdusId { get; set; }
        public string Author { get; set; }
        public string Style { get; set; }
        public string Editor { get; set; }
        
    }
}
