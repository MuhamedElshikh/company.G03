using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace company.G3.BLL.servises.AttachementServises
{
    public interface IAttachementServises
    {
        public string? Upload(IFormFile File , string FolderName);
  
        bool Delete(string FilePath);

    }
}
