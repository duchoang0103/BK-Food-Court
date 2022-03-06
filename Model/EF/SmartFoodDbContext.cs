namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SmartFoodDbContext : DbContext
    {
        public SmartFoodDbContext()
            : base("name=SmartFoodDbContext")
        {
        }

        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<Cooker> Cooker { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserBank> UserBank { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .Property(e => e.BankName)
                .IsFixedLength();

            modelBuilder.Entity<Cooker>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Cooker>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserBank>()
                .Property(e => e.BankName)
                .IsFixedLength();

            modelBuilder.Entity<UserBank>()
                .Property(e => e.STK)
                .IsFixedLength();

            modelBuilder.Entity<UserBank>()
                .Property(e => e.Pass)
                .IsFixedLength();

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorAccount)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.VendorName)
                .IsUnicode(false);
        }
    }
}
