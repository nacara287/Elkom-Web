namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SIPARIS_FIS_HAREKET: EntityBaseFirma
    {
        public virtual STOK STOK { get; set; }
        public int STOKID { get; set; }

        public virtual SIPARIS_FIS SIPARIS_FIS { get; set; }
        public int SIPARIS_FISID { get; set; }
        public string SIPARISNO { get; set; }

        public string STOKKODU { get; set; }
        public int? deleted { get; set; }


        [Column(Order = 3)]

        public string BIRIM { get; set; }
        public int? KULLANIMDA { get; set; }
        public string BELGENO { get; set; }

        public double? FIYAT { get; set; }

        public int? KDV { get; set; }


        [Column(Order = 4)]
        public double MIKTAR { get; set; }

        public double? TOPLAMFIYAT { get; set; }

        public double? KDVMATRAHI { get; set; }

        public double? KDVTUTARI { get; set; }

        public int? ONAY { get; set; }

        public string PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }


        [Column(Order = 5)]

        public int DEPONO { get; set; }

        public double? ISK1 { get; set; }

        public double? ISK2 { get; set; }

        public double? NETFIYAT { get; set; }

        public double? ISKTOPLAM { get; set; }

        [StringLength(50)]
        public string ACIKLAMA { get; set; }


        public string EN { get; set; }

        public string BOY { get; set; }
        public string YUKSEKLIK { get; set; }
        public string RENK { get; set; }


        public double? TUTAR { get; set; }

        [StringLength(10)]
        public string BIRIM2 { get; set; }

        public double? MIKTAR2 { get; set; }

        public double? OTVTUTAR { get; set; }

        public int? IRS_NO { get; set; }

        public double? OTVSIZ_FIYAT { get; set; }

        public int? KAR { get; set; }

        public int? S_MERKEZI { get; set; }

    }
}
