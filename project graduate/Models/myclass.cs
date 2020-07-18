using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project_graduate.Models
{
    public class myclass

    {
        public string orignalmsg;
        public string cryptomsg;
        [Required]
        [MinLength(16),MaxLength(16)]
        public string key { get; set; }
    }
}
