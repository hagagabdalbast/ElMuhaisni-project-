using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.DTO.LastNews
{
    public class CreateLastNewDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
         // [Required]
        //public string Photo { get; set; }

        public List<IFormFile> Photos { get; set; }
    }
}
