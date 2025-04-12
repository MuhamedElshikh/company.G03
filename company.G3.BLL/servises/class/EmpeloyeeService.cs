using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using company.G3.BLL.DTO.Department;
using company.G3.BLL.DTO.Empeloyee;
using company.G3.BLL.servises.interfaces;
using company.G3.DLL.Models.empeloyeeModel;
using company.G3.DLL.Repositories.interfaces;

namespace company.G3.BLL.servises.@class
{
    public class EmpeloyeeService(IUnitOfWork _unitOfWork, IMapper _mapper) : IEmpeloyeeService
    {
        public int Add(CreatedEmployeeDto Empeloyee)
        {
            var empeloyee = _mapper.Map<CreatedEmployeeDto, Empeloyee>(Empeloyee);
            _unitOfWork.empeloyeeRepositore.add(empeloyee);
            return _unitOfWork.SaveChanges();

        }

        public IEnumerable<EmpeloyeeDTO> GetAll(string? EmpoloyeesSearchName)
        {
            IEnumerable<Empeloyee> empeloyees;
            if (string.IsNullOrEmpty(EmpoloyeesSearchName))
            
                empeloyees = _unitOfWork.empeloyeeRepositore.GetAll();

            else
            
                 empeloyees = _unitOfWork.empeloyeeRepositore.GetAll(E => E.Name.ToLower().Contains(EmpoloyeesSearchName.ToLower()));
            
            
            var empeloyeeDto = _mapper.Map<IEnumerable<Empeloyee>,IEnumerable<EmpeloyeeDTO>>(empeloyees);
            return empeloyeeDto;
        }

        public EmployeeDetailsDto? GetById(int id)
        {
            var empeloyee = _unitOfWork.empeloyeeRepositore.GetById(id);
            if (empeloyee == null)
                return null;
            var empeloyeeDto = _mapper.Map<Empeloyee, EmployeeDetailsDto>(empeloyee);
            return empeloyeeDto;
        }

        public bool Remove(int id)
        {
            var empeloyee = _unitOfWork.empeloyeeRepositore.GetById(id);
            if (empeloyee == null) return false;
            else
            {
              empeloyee.IsDeleted = true;
                _unitOfWork.empeloyeeRepositore.ubdate(empeloyee);
                return _unitOfWork.SaveChanges() > 0 ? true : false;
            }
        }

        public int Update(UpdatedEmployeeDto empeloyee)
        {
            var empeloyee1 = _mapper.Map<UpdatedEmployeeDto, Empeloyee>(empeloyee);
            _unitOfWork.empeloyeeRepositore.ubdate(empeloyee1);
            return _unitOfWork.SaveChanges();
        }
    }

}
