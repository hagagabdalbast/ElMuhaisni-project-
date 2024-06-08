using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.DTO.Project
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        //public string Photo { get; set; }

        public string Phone { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<string> PhotoUrls { get; set; }

    }
}
