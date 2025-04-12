using company.G03.PL.Models.department;
using company.G3.BLL.DTO;
using company.G3.BLL.DTO.Department;
using company.G3.BLL.servises.interfaces;
using company.G3.DLL.Models.DepartmentModel;
using Microsoft.AspNetCore.Mvc;

namespace company.G03.PL.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService, ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
    {

        public IActionResult Index()
        {
            var Debartment = _departmentService.GetAllDepatment();
            return View(Debartment);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(AddDepatmentDTO department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _departmentService.AddDepartmaent(department);
                    string message = string.Empty;
                    if (result > 0)
                    {
                        message = $"Department {department.name} added successfully.";
                    }
                   
                    else
                    {
                        message = $"Department {department.name} cannot Be Create.";

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
            return View(department);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetByID(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetByID(id.Value);

            if (department is null) return NotFound();
            var departmentViewModel = new DepartmentViweModel
            {
                Code = department.code,
                Name = department.Name,
                Description = department.Description,
                CreatedDate = department.DateOfCreation,
            };
            return View(departmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentViweModel department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var departmentDTO = new UbdateDepartmentDTO
                    {
                        Id = id,
                        name = department.Name,
                        code = department.Code,
                        description = department.Description,
                        DateOfCreation = department.CreatedDate,
                    };
                    int result = _departmentService.UbdateDeprtment(departmentDTO);
                    string message = string.Empty;
                    if (result > 0)
                    {
                        message = $"Department {departmentDTO.name} added successfully.";
                    }

                    else
                    {
                        message = $"Department {departmentDTO.name} cannot Be Create.";

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
                        return View(department);
                    }
                }

            }
            return View(department);
        }

        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetByID(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool deleted = _departmentService.deleteDepartment(id);
                 string message = string.Empty;
                if (deleted) 
                {
                    message = $"Department  deleted successfully.";
                        }
                else
                {
                    message = "Department is not deleted";
                  
                }
                TempData["message"] = message;
                return RedirectToAction("Index");
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
