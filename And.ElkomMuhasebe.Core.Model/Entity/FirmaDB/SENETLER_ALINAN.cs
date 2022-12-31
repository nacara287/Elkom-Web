namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SENETLER_ALINAN: EntityBaseFirma
    {



        public string PORTFOYNO { get; set; }  
 public int? deleted { get; set; }

        
        
        
        public CEKLER_ALINAN.alinandurumlar SENETDURUMU { get; set; }

        public string SENETKESIDEEDEN { get; set; }
          public virtual BANKA VERILENBANKA { get; set; }

        public int? VERILENBANKAID { get; set; }
      
        public string SENETADRES1 { get; set; }

        public string SENETADRES2 { get; set; }

        
        public string SENETSEHIR { get; set; }

        public DateTime? SENETKESIDETARIHI { get; set; }

      
        public string SENETVERGIDAI { get; set; }

        public double? TUTAR { get; set; }

        public DateTime? TARIH { get; set; }


        public virtual CARI_BASLIK CIROKISI { get; set; }

        public int? CIROKISIID { get; set; }

        public DateTime? CIROTARIHI { get; set; }

       
        public string VERILENBANKAKODU { get; set; }

        public DateTime? VERILENBANKATARIHI { get; set; }

        public DateTime? TAHSILTARIHI { get; set; }

        public DateTime? IADETARIHI { get; set; }

   

       
        public string ACIKLAMA { get; set; }

        public DateTime? VADE { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARA { get; set; }


        public string KASA { get; set; }

        public int? RISKDENDUS { get; set; }

        public int S_MERKEZIID { get; set; }
        public virtual CARI_BASLIK ALINANKISI { get; set; }

        public int ALINANKISIID { get; set; }

        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }


        public string YAZIILE { get; set; }
    }
}
