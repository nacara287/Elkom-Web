namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_MAAS_TAHAKKUK_HAREKET: EntityBaseFirma
    {









        public PERSONEL_MAAS_TAHAKKUK PERSONEL_MAAS_TAHAKKUK { get; set; }
        public int PERSONEL_MAAS_TAHAKKUKID { get; set; }



        public string FISNO { get; set; }
        public string HAREKET { get; set; }  
 public int? deleted { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        
        [Column(Order = 3)]
        public double TUTARI { get; set; }

        [StringLength(10)]
        public string BIRIM { get; set; }

        public double? BIRIM_MIKTAR { get; set; }

        public double? BIRIM_UCRET { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
