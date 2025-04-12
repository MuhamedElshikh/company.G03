using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.G3.DLL.Repositories.interfaces
{
    public interface IUnitOfWork
    {
        public IEmpeloyeeRepositore empeloyeeRepositore { get; }
        public IdepartmentRepositore departmentRepositore { get; }
        public int SaveChanges();
    }
}
