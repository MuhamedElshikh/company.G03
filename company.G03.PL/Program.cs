using company.G3.BLL.Profilies;
using company.G3.BLL.servises.AttachementServises;
using company.G3.BLL.servises.@class;
using company.G3.BLL.servises.interfaces;
using company.G3.DLL.Data.contexts;
using company.G3.DLL.Models.IdentityModel;
using company.G3.DLL.Repositories.@class;
using company.G3.DLL.Repositories.interfaces;
using Microsoft.AspNetCore.Identity;
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
            builder.Services.AddScoped<IEmpeloyeeRepositore, empeloyeeRepositore>();
            builder.Services.AddScoped<IAttachementServises, AttachementServises>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmpeloyeeService, EmpeloyeeService>();
            builder.Services.AddAutoMapper(typeof(MappingProfilies).Assembly);
            builder.Services.AddIdentity<AppUser, IdentityRole>(e => { e.User.RequireUniqueEmail = true;} )
                .AddEntityFrameworkStores<CombanyDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.LogoutPath = "/Auth/Logout";
                //options.AccessDeniedPath = "/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.SlidingExpiration = true;
            });

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
                pattern: "{controller=Auth}/{action=Register}/{id?}");

            app.Run();
        }
    }
}
