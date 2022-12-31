namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GIDER_BORDRO_HAREKET: EntityBaseFirma
    {






        public virtual GIDER_BASLIK GIDER_BASLIK { get; set; }
        public int GIDER_BASLIKID { get; set; }


        [StringLength(15)]
        public string GIDERKODU { get; set; }  
 public int? deleted { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        
        [Column(Order = 2)]
        public double TUTARI { get; set; }
        public CARI_HAREKET.tür ISLEMTURU { get; set; }
        public string FISNO { get; set; }

        public string PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }

        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
    }
}
