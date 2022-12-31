namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IRSALIYE")]
    public partial class IRSALIYE: EntityBaseFirma
    {



        public CARI_BASLIK CARI { get; set; }


        public int CARIID { get; set; }



        public int TIP { get; set; }  
 public int? deleted { get; set; }

        
        [Column(Order = 2)]
        [StringLength(17)]
        public string CARIKOD { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(10)]
        public string IRSNO { get; set; }

        [StringLength(15)]
        public string OZELKOD { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public int? DEPO { get; set; }

        public DateTime? ODEMETARIHI { get; set; }

        
        [Column(Order = 3)]
        
        public int KDVDAHIL { get; set; }

        
        [Column(Order = 4)]
        
        public int IADE { get; set; }

        
        [Column(Order = 5)]
        
        public int MUHASEBEDURUM { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        public double? KDVMATRAHI { get; set; }

        public double? KDVTUTARI { get; set; }

        public double? GENELTOPLAM { get; set; }

        public int? FATURALASTIMI { get; set; }

        [StringLength(2)]
        public string IRSNOSOL { get; set; }

        public double? IRSNOSAG { get; set; }

        [StringLength(40)]
        public string TESLIMALAN { get; set; }

        [StringLength(150)]
        public string YAZIILE { get; set; }

        public double? MASRAFTUTARI { get; set; }

        public int? ACIKKAPALI { get; set; }

        public float? FATURANO { get; set; }

        public DateTime? TESLIM_TARIH { get; set; }

        public double? ARATOPLAM { get; set; }

        public double? KALEMISKONTOSU { get; set; }

        public double? ISK1_TOPLAM { get; set; }

        public double? ISK2_TOPLAM { get; set; }

        [StringLength(5)]
        public string SAAT { get; set; }

        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
        public drumlar? DURUM { get; set; }
        public enum drumlar
        {
            Faturalaþtýrýlmadý,Faturalaþtýrýldý,KýsmenFaturalaþtýrýldý,StokFiþinde

        }

        public double? DUZLEME_ISKONTO { get; set; }

    }
}
