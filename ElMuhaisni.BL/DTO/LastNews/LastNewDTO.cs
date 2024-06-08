using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.DTO.LastNews
{
    public class LastNewDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string Photo { get; set; }
        public List<string> PhotoUrls { get; set; }
    }
}
