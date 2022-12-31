namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KASA_HAREKET: EntityBaseFirma
    {



        public KASA KASA { get; set; }  
 public int? deleted { get; set; }
        public int KASAID { get; set; }



        public string KASAKODU { get; set; }

        
        [Column(Order = 2)]
        public DateTime TARIHSAAT { get; set; }

        
        [Column(Order = 3)]
        
        public int? ISLEMKODU { get; set; }

        public string ISLEMNO { get; set; }

      
        public string DOSYANO { get; set; }

        public double? BORC { get; set; }

        public double? ALACAK { get; set; }
        public double? BAKIYE { get; set; }

        public int? IADE { get; set; }

   
        public string ACIKLAMA { get; set; }

    

        public kasaislemtürü ISLEMTURU { get; set; }
        public enum kasaislemtürü
        {Devir,
         KasaFişi,CariFişi,PerMaaş,KarşılıksızSenet,KarşılıksızÇek,TSenet,TÇek,Senet,Çek,Banka,BankayaTahsilat,TKarşılıksızSenet,TKarşılıksızÇek,Fatura,Stok,BankadanPortfoy,VisaTahsili,VisaÖdeme,Gelir,Gider

        }
        public int? MUHASEBEDURUM { get; set; }

        public CARI_HAREKET.tip TIPI { get; set; }

        public enum kasahareket
        {
            Cari, Banka, Personel, Virman, Dekont, Gelir,Gider

        }

        public string ILGILI { get; set; }

        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
    }
}
