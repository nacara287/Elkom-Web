namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_HAREKET: EntityBaseFirma
    {
        
        
        
        public PERSONEL PERSONEL { get; set; }
        public int PERSONELID { get; set; }

        public string PERSONELKODU { get; set; }  
 public int? deleted { get; set; }

        
        [Column(Order = 2)]
        public DateTime TARIHSAAT { get; set; }

        
        [Column(Order = 3)]
        
        public personeltür TURU { get; set; }

        public float? ISLEMNO { get; set; }

        [StringLength(15)]
        public string DOSYANO { get; set; }

        public double? BORC { get; set; }
        public double? BAKIYE { get; set; }

        public double? ALACAK { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public int DETAY { get; set; }


        public enum personeltür
        {
           Devir,PersonelFiþi,MaaþÝþlemleri,KasaFiþi
        }
       
        public int? MUHASEBEDURUM { get; set; }

        public CARI_HAREKET.tip TIPI { get; set; }

        public int? MAASAYI { get; set; }

        public int? HESAP_KAPAT { get; set; }

        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }
    }
}
