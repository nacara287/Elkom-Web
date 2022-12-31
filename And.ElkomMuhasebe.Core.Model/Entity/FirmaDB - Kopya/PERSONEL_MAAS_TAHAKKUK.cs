namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_MAAS_TAHAKKUK: EntityBaseFirma
    {
        public float? INDEXNO { get; set; }  
 public bool deleted { get; set; }

        
        [StringLength(20)]
        public string PERSONELKODU { get; set; }

        [StringLength(2)]
        public string FISNOSOL { get; set; }

        public float? FISNOSAG { get; set; }

        [StringLength(10)]
        public string FISNO { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(100)]
        public string ACIKLAMA { get; set; }

        [StringLength(10)]
        public string OZELKOD { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        public int? GUN { get; set; }

        public double? MAAS { get; set; }

        public double? MAASTUTARI { get; set; }

        public int? DONEM { get; set; }

        public int? YIL { get; set; }

        public double? NET_TUTARI { get; set; }

        [StringLength(15)]
        public string KASAKODU { get; set; }

        public double? AVANSTOPLAM { get; set; }

        public int? GUN_CALIS { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
