using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    public partial class CARI_FIS_HAREKET : EntityBaseFirma
    {
        public CARI_FIS CARI_FIs { get; set; }
        public int CARI_FIsID { get; set; }
        public string HAREKET { get; set; }
        public string KASA { get; set; }
        public string PORTFÖYNO { get; set; }
        public string ACIKLAMA { get; set; }
        public string VADE { get; set; }
        public string TUTAR { get; set; }
        public string PARABIRIMI { get; set; }
        public string PARAKURU { get; set; }
        public string NETTUTAR { get; set; }
        public int? deleted { get; set; }

    }
}
