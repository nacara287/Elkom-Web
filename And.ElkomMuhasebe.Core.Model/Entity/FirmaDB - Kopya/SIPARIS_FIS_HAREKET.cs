namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SIPARIS_FIS_HAREKET: EntityBaseFirma
    {
        
        

        

        [Required]
        [StringLength(30)]
        public string STOKKODU { get; set; }  
 public bool deleted { get; set; }

        [StringLength(50)]
        public string ACIKLAMA { get; set; }

        public int BIRIM { get; set; }

        public double MIKTAR { get; set; }

        public double? FIYAT { get; set; }

        public int? KDV { get; set; }

        public double? ARATOPLAM { get; set; }

        public double? ISK1 { get; set; }

        public double? ISK1TUTAR { get; set; }

        public double? ISK2 { get; set; }

        public double? ISK2TUTAR { get; set; }

        public double? ISKTOPLAM { get; set; }

        public double? MASRAF { get; set; }

        public double? MASRAFTUTAR { get; set; }

        public double? NETFIYAT { get; set; }

        public double? KDVMATRAHI { get; set; }

        public double? KDVTUTARI { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        public int DEPONO { get; set; }

        public double? ONAY { get; set; }

        public double? GENELTOPLAM { get; set; }

        public DateTime? TESLIM_TARIHI { get; set; }

        public int? TESLIM_TURU { get; set; }

        [StringLength(10)]
        public string TESLIM_BELGENO { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Z { get; set; }

        public double? OZEL_MALIYET { get; set; }

        public int? S_MERKEZI { get; set; }

        [StringLength(20)]
        public string RENK { get; set; }

        public int? WEB_DURUM { get; set; }

        public virtual SIPARIS_FIS SIPARIS_FIS { get; set; }
    }
}
