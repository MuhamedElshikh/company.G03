﻿using company.G3.DLL.Models.empeloyeeModel;
using company.G3.DLL.Models.Shered;
using System.ComponentModel.DataAnnotations;

namespace company.G03.PL.Models.Employee
{
    public class EmployeeModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Can`t Be Null")]
        [MaxLength(50, ErrorMessage = "Max length should be 50 character")]
        [MinLength(5, ErrorMessage = "Min length should be 5 characters")]
        public string Name { get; set; } = null!;
        [Range(22, 35)]
        public int? Age { get; set; }
        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
           ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmpeloyeeType EmployeeType { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; }
    }
}
