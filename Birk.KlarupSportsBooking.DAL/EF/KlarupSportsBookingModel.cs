namespace Birk.KlarupSportsBooking.DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KlarupSportsBookingModel : DbContext
    {
        public KlarupSportsBookingModel()
            : base("name=KlarupSportsBookingModelConfig")
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Fixed> Fixeds { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<UnionLeader> UnionLeaders { get; set; }
        public virtual DbSet<Union> Unions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.UnionLeaders)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Unions)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Fixeds)
                .WithRequired(e => e.Reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Union>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Union)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Union>()
                .HasMany(e => e.UnionLeaders)
                .WithRequired(e => e.Union)
                .WillCascadeOnDelete(false);
        }
    }
}
