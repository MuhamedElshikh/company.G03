using company.G3.BLL.Profilies;
using company.G3.BLL.servises.@class;
using company.G3.BLL.servises.interfaces;
using company.G3.DLL.Data.contexts;
using company.G3.DLL.Repositories.@class;
using company.G3.DLL.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace company.G03.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options=>options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
            builder.Services.AddDbContext<CombanyDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnectionString"));
                options.UseLazyLoadingProxies();
            });

            builder.Services.AddScoped<IdepartmentRepositore, departmentRepositore>();
            builder.Services.AddScoped<IDepartmentService , DepartmentService>();
              builder.Services.AddScoped<IEmpeloyeeRepositore, empeloyeeRepositore>()
            ;
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmpeloyeeService, EmpeloyeeService>();
            builder.Services.AddAutoMapper(typeof(MappingProfilies).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
