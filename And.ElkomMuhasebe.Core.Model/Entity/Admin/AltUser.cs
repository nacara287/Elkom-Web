using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.ElkomMuhasebe.Core.Model.Entity.Admin
{
    public class AltUser:EntityBase
    {
        public User User { get; set; }
        public int UserID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string mail { get; set; }
        public int telephone { get; set; }

        public int? Actıve { get; set; }
  
        public string ekleme { get; set; }
        public string degistir { get; set; }
        public string silme { get; set; }
        public string görme { get; set; }


 



    }
}
