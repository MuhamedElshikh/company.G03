﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Data.contexts;
using company.G3.DLL.Models.DepartmentModel;
using company.G3.DLL.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace company.G3.DLL.Repositories.@class
{
    public class departmentRepositore(CombanyDbContext dbContext) :GenericReepositore<Department>(dbContext) ,IdepartmentRepositore
    {
        
    }
}
