namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FATURA_PARAKENDE_AYARLAR: EntityBaseFirma
    {
        
        public int ID { get; set; }  
 public int? deleted { get; set; }

        [StringLength(100)]
        public string FATURA_YAZICI { get; set; }

        [StringLength(100)]
        public string STOK_FISI_YAZICI { get; set; }

        [StringLength(15)]
        public string NAKIT_KASA { get; set; }

        [StringLength(15)]
        public string VIZA_KASA { get; set; }

        public int? FIYAT_ONDALIK_BASAMAK { get; set; }

        [StringLength(17)]
        public string VARSAYILAN_MUSTERI { get; set; }

        public int? KASA_DEGISTIREMEZ { get; set; }

        public int? FIYAT_DEGISTIREMEZ { get; set; }

        [StringLength(15)]
        public string VISA_BANKA { get; set; }
    }
}
