using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsConnect.Entities.Models
{
    public class FileUpload
    {
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string FileContent { get; set; }
    }
}
