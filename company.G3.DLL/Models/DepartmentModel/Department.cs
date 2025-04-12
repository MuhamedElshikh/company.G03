using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Models.empeloyeeModel;
using company.G3.DLL.Models.Shered;

namespace company.G3.DLL.Models.DepartmentModel
{
    public class Department : baseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Empeloyee> empeloyees { get; set; } = new HashSet<Empeloyee>();
    }
}
