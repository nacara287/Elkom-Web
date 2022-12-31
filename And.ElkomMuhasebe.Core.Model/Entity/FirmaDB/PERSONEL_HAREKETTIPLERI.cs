namespace And.ElkomMuhasebe.Core.Model.Entity.FirmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSONEL_HAREKETTIPLERI : EntityBaseFirma
    {
        public string HAREKETADI { get; set; }
        public string BIRIMADI { get; set; }
        public double? BIRIMUCRETI { get; set; }

        public string ACIKLAMA { get; set; }

    }
}
