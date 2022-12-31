using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace And.ElkomMuhasebe.Core.Model.Entity.Admin
{
    public class User:EntityBase
    {
        
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string mail { get; set; }
        public string telephone { get; set; }
        public bool  IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string kullanılanfirma { get; set; }

        public virtual IEnumerable<UserFirma> Firmas { get; set; }
        public virtual IEnumerable<AltUser> AltUsers { get; set; }
        public versiontype Version { get; set; }
        public string kullanma { get; set; }

        public enum versiontype
        {
            Deneme,
            Mikro,
            Standart, Pro, Üretim


        }
    }
}
