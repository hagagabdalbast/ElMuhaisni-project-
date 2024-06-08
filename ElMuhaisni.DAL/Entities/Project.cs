using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.DAL.Entities
{
    public class Project
    {
        public Project()
        {
            Attachments = new List<Attachment>();
        }
        public int Id { get; set; }
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
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Attachment> Attachments { get; set; }
    }
}
