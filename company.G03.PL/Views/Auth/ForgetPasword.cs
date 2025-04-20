using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace company.G03.PL.Views.Auth
   
{
    public class ForgetPasword
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
