namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CARI_BORDRO: EntityBaseFirma
    {






        public CARI_BASLIK cari { get; set; }  
 public int? deleted { get; set; }
        public int cariID { get; set; }
        public int BORDROTIPI { get; set; }

        [StringLength(10)]
        public string BORDRONO { get; set; }

        
        [Column(Order = 2)]
        [StringLength(17)]
        public string CARIKOD { get; set; }

        public DateTime? TARIH { get; set; }

        public int? AYLIKVADE { get; set; }

        [StringLength(40)]
        public string ACIKLAMA { get; set; }

        public double? TOPLAMTUTAR { get; set; }

        [StringLength(10)]
        public string OZELKOD { get; set; }

        public int? IADE { get; set; }

        [StringLength(150)]
        public string YAZIILE { get; set; }

        public float? FISINDEXNO { get; set; }

        [StringLength(2)]
        public string BORNOSOL { get; set; }

        public float? BORNOSAG { get; set; }

        public double? KALANTUTAR { get; set; }

        public double? VADE_FARKI { get; set; }

        public double? GUNUDE_DEGER { get; set; }

        public int? ORT_GUN { get; set; }

        public DateTime? ORT_VADE { get; set; }

        public double? CEKTOPLAM { get; set; }

        public double? SENETTOPLAM { get; set; }

        public double? NAKITTOPLAM { get; set; }

        public double? DEKONTTOPLAM { get; set; }

        public double? VISATOPLAM { get; set; }

        public double? VIRMANTOPLAM { get; set; }
    
        public int? RESMI { get; set; }

      
        public int? S_MERKEZI { get; set; }

        [StringLength(15)]
        public string OLUSTURAN { get; set; }
        public virtual ICollection<CARI_BORDRO_HAREKET> CARI_BORDRO_HAREKETs { get; set; }
        public virtual ICollection<CARI_BORDRO_IADE> CARI_BORDRO_IADEs { get; set; }
        public virtual ICollection<CARI_BORDRO_TOPLU> CARI_BORDRO_TOPLUs { get; set; }
    }
}
