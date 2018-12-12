using Data.Entidades;
using SQLite.CodeFirst;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

namespace Data.EF
{
    public class Context : DbContext
    {

        //public Context() : base(new SQLiteConnection() {
        //    ConnectionString = new SQLiteConnectionStringBuilder()
        //    {
        //        
        //        DateTimeFormat = SQLiteDateFormats.ISO8601,
        //        SyncMode = SynchronizationModes.Off,
        //        Version = 3,
        //        JournalMode = SQLiteJournalModeEnum.Truncate,
        //        DefaultIsolationLevel = System.Data.IsolationLevel.ReadCommitted,
        //        Pooling = true,
        //        Uri = new Uri(@"file:data.db").AbsoluteUri
        //    }.ConnectionString
        //},true)
        //{
        //    //Database.SetInitializer(new DbInitializer());
        //    //this.Configuration.LazyLoadingEnabled = true;
        //    //Database.SetInitializer<DbContext>(null);
        //}
        //

        public Context() : base("name=clinicaConn")
        {
            //Database.SetInitializer(new DbInitializer());
            //this.Configuration.LazyLoadingEnabled = true;
            //Database.SetInitializer<DbContext>(null);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<Context>(modelBuilder);
        //    //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    //base.OnModelCreating(modelBuilder);
        //
        //    Database.SetInitializer(sqliteConnectionInitializer);
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    Database.SetInitializer(new SQLite.CodeFirst.SqliteCreateDatabaseIfNotExists<Context>(modelBuilder));
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new SQLite.CodeFirst.SqliteCreateDatabaseIfNotExists<Context>(modelBuilder));
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
    }
}
