namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_HAREKET: EntityBaseFirma
    {


       

        public CARI_BASLIK cari { get; set; }  
 public bool deleted { get; set; }
        public int cariID { get; set; }

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

        public CARI_HAREKET_AYRINTI.detay KAYITSEKLI { get; set; }

        public int? MUHASEBEDURUM { get; set; }

        public tip TIPI { get; set; }
        public enum tip
        {Devir,
            Giriş,Çıkış,
           

        }

        public double? BAKIYE { get; set; }

        public tür ISLEMTURU { get; set; }
        public enum tür
        {
            Devir,
            Fature, CariFişi,Havale,Virman,StokFişi,VisaKomisyon,KasaFişi,GGiderler,ÇekSenet,ServisHizmet


        }

        public DateTime? VADE { get; set; }

        public int? ORTVADE { get; set; }

        public int? RESMI { get; set; }
     
        
    public SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
        public virtual ICollection<CARI_HAREKET_AYRINTI> CARI_HAREKET_AYRINTIs { get; set; }
    }
}
