namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SMS_BASLIK: EntityBaseFirma
    {
        
        

        [StringLength(17)]
        public string CARIKOD { get; set; }  
 public bool deleted { get; set; }

        [StringLength(20)]
        public string TELNO { get; set; }

        public int? SMS_MESAJID { get; set; }

        public int? MESAJ_TIPI { get; set; }

        public int DURUM { get; set; }

        public DateTime? TARIH { get; set; }

        public DateTime? GONDERME_TARIHI { get; set; }

        public DateTime? SONUC_TARIH { get; set; }

        public float? EVRAK_ID { get; set; }

        public virtual SMS_MESAJ SMS_MESAJ { get; set; }
    }
}
