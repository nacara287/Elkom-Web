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
 public bool deleted { get; set; }
        public int KASAID { get; set; }


        [StringLength(17)]
        public string KASAKODU { get; set; }

        
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

        public kasaislemtürü ISLEMTURU { get; set; }
        public enum kasaislemtürü
        {Devir,
         KasaFişi,CariFişi,PerMaaş,KarşılıksızSenet,KarşılıksızÇek,TSenet,TÇek,Senet,Çek,Banka,BankayaTahsilat,TKarşılıksızSenet,TKarşılıksızÇek,Fatura,Stok

        }
        public int? MUHASEBEDURUM { get; set; }

        public CARI_HAREKET.tip TIPI { get; set; }
        

        [StringLength(50)]
        public string ILGILI { get; set; }

        public SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
    }
}
