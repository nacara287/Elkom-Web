namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        [StringLength(20)]
        public string PERSONELKODU { get; set; }  
 public bool deleted { get; set; }

        
        [Column(Order = 2)]
        public DateTime TARIHSAAT { get; set; }

        
        [Column(Order = 3)]
        
        public int ISLEMKODU { get; set; }

        public float? ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }

        public double? BORC { get; set; }

        public double? ALACAK { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public int? KAYITSEKLI { get; set; }

        public int? MUHASEBEDURUM { get; set; }

        public int? TIPI { get; set; }

        public int? MAASAYI { get; set; }

        public int? HESAP_KAPAT { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
