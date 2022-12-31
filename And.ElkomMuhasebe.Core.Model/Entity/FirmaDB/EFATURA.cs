namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EFATURA: EntityBaseFirma
    {

        public CARI_BASLIK CARI { get; set; }

        public int CARIID { get; set; }

        public CARI_HAREKET.tip? TIP { get; set; }
        public string GONDERIMTURU{ get; set; }
        public string GIBFATURATURU { get; set; }
        public string VKN { get; set; }
        public string PK { get; set; }
        public string STATU { get; set; }
 
        public double? FATURATUTAR { get; set; }
        public string FATURANO { get; set; }
        public string ETTN { get; set; }



        public string SeriNo { get; set; }
        public int? Sýra { get; set; }
        public string MUSTERI { get; set; }
        public DateTime? TARIH { get; set; }
        public string FATURAURL { get; set; }
        public bool? STOKESLENDI { get; set; }
      
        public bool? OKUNDU { get; set; }
        public int S_MERKEZIID { get; set; }
        
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
public virtual ICollection<EFATURAIN> eFATURAINs { get; set; }

    }
}
