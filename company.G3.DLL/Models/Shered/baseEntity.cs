using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.G3.DLL.Models.Shered
{
    public class baseEntity
    {
        public int Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime createdOn { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
