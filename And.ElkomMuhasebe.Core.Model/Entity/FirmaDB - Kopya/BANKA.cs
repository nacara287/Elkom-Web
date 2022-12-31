namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANKA")]
    public partial class BANKA: EntityBaseFirma
    {





        [StringLength(17)]
        public string BANKAKODU { get; set; }  
 public bool deleted { get; set; }

        
     
        [StringLength(20)]
        public string BANKAADI { get; set; }

        [StringLength(20)]
        public string SUBEADI { get; set; }

        [StringLength(15)]
        public string TELEFON1 { get; set; }

        [StringLength(15)]
        public string TELEFON2 { get; set; }

        [StringLength(30)]
        public string YETKILI { get; set; }

        [StringLength(20)]
        public string HESAPNO { get; set; }

        public int? MUHASEBEKODU { get; set; }

        public int? FAIZORANI { get; set; }

        public double? BAKIYE { get; set; }

        public int? VISA { get; set; }

        public double? TOPLAMBORC { get; set; }

        public double? TOPLAMALACAK { get; set; }

        public double? VISAKOMISYON { get; set; }

        public double? CEK_TOPLAM { get; set; }

        public double? SENET_TOPLAM { get; set; }

        public int? KREDI { get; set; }

        public int? VISA_GUN { get; set; }

        [StringLength(15)]
        public string KOD1 { get; set; }

        [StringLength(15)]
        public string KOD2 { get; set; }

        [StringLength(50)]
        public string IBAN { get; set; }

        [StringLength(500)]
        public string ACIKLAMA { get; set; }

        [StringLength(15)]
        public string KOMISYON_GIDER_KODU { get; set; }
    }
}
