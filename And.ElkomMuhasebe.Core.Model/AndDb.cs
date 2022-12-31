using And.ElkomMuhasebe.Core.Model.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.ElkomMuhasebe.Core.Model
{
    public class AndDB : DbContext
    {
        public AndDB()
              :base("name=postgresadmin")
        { 
          
}
        public DbSet<Entity.Admin.User> Users { get; set; }
        public DbSet<Entity.Admin.UserFirma> userFirmas { get; set; }
        public DbSet<Entity.Admin.AltUser> altUsers { get; set; }
        public virtual DbSet<VERGIDAIRE> VERGIDAIRE { get; set; }
        public virtual DbSet<ILILCE> ILILCE { get; set; }
        public virtual DbSet<TEVFIKATKODLARI> TEVFIKATKODLARI { get; set; }
        public virtual DbSet<ISTISNAKODLARI> ISTISNAKODLARI { get; set; }
        public virtual DbSet<OZELMATRAHKODLARI> OZELMATRAHKODLARI { get; set; }
        public virtual DbSet<TESLIMSARTLARI> TESLIMSARTLARI { get; set; }
        public virtual DbSet<ESYANINBULUNDUGUKABINCINSI> ESYANINBULUNDUGUKABINCINSI { get; set; }
        public virtual DbSet<ESYANINGONDERIMSEKLI> ESYANINGONDERIMSEKLI { get; set; }
        public virtual DbSet<STOK_BIRIM> STOK_BIRIMLER { get; set; }
        public virtual DbSet<ULKELER> ULKELER { get; set; }
        public DbSet<Fedback> Fedbacks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
          
            base.OnModelCreating(modelBuilder);
        }

    }
}

