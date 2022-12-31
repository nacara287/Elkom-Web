namespace And.ElkomMuhasebe.Core.Model.Migrations
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;

    public sealed class Configuration : DbMigrationsConfiguration<And.ElkomMuhasebe.Core.Model.AndDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
     //SetSqlGenerator("MySql.Data.MySqlClient", new
     //
     //.MySqlMigrationSqlGenerator());

        }
       
        public void ManualSeed(AndDB context)
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AndDB, Configuration>());

            Seed(context);

            var dbMigrator = new DbMigrator(new Configuration());

            dbMigrator.Update();






            context.SaveChanges();
        }


        protected override void Seed(And.ElkomMuhasebe.Core.Model.AndDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
