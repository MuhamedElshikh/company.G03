using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace company.G3.DLL.Models.IdentityModel
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
