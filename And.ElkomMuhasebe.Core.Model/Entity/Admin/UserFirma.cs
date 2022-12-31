using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.ElkomMuhasebe.Core.Model.Entity.Admin
{
    public class UserFirma : EntityBase
    {
        public User User { get; set; }
        public int UserID{ get; set; }
        public string Companyname { get; set; }
        public string DatabaseName { get; set; }
        public bool Using { get; set; }
     
    }
}
