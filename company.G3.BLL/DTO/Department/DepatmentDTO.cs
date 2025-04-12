using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.G3.BLL.DTO.Department
{
    public class DepatmentDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string code { get; set; }

        public DateOnly DateOfCreation { get; set; }
    }
}
