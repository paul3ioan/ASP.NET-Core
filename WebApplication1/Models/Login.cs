using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinWeb.Models
{
    public class LoginModel
    {
        [Required]       
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
