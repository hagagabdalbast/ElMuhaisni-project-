
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ElMuhaisni.DAL.Entities
//{
//    public class Attachment
//    {
//        public int Id { get; set; }
//        public string LastNewPhotoUrl { get; set; }
//        public int LastNewId { get; set; }
//        public virtual LastNew LastNew { get; set; }
//        public int ProjectId { get; set; }
//        public virtual Project Project { get; set; }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.DAL.Entities
{

    public class Attachment
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public int? LastNewId { get; set; }
        public virtual LastNew? LastNew { get; set; }
    }
}
