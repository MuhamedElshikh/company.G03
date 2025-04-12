using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using company.G3.BLL.DTO.Department;
using company.G3.DLL.Models.DepartmentModel;

namespace company.G3.BLL.factories
{
    static class DepatmentFactory
    {
        public static DepatmentDTO ToDepatmentDTO(this Department D)
        {
            return new DepatmentDTO { ID = D.Id, Name = D.Name, code = D.Code, DateOfCreation = DateOnly.FromDateTime(D.createdOn), Description = D.Description };
        }

        public static Department ToEntity(this AddDepatmentDTO AddDepatment)
        {
            return new Department { Name = AddDepatment.name, Code = AddDepatment.code, Description = AddDepatment.description, createdOn = AddDepatment.DateOfCreation };

        }
        public static Department ToEntity(this UbdateDepartmentDTO Depatment)
        {
            return new Department {Id = Depatment.Id, Name = Depatment.name, Code = Depatment.code, Description = Depatment.description,  createdOn = Depatment.DateOfCreation };

        }
        public static DepartmentDetailsDTO toDepartmentDetailsDTO(this Department Depatment)
        {
            return new DepartmentDetailsDTO { ID = Depatment.Id, Name = Depatment.Name, code = Depatment.Code, Description = Depatment.Description, DateOfCreation = Depatment.createdOn ,CreatedBy = Depatment.CreatedBy ,LastModifiedBy=Depatment.LastModifiedBy,LastModifiedOn=Depatment.LastModifiedOn };

        }
    }
}
