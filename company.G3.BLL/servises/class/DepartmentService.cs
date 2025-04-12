using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using company.G3.BLL.DTO.Department;
using company.G3.BLL.factories;
using company.G3.BLL.servises.interfaces;
using company.G3.DLL.Models;
using company.G3.DLL.Repositories.@class;
using company.G3.DLL.Repositories.interfaces;

namespace company.G3.BLL.servises.@class
{
    public class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
    {

        public IEnumerable<DepatmentDTO> GetAllDepatment()
        {
            var depatrtments = _unitOfWork.departmentRepositore.GetAll();
            return depatrtments.Select(D => D.ToDepatmentDTO());

        }

        public DepartmentDetailsDTO? GetByID(int id)
        {
            var department = _unitOfWork.departmentRepositore.GetById(id);


            return department is null ? null : department.toDepartmentDetailsDTO();
        }

        public int AddDepartmaent(AddDepatmentDTO Depatment)
        {
            var department = Depatment.ToEntity();
             _unitOfWork.departmentRepositore.add(department);
            return _unitOfWork.SaveChanges();
        }

        public int UbdateDeprtment(UbdateDepartmentDTO Department)
        {
             _unitOfWork.departmentRepositore.ubdate(Department.ToEntity());
            return _unitOfWork.SaveChanges();
        }

        public bool deleteDepartment(int id)
        {
            var department = _unitOfWork.departmentRepositore.GetById(id);
            if (department is null) return false;
            else
            {
                  _unitOfWork.departmentRepositore.remove(department);
                var result = _unitOfWork.SaveChanges();
                if (result == 0) return false;
                return true;
            }
        }


    }
}
