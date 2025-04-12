using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Models.DepartmentModel;
using company.G3.DLL.Models.Shered;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace company.G3.DLL.Data.Configurations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : baseEntity
    {
       

       public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(B => B.createdOn).HasDefaultValueSql("GETDATE()");
            builder.Property(B => B.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }

        }
    }
