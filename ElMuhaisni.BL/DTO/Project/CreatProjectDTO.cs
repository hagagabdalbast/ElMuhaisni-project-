using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.DTO.Project
{
    public class CreatProjectDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        //public string Photo { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
