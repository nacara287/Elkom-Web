namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CEKLER_ALINAN: EntityBaseFirma
    {
        
        
        public string PORTFOYNO { get; set; }  
 public int? deleted { get; set; }

        
        
        
        public alinandurumlar CEKDURUMU { get; set; }
        public enum alinandurumlar
        {
            Pörtföy,Ciro,TahsilEdildi,BankayaTahsilVerildi,Karþýlýksýz,ÝadeEdilenler,BankadanTahsilEdildi,BankadanPortfoy

        }

        
        [Column(Order = 2)]
     
        public string CEKNO { get; set; }

    
        public string CEKKESIDEEDEN { get; set; }

       
        public string CEKKESIDEYERI { get; set; }

        public DateTime? CEKKESIDETARIHI { get; set; }


        public string CEKVERGIDAI { get; set; }

        public double? TUTAR { get; set; }

        public DateTime? VALOR { get; set; }


        public string ACIKLAMA { get; set; }

        public DateTime? TARIH { get; set; }

     
        public string CEKBANKA { get; set; }

        public DateTime? CIROTARIHI { get; set; }

        public virtual CARI_BASLIK CIROKISI { get; set; }

        public int? CIROKISIID { get; set; }
       

        public DateTime? TAHSILTARIHI { get; set; }

        public virtual BANKA VERILENBANKA { get; set; }

        public int? VERILENBANKAID { get; set; }


        public DateTime? VERILENBANKATARIHI { get; set; }

        public DateTime? IADETARIHI { get; set; }

      

        public virtual CARI_BASLIK ALINANKISI { get; set; }

        public int ALINANKISIID { get; set; }

        public DateTime? VADE { get; set; }

  
        public string CEKSUBE { get; set; }

       
        public string CEKHESAPNO { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARA { get; set; }

        public string KASA { get; set; }

        public int? RISKDENDUS { get; set; }

        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
    }
}
