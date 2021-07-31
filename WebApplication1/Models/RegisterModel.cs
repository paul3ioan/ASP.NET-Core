using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace MagazinWeb.Models
{
    public class RegisterModel
    {
        
        [Required(ErrorMessage = "Field Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public string Number { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
