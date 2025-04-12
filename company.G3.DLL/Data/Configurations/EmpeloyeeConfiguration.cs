using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Models.DepartmentModel;
using company.G3.DLL.Models.empeloyeeModel;
using company.G3.DLL.Models.Shered;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace company.G3.DLL.Data.Configurations
{
    internal class EmpeloyeeConfiguration : BaseEntityConfiguration<Empeloyee>, IEntityTypeConfiguration<Empeloyee>
    {

        public void Configure(EntityTypeBuilder<Empeloyee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e => e.Gender).HasConversion((EmpGender) => EmpGender.ToString(), (_Gender) => (Gender)Enum.Parse(typeof(Gender), _Gender));
            builder.Property(e => e.EmployeeType).HasConversion((EmpType) => EmpType.ToString(), (_EmpType) => (EmpeloyeeType)Enum.Parse(typeof(EmpeloyeeType), _EmpType));
                base.Configure(builder);                                    

        }
    }
}
