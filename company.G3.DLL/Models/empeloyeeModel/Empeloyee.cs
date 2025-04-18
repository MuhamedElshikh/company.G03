using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Models.DepartmentModel;
using company.G3.DLL.Models.Shered;

namespace company.G3.DLL.Models.empeloyeeModel
{
    public class Empeloyee:baseEntity
    {

        public string Name { get; set; }    
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmpeloyeeType EmployeeType { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public string? ImageName { get; set; }
    }
}
