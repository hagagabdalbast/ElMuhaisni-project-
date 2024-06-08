using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.DAL.Entities
{
    public class LastNew
    {
        public LastNew()
        {
            Attachments = new List<Attachment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

       // public string Photo { get; set; }
        public virtual List<Attachment> Attachments { get; set; }
    }
}
