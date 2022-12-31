namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SENETLER_VERILEN: EntityBaseFirma
    {




        public string PORTFOYNO { get; set; }
        public string SENETNO { get; set; }

        public CEKLER_VERILEN.verilendurumlar SENETDURUMU { get; set; }  
 public int? deleted { get; set; }

        public double? TUTAR { get; set; }

        public DateTime? KESIDETARIHI { get; set; }

        public DateTime? VALOR { get; set; }

        public DateTime? IADETARIHI { get; set; }

        public DateTime? ODEMETARIHI { get; set; }


        public virtual CARI_BASLIK VERILENKISI { get; set; }

        public int VERILENKISIID { get; set; }

        public string ACIKLAMA { get; set; }

        public DateTime? VADE { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? PARA { get; set; }

    
        public string KASA { get; set; }
        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
    }
}
