using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using company.G3.BLL.DTO.Department;
using company.G3.BLL.DTO.Empeloyee;
using company.G3.DLL.Models.empeloyeeModel;

namespace company.G3.BLL.servises.interfaces
{
    public interface IEmpeloyeeService
    {
        IEnumerable<EmpeloyeeDTO> GetAll(string? EmpoloyeesSearchName);
        EmployeeDetailsDto? GetById(int id);
        int Add(CreatedEmployeeDto empeloyee);
        int Update(UpdatedEmployeeDto empeloyee);
        bool Remove(int id);
    }
}
