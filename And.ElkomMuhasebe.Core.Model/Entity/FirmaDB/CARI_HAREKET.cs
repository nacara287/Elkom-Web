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
 public int? deleted { get; set; }
        public int cariID { get; set; }


        public string CARIKOD { get; set; }

        
   
        public DateTime TARIHSAAT { get; set; }

        
     
        
        public int ISLEMKODU { get; set; }

        public string ISLEMNO { get; set; }

      
        public string DOSYANO { get; set; }

        public double? BORC { get; set; }

        public double? ALACAK { get; set; }

        public double? DOVIZBORC { get; set; }

        public double? DOVIZALACAK { get; set; }

        public double? KUR { get; set; }
        public string PARABIRIMI { get; set; }


        public int? IADE { get; set; }


        public string ACIKLAMA { get; set; }

        public CARI_HAREKET_AYRINTI.detay KAYITSEKLI { get; set; }

        public int? MUHASEBEDURUM { get; set; }

        public tip TIPI { get; set; }
      
        public enum tip
        {Devir,
            Giriş,Çıkış,
           

        }

        public double? BAKIYE { get; set; }

        public double? DOVIZBAKIYE { get; set; }

 
    
        public tür ISLEMTURU { get; set; }

        public enum tür
        {
            Devir,
            Fatura, CariFişi,Havale,Virman,StokFişi,VisaKomisyon,KasaFişi,GGiderler,ÇekSenet,ServisHizmet,İrsaliye,EFatura,EArşiv,BankaFişi,PersonelFişi,Çekİade,Senetİade,Visa


        }

        public DateTime? VADE { get; set; }

        public int? ORTVADE { get; set; }

        public int? RESMI { get; set; }

        public int  S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
      
        public virtual ICollection<CARI_HAREKET_AYRINTI> CARI_HAREKET_AYRINTIs { get; set; }
    }
}
