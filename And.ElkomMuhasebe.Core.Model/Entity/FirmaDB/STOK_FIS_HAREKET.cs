namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_FIS_HAREKET: EntityBaseFirma
    {




        public STOK_DEPO DEPOSU { get; set; }
        public int DEPOSUID { get; set; }
        public int fisid{ get; set; }

        public string fisno { get; set; }
        public string STOKKODU { get; set; }

        public int STOKID{ get; set; }

public virtual STOK STOK { get; set; }


        public int? deleted { get; set; }

        
        [Column(Order = 3)]
        
        public string BIRIM { get; set; }

        
        [Column(Order = 4)]
        public double MIKTAR { get; set; }

        public double? FIYAT { get; set; }

        public double? TOPLAMTUTAR { get; set; }


      

        public string PARABIRIMI { get; set; }

        public string PARAKUR { get; set; }

        public double? ISK1 { get; set; }

        public double? ISK2 { get; set; }

        public double? NETFIYAT { get; set; }

        public double? ISKTOPLAM { get; set; }

        public double? ISK1TUTAR { get; set; }

        public double? ISK2TUTAR { get; set; }

        public double? MASRAF { get; set; }

        public double? MASRAFTUTAR { get; set; }

        public double? ARATOPLAM { get; set; }

        [StringLength(50)]
        public string ACIKLAMA { get; set; }

        public float? SIP_NO { get; set; }

        public int? KAR { get; set; }

        public int? S_MERKEZI { get; set; }
    }
}
