using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Models.DepartmentModel;
using company.G3.DLL.Models.empeloyeeModel;
using Microsoft.EntityFrameworkCore;

namespace company.G3.DLL.Data.contexts
{
    public class CombanyDbContext(DbContextOptions<CombanyDbContext> options) : DbContext(options)
    {
        public DbSet<Empeloyee> Empeloyees { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
