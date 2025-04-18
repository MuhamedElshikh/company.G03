using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Models.DepartmentModel;
using company.G3.DLL.Models.empeloyeeModel;
using company.G3.DLL.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace company.G3.DLL.Data.contexts
{
    public class CombanyDbContext(DbContextOptions<CombanyDbContext> options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Empeloyee> Empeloyees { get; set; }
        public DbSet<Department> Department { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().HasIndex(e => e.UserName).IsUnique(false);
            modelBuilder.Entity<AppUser>().HasIndex(e => e.NormalizedUserName).IsUnique(false);

        }


    }
}
