using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.G3.BLL.DTO.Department
{
    public class AddDepatmentDTO

    {
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string code { get; set; }
    }
}
