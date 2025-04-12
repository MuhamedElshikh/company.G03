using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using company.G3.BLL.DTO.Empeloyee;
using company.G3.DLL.Models.empeloyeeModel;

namespace company.G3.BLL.Profilies
{
    public class MappingProfilies:Profile
    {
        public MappingProfilies()
        {
            CreateMap<Empeloyee, EmpeloyeeDTO>()
                .ForMember(dest=>dest.Gender , option=>option.MapFrom(src=>src.Gender))
                .ForMember(dest => dest.EmployeeType, option => option.MapFrom(src => src.EmployeeType))
                .ForMember(dest=>dest.Department,option=>option.MapFrom(src=>src.Department !=null?src.Department.Name :null ));
            CreateMap<Empeloyee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Gender, option => option.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType, option => option.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.Department, option => option.MapFrom(src => src.Department != null ? src.Department.Name : null))
                .ForMember(dest => dest.HiringDate, option => option.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));
            CreateMap<CreatedEmployeeDto, Empeloyee>()
                .ForMember(dest => dest.HiringDate, option => option.MapFrom(src =>src.HiringDate.ToDateTime(TimeOnly.MinValue)));
            CreateMap<UpdatedEmployeeDto,Empeloyee>()
                .ForMember(dest => dest.HiringDate, option => option.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));







        }
    }
}
