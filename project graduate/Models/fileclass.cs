using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [MinLength(16), MaxLength(16)]
        public string key { get; set; }
    }
}
