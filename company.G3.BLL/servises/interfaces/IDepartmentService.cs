using company.G3.BLL.DTO.Department;

namespace company.G3.BLL.servises.interfaces
{
    public interface IDepartmentService
    {
        int AddDepartmaent(AddDepatmentDTO Depatment);
        bool deleteDepartment(int id);
        IEnumerable<DepatmentDTO> GetAllDepatment();
        DepartmentDetailsDTO? GetByID(int id);
        int UbdateDeprtment(UbdateDepartmentDTO Department);
    }
}