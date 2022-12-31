namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EFATURAIN_HAREKET: EntityBaseFirma
    {
        public int  EFATURAINID { get; set; }
        public virtual EFATURAIN EFATURAIN { get; set; }
    
        public string STOKKOD { get; set; }


        public STOK_DEPO DEPO { get; set; }
        public int DEPOID { get; set; }
        public int GELIRGIDER { get; set; }
        public int MALHIZMET { get; set; }

        public string ACIKLAMA { get; set; }
        public string MIKTAR { get; set; }
        public string BIRIM { get; set; }


        public string KFIYAT { get; set; }
        public string FIYAT { get; set; }
        public string ISKONTO { get; set; }
        public string ISKONTOTUTAR { get; set; }
        public string KDVORANI { get; set; }
        public string KDVTUTAR { get; set; }

        public string TEVFIKAT { get; set; }
        public string TEVFIKATORAN { get; set; }
        public string TEVFIKATTUTAR { get; set; }
        public string TESLIMSARTI { get; set; }
        public string GTIP { get; set; }
        public string ESYANINGONDERIMSEKLI { get; set; }
        public string ESYANINBULUNDUGUKAP { get; set; }
        public string KAPADET { get; set; }
        public string TOPLAM { get; set; }
        public string REFERANSNO { get; set; }
        public int? REFERANSID { get; set; }
    }
}
