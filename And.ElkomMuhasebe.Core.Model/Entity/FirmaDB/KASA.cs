namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KASA")]
    public partial class KASA : EntityBaseFirma
    {
        public türü? TUR { get; set; }
        public kasatipi TIPI { get; set; }  
 public int? deleted { get; set; }
        public enum kasatipi{
            Nakit,Çek,Senet,Visa

}
        public enum türü
        {
            Giriş,Çıkış

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? BAKIYE
        {
            get { return TOPLAMBORC - TOPLAMALACAK; }
            private set { /* needed for EF */ }
        }
        public double? TOPLAMBORC { get; set; }

        public double? TOPLAMALACAK { get; set; }

        
      
        public string KASAKODU { get; set; }

        [StringLength(30)]
        public string KASAADI { get; set; }

        
        public byte[] BILGI { get; set; }

        public string PBIRIMI { get; set; }
        public virtual ICollection<KASA_HAREKET> KASA_HAREKETs { get; set; }
       
}
}
