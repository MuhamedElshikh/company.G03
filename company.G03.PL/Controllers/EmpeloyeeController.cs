using company.G03.PL.Models.Employee;
using company.G3.BLL.DTO.Empeloyee;
using company.G3.BLL.servises.@class;
using company.G3.BLL.servises.interfaces;
using company.G3.DLL.Models.DepartmentModel;
using company.G3.DLL.Models.empeloyeeModel;
using company.G3.DLL.Models.Shered;
using company.G3.DLL.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace company.G03.PL.Controllers
{
    public class EmpeloyeeController(IEmpeloyeeService _empeloyeeService , ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index(string? EmpoloyeesSearchName)
        {
            var empeloyees = _empeloyeeService.GetAll(EmpoloyeesSearchName);
            return View(empeloyees);
        }
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModelView Employee)
        {
            var createdEmployee = new CreatedEmployeeDto()
            {
                Name = Employee.Name,
                Age = Employee.Age,
                Address = Employee.Address,
                Salary = Employee.Salary,
                IsActive = Employee.IsActive,
                Email = Employee.Email,
                PhoneNumber = Employee.PhoneNumber,
                DepartmentId = Employee.DepartmentId,
                EmployeeType = Employee.EmployeeType,
                Gender = Employee.Gender,
                HiringDate = Employee.HiringDate,
                Image = Employee.Image,
            };
            try
            {
                
                var result = _empeloyeeService.Add(createdEmployee);
                string message ;
                if (result > 0)
                {
                    message = $"Employee {createdEmployee.Name} added successfully.";
                }

                else
                {
                    message = $"Employee {createdEmployee.Name} cannot Be Create.";

                }
                TempData["message"] = message;
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                }
            }
            return View(createdEmployee);

        }

        public IActionResult Details(int id)
        {
            var empelyee = _empeloyeeService.GetById(id);
            if (empelyee is null) return NotFound();
            return View(empelyee);
        }

        public IActionResult Edit([FromRoute] int? id)
        {
            var empeloyee = _empeloyeeService.GetById(id.Value);
            if (empeloyee is null) return NotFound();
           var empeloyeeDto = new EmployeeModelView()
           {
           Name=empeloyee.Name,
           Salary=empeloyee.Salary,
           Address=empeloyee.Address,
           Age=empeloyee.Age,
           Email=empeloyee.Email,
           PhoneNumber=empeloyee.PhoneNumber,
           IsActive=empeloyee.IsActive,
           HiringDate=empeloyee.HiringDate,
           Gender=Enum.Parse<Gender>( empeloyee.Gender),
           EmployeeType=Enum.Parse<EmpeloyeeType>(empeloyee.EmployeeType),
               DepartmentId = empeloyee.Departmentid,
               Image = empeloyee.Image,
               ImageName = empeloyee.ImageName
               

           };
            return View(empeloyeeDto);
        }
        [HttpPost]

        public IActionResult Edit([FromRoute] int? id,[FromForm] EmployeeModelView employeeModelView)
        {
            if(!id.HasValue) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {


                    var employeeDto = new UpdatedEmployeeDto()
                    {
                        Id = id.Value,
                        Name = employeeModelView.Name,
                        Salary = employeeModelView.Salary,
                        Address = employeeModelView.Address,
                        Age = employeeModelView.Age,
                        Email = employeeModelView.Email,
                        PhoneNumber = employeeModelView.PhoneNumber,
                        IsActive = employeeModelView.IsActive,
                        EmployeeType = employeeModelView.EmployeeType,
                        DepartmentId = employeeModelView.DepartmentId,
                        HiringDate = employeeModelView.HiringDate,
                        Gender = employeeModelView.Gender,
                        Image = employeeModelView.Image,
                        ImageName = employeeModelView.ImageName,
                        

                    };
                    
                   
                    var result = _empeloyeeService.Update(employeeDto);
                    string message = string.Empty;
                    if (result > 0)
                    {
                        message = $"Employee {employeeDto.Name} updated successfully.";
                    }

                    else
                    {
                        message = $"Employee {employeeDto.Name} cannot Be updated.";

                    }
                    TempData["message"] = message;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(employeeModelView);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool deleted = _empeloyeeService.Remove(id);
                if (deleted)
                {
                    string message = $"Employee  deleted successfully.";
                    TempData["message"] = message;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Employee is not deleted");
                    return RedirectToAction("Delete", new { id });
                }
            }
            catch (Exception ex)
            {
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger?.LogError(ex.Message);
                        return View("ErrorView");
                    }
                }
            }
        }
    }
}
