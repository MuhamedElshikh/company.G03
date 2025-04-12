using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.G3.BLL.DTO.Department
{
    public class DepartmentDetailsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string code { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int CreatedBy { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
