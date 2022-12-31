namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FATURA")]
    public partial class FATURA: EntityBaseFirma
    {


        public CARI_BASLIK CARI { get; set; }

        public int CARIID { get; set; }


        public int TIP { get; set; }  
 public int? deleted { get; set; }

        [Required]
        [StringLength(17)]
        public string CARIKOD { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(10)]
        public string FATNO { get; set; }

        [StringLength(15)]
        public string OZELKOD { get; set; }

        [StringLength(50)]
        public string ACIKLAMA { get; set; }

        public int? DEPO { get; set; }
        public double? TOPLAMSONTUTAR { get; set; }
        public int ACIKKAPALI { get; set; }

        public DateTime? ODEMETARIHI { get; set; }

        public int KDVDAHIL { get; set; }

        public int IADE { get; set; }

        public int MUHASEBEDURUM { get; set; }

        public double? TOPLAMMALIYET { get; set; }

        public double? KALEMISKONTOSU { get; set; }

        public double? ALTISKONTO { get; set; }

        public double? KDVMATRAHI { get; set; }

        public double? KDVTUTARI { get; set; }

        public double? TOPLAMMIKTAR { get; set; }

        public int? KAYITSEKLI { get; set; }

        [StringLength(2)]
        public string FATNOSOL { get; set; }

        public double? FATNOSAG { get; set; }

        public double? KALANTUTAR { get; set; }

        [StringLength(40)]
        public string TESLIMALAN { get; set; }

        [StringLength(150)]
        public string YAZIILE { get; set; }

        public float? FISINDEXNO { get; set; }

        public double? MASRAFTUTARI { get; set; }

        [StringLength(250)]
        public string FATURANOTU { get; set; }

        public string IRSLER { get; set; }
        public string SPARISLER { get; set; }
        public string STOKFISLER { get; set; }

        public double? ISK1 { get; set; }

        public double? ISK2 { get; set; }

        public double? ISK3 { get; set; }

        [StringLength(20)]
        public string PERSONEL { get; set; }

        [StringLength(15)]
        public string KASAKODU { get; set; }

        [StringLength(500)]
        public string IRSNO_TARIH { get; set; }

        [StringLength(10)]
        public string IRSALIYENO { get; set; }

        public DateTime? IRSALIYE_TARIH { get; set; }

        public double? KDV_1 { get; set; }

        public double? KDV_2 { get; set; }

        public double? KDV_3 { get; set; }

        public double? KDV_4 { get; set; }

        public double? KDV_5 { get; set; }

        [StringLength(5)]
        public string KDV_ET_1 { get; set; }

        [StringLength(5)]
        public string KDV_ET_2 { get; set; }

        [StringLength(5)]
        public string KDV_ET_3 { get; set; }

        [StringLength(5)]
        public string KDV_ET_4 { get; set; }

        [StringLength(5)]
        public string KDV_ET_5 { get; set; }

        [StringLength(5)]
        public string SAAT { get; set; }

        [StringLength(255)]
        public string IRSNOLARI { get; set; }

        [StringLength(255)]
        public string IRSTARIHLERI { get; set; }

        public double? ARATOPLAM { get; set; }

        public double? EKMASRAF { get; set; }

        [StringLength(70)]
        public string EKMASRAF_ACIKLAMA { get; set; }

        public double? PARAKUR { get; set; }

        public double? DOVIZ_GENELTOPLAM { get; set; }

        public int? PARABIRIMI { get; set; }

        public double? FATURATEV { get; set; }

        public int? KDVTEV { get; set; }

        public double? KDVTOPLAM { get; set; }

        public int? KDVSIZ { get; set; }

        public double? TEVSIZ_GENELTOPLAM { get; set; }

        public double? OTVTUTAR { get; set; }

        public double? OTVSIZ_TUTAR { get; set; }

        public double? TEVORAN { get; set; }

        public double? STOPAJ_ORAN { get; set; }

        public double? STOPAJ_TUTAR { get; set; }

        public double? ONCEKI_BAKIYE { get; set; }

        public double? DOVIZ_KUR_1 { get; set; }

        public double? DOVIZ_KUR_2 { get; set; }

        public double? DOVIZ_KUR_3 { get; set; }
        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }

        public double? DUZLEME_ISKONTO { get; set; }

        public double? KOMISYON { get; set; }

        public int? E_FATURA { get; set; }

        [StringLength(50)]
        public string E_FATURA_ETTN { get; set; }

        [StringLength(50)]
        public string E_FATURA_NO { get; set; }

        public int? E_FATURA_SENARYO { get; set; }

        public int? E_FATURA_TIPI { get; set; }
    }
}
