using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.ElkomMuhasebe.Core.Model.Entity.Admin
{
    public class VERGIDAIRE: EntityBase
    {
        public int sira { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public int saymanlik { get; set; }
        public string ismi { get; set; }
    }
}
