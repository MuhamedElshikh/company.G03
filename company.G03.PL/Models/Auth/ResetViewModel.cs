using System.ComponentModel.DataAnnotations;

namespace company.G03.PL.Models.Auth
{
    public class ResetViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
