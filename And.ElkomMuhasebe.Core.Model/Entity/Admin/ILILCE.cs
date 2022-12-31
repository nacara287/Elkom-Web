using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.ElkomMuhasebe.Core.Model.Entity.Admin
{
   public class ILILCE: EntityBase
    { public int ilkodu { get; set; }
        public string iladi { get; set; }

        public int ilcekodu { get; set; }
        public string ilceadi {get; set; }
        public bool aktif { get; set; }
}
}
