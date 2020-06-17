using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_graduate.Models
{
    public class fileclass
    {
        public IFormFile File { get; set; }
        public string File_Name { get; set; }
        public string Encryptfile { get; set; }
        public string Decryptfile { get; set; }
    }
}
