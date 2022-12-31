namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOK_HAREKET: EntityBaseFirma
    {
        
        
        

        
        
        
        public STOK STOK { get; set; }
        public int STOKID { get; set; }
        [Column(Order = 2)]
        [StringLength(30)]
        public string STOKKODU { get; set; }  
 public int? deleted { get; set; }

        
        [Column(Order = 3)]

        public string BELGENO { get; set; }
        public string ACIKLAMA { get; set; }


        public stoktur ISLEMTURU { get; set; }
        public enum stoktur
        {
            Devir,
            StokFiþi, Fatura, Ýrsaliye, DepoFiþi, Üretim, Adisyon, SarfZayi,EFatura,EArþiv


        }

        [Column(Order = 4)]
        public double MIKTAR { get; set; }

        
        [Column(Order = 5)]
        public double FIYAT { get; set; }

   
        public double? KDVLIFIYAT { get; set; }



        [Column(Order = 6)]
        
        public CARI_HAREKET.tip TIPI { get; set; }
      


        [Column(Order = 7)]
        public DateTime TARIH { get; set; }

     

        public int? CARIID { get; set; }

        public virtual CARI_BASLIK CARI { get; set; }
     

        public int? BIRIM { get; set; }

        public int? BIRIMADET { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? MALIYETORT
        {
            get {
                if(STOKMIKTAR_GIREN==0|| TL_STOKALIS_TOPLAM == 0)
                {
                    return 0;
                }
                else
                {
                    return TL_STOKALIS_TOPLAM / STOKMIKTAR_GIREN;
                }
            }
                
              
            private set { /* needed for EF */ }
        }
    
    
        public double? MALIYETFIFO { get; set; }

        public double? MALIYETLIFO { get; set; }

        public double? TUTAR { get; set; }


        public STOK_DEPO DEPOSU { get; set; }
        public int DEPOSUID { get; set; }
        public string PARABIRIMI { get; set; }

        public double? PARAKUR { get; set; }

        public float? LIFOADET { get; set; }

        public float? FIFOADET { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? SONMALIYET
        {
            get { return FIYAT * KUR_FIYAT; }
            private set { /* needed for EF */ }
        }

        public double? TL_FIYAT { get; set; }

        public double? TL_TUTAR { get; set; }

        public double? KUR_FIYAT { get; set; }

        public double? DOVIZ_TUTAR { get; set; }

        public float? STOKMIKTAR { get; set; }
        public float? STOKMIKTAR_GIREN { get; set; }

        public double? TL_STOKALIS_TOPLAM{ get; set; }

        public double? DOVIZ_STOKALIS_TOPLAM { get; set; }
        public double? EK_MALIYET { get; set; }

        public int? IADE { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? DOVIZ_MALIYETORT
        {
            get
            {
                if (STOKMIKTAR_GIREN == 0 || DOVIZ_STOKALIS_TOPLAM == 0)
                {
                    return 0;
                }
                else
                {
                    return DOVIZ_STOKALIS_TOPLAM / STOKMIKTAR_GIREN;
                }

              
            
            
            
            }
            private set { /* needed for EF */ }
        }
    
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? DOVIZ_SONMALIYET
        {
            get { return  FIYAT; }
            private set { /* needed for EF */ }
        }

        public int? KAR { get; set; }
        public int S_MERKEZIID { get; set; }
        public virtual SORUMLULUK_MERKEZI S_MERKEZI { get; set; }

        public double? ISK1 { get; set; }

        public double? ISK2 { get; set; }

        public double? Y_ORT_MALIYET { get; set; }

        public double? MALIYETFIFO_DEPO { get; set; }
    }
}
