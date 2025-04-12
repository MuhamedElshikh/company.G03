using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using company.G3.DLL.Data.contexts;
using company.G3.DLL.Models.empeloyeeModel;
using company.G3.DLL.Repositories.interfaces;

namespace company.G3.DLL.Repositories.@class
{
    public class empeloyeeRepositore(CombanyDbContext dbContext) :GenericReepositore<Empeloyee>(dbContext), IEmpeloyeeRepositore
    {
       
    }
}
