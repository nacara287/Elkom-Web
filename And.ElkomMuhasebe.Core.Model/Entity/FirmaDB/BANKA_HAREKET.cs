namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANKA_HAREKET: EntityBaseFirma
    {
        
        

      
        public BANKA BANKA { get; set; }
    
        public int BANKAID { get; set; }
        [Required]
        public string BANKAKODU { get; set; }  
 public int? deleted { get; set; }

        public DateTime TARIHSAAT { get; set; }

        public int ISLEMKODU { get; set; }

        public string ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }

        public double? BORC { get; set; }
        public double? BAKIYE { get; set; }

        public double? ALACAK { get; set; }

        public int? IADE { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public ayrýntý KAYITSEKLI { get; set; }

        public int? MUHASEBEDURUM { get; set; }

        public CARI_HAREKET.tip TIPI { get; set; }


        public CARI_HAREKET.tür ISLEMTURU { get; set; }
        public enum ayrýntý
        {
            Devir,
            Nakit, Çek, Senet, Dekont, Virman, Havale, Personel, GGiderler


        }

        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
    }
}
