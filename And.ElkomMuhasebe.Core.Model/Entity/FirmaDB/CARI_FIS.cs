using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    public partial class   CARI_FIS : EntityBaseFirma
    {
        public  CARI_BASLIK Cari { get; set; }
        public int CariID { get; set; }
   
      
        public string CariKod { get; set; }

        public int? TIP { get; set; }
        public int? deleted { get; set; }
        public string FISNO { get; set; }
        public DateTime TARIH { get; set; }
        public string NOT { get; set; }
        public double TUTAR { get; set; }

        public SORUMLULUK_MERKEZI SORUMLULUK_MERKEZI { get; set; }
        public int SORUMLULUK_MERKEZIID { get; set; }
        public virtual ICollection<CARI_FIS_HAREKET> CARI_FIS_HAREKETs { get; set; }
    }
}
