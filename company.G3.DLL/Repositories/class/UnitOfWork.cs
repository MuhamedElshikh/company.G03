using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Data.contexts;
using company.G3.DLL.Repositories.interfaces;

namespace company.G3.DLL.Repositories.@class
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdepartmentRepositore _DepartmentRepositore;
        private readonly IEmpeloyeeRepositore _EmpeloyeeRepositore;
        private readonly CombanyDbContext _CombanyDbContext;
        public UnitOfWork(IdepartmentRepositore departmentRepositore , IEmpeloyeeRepositore empeloyeeRepositore, CombanyDbContext combanyDbContext)
        {
            _DepartmentRepositore = departmentRepositore;
            _EmpeloyeeRepositore = empeloyeeRepositore;
            _CombanyDbContext = combanyDbContext;
        }


        public IEmpeloyeeRepositore empeloyeeRepositore => _EmpeloyeeRepositore;

        public IdepartmentRepositore departmentRepositore => _DepartmentRepositore;

        public int SaveChanges() => _CombanyDbContext.SaveChanges();

    }
}
