namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EFATURAIN: EntityBaseFirma
    {

        public int EFATURAID { get; set; }

        public virtual EFATURA EFATURA { get; set; }
        public string SERINO { get; set; }
            public string GONDERIMTIPI { get; set; }
            public string GONDERIMSEKLI { get; set; }
            public string GONDERIMSENARYO { get; set; }
            public string UUID { get; set; }
            public string KOD { get; set; }

            
                  public string EKVERGINO { get; set; }
            public string MUKELLEFKODU { get; set; }

            public string MUKELEFADI { get; set; }
            public string DOSYANO { get; set; }
            public string ILAVEFATURATIPI { get; set; }

            public string MALHIZMET { get; set; }

            public string TEVFIKAT3 { get; set; }
            public string TEVFIKAT5 { get; set; }
            public string TEVFIKAT7 { get; set; }
            public string TEVFIKAT9 { get; set; }
            public string ISTISNA { get; set; }

        public string KDV1 { get; set; }
            public string KDV8 { get; set; }
            public string KDV18 { get; set; }
            public string MATRAH { get; set; }
        public int[] IRSALIYELER { get; set; }
        public string IRSALIYELERARRAY{ get; set; }
        public int[] SIPARISLER { get; set; }
        public string SIPARISLERARRAY { get; set; }
        public string TOPLAMKDV { get; set; }
            public string ISKONTOTOPLAM { get; set; }

          
            public string ODENCEKTUTAR { get; set; }
        public int KDVDAHIL { get; set; }

        public CARI_BASLIK CARI { get; set; }

        public int CARIID { get; set; }
        public string FISNO { get; set; }
            public string TARIH { get; set; }
            public string ODEMETARIHI { get; set; }
            public string NOT { get; set; }
            public string SORUMLULUK_MERKEZI { get; set; }
            public string DEPO { get; set; }
            public string PARABIRIMI { get; set; }

            public string PARABIRIMIKUR { get; set; }

            public string ODEMESEKLI { get; set; }
            public string ODEMEKANALI { get; set; }
            public string ODEMEHESAPNO { get; set; }
            public string SIPARISNO { get; set; }
            public string SIPARISTARIH { get; set; }


            public CARI_HAREKET.tip TIPI { get; set; }
  

        public int S_MERKEZIID { get; set; }
        
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
        public ICollection<EFATURAIN_HAREKET> Hareketler { get; set; }
    }
}
