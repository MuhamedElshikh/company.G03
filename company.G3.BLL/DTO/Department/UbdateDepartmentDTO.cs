using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.G3.BLL.DTO.Department
{
    public class UbdateDepartmentDTO
    {
        public int Id { get; set; }
        public string name { get; set; }

        public string description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string code { get; set; }
    }
}
