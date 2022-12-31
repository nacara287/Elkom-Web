using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    public partial class BANKA_FIS : EntityBaseFirma
    {
        public BANKA BANKA { get; set; }
        public int BANKAID { get; set; }
        public string BANKAKODU { get; set; }
        public int? TIP { get; set; }
        public int? deleted { get; set; }
        public string FISNO { get; set; }
        public DateTime TARIH { get; set; }
        public string NOT { get; set; }
        public double TUTAR { get; set; }
        public SORUMLULUK_MERKEZI SORUMLULUK_MERKEZI { get; set; }
        public int SORUMLULUK_MERKEZIID { get; set; }
        public virtual ICollection<BANKA_FIS_HAREKET> BANKA_FIS_HAREKETS { get; set; }
    }
}
