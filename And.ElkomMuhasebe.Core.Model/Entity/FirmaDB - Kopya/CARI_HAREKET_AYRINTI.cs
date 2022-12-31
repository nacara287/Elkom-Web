namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_HAREKET_AYRINTI: EntityBaseFirma
    {
        
        
        

        public CARI_HAREKET CARI_HAREKET { get; set; }  
 public bool deleted { get; set; }
        public CARI_HAREKET CARI_HAREKETID { get; set; }

        [StringLength(17)]
        public string CARIKOD { get; set; }

        
        [Column(Order = 2)]
        public DateTime TARIHSAAT { get; set; }

        
        [Column(Order = 3)]
        
        public int ISLEMKODU { get; set; }

        public float? ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }

        public double? BORC { get; set; }

        public double? ALACAK { get; set; }

        public int? IADE { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public detay Detay { get; set; }
        public enum detay
        {
            Nakit,Çek,Senet,Dekont,Virman,Visa

        }

        public int? MUHASEBEDURUM { get; set; }

        public CARI_HAREKET.tip TIPI { get; set; }
      

        public int? PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }

        public CARI_HAREKET.tür ISLEMTURU { get; set; }


        public DateTime? VADE { get; set; }

        public double? BAKIYE { get; set; }

        public double? MIKTAR { get; set; }

        public double? BFIYAT { get; set; }

        public double? KBORC { get; set; }

        public double? KALACAK { get; set; }

        public double? KBAKIYE { get; set; }

        public int? S_MERKEZI { get; set; }

        [StringLength(30)]
        public string URUNKODU { get; set; }

        public int? RESMI { get; set; }

        public int? WEB_DURUM { get; set; }

        public double? WEB_ID { get; set; }

        public int? WEB_UPDATE { get; set; }
    }
}
