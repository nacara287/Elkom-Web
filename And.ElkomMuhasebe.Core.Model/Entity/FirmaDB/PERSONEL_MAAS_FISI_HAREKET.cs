namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_MAAS_FISI_HAREKET: EntityBaseFirma
    {
        public float? INDEXNO { get; set; }  
 public int? deleted { get; set; }

        
        
        

        
        
        [StringLength(17)]
        public string PERSONELKODU { get; set; }

        [StringLength(15)]
        public string KASAKODU { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public int? DONEM { get; set; }

        public int? GUN { get; set; }

        public double? MAAS { get; set; }

        public double? MAASTUTARI { get; set; }

        public double? AVANS { get; set; }

        public double? NETTUTAR { get; set; }

        
        [Column(Order = 2)]
        
        public int ISLEMKODU { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
