namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GELIR_BORDRO_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        public virtual GELIR_BASLIK GELIR_BASLIK { get; set; }
        public int GELIR_BASLIKKID { get; set; }


        [StringLength(15)]
        public string GELIRKODU { get; set; }  
 public int? deleted { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        
        [Column(Order = 2)]
        public double TUTARI { get; set; }

        public string PARABIRIMI { get; set; }


        public CARI_HAREKET.tür ISLEMTURU { get; set; }
        public string FISNO { get; set; }

        public double? PARAKUR { get; set; }

        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
    }
}
