namespace CoreAdmChamepe.Models.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class CoreAdmChamepeDbEntities : DbContext
    {
        public CoreAdmChamepeDbEntities()
            : base("name=CoreAdmChamepeDbEntities")
        {
            Database.SetInitializer<CoreAdmChamepeDbEntities>((IDatabaseInitializer<CoreAdmChamepeDbEntities>)null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<Evento> Eventoes { get; set; }
        public virtual DbSet<Igreja> Igrejas { get; set; }
        public virtual DbSet<ParticipanteEvento> ParticipanteEventoes { get; set; }
    }
}
