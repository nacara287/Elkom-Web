using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    public partial class BANKA_FIS_HAREKET : EntityBaseFirma
    {
        public BANKA_FIS BANKA_FIS { get; set; }
        public int BANKA_FISID { get; set; }
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
