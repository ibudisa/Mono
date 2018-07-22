namespace Service
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VehicleContext : DbContext
    {
        public VehicleContext()
            : base("name=VehicleContext")
        {
        }

        public virtual DbSet<VehicleMake> VehicleMakes { get; set; }
        public virtual DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleMake>()
                .Property(e => e.Abrv)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleMake>()
                .HasMany(e => e.VehicleModels)
                .WithOptional(e => e.VehicleMake)
                .HasForeignKey(e => e.MakeId);

            modelBuilder.Entity<VehicleModel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleModel>()
                .Property(e => e.Abrv)
                .IsUnicode(false);
        }
    }
}
