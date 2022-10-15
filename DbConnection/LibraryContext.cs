using api_c2c.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace api_c2c.DbConnection
{
    public class LibraryContext : DbContext 
    {
        #region Entidades
        public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<ItemFamily> ItemFamilies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string server = ConfigurationSettings.AppSettings["server"];
            string user = ConfigurationSettings.AppSettings["user"];
            string database = ConfigurationSettings.AppSettings["database"];
            string password = ConfigurationSettings.AppSettings["password"];

            optionsBuilder.UseMySQL("server="+server+ ";database="+ database + ";user="+user+";password="+password+"");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Roles>().HasIndex(b => b.name).IsUnique();
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(b => b.email).IsUnique();
                entity.HasIndex(b => b.nit).IsUnique();
                entity.HasIndex(b => b.username).IsUnique();
                entity.HasIndex(b => b.email).IsUnique();
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.HasOne(d => d.order)
                .WithMany(p => p.OrderDetails);
            });

            //modelBuilder.Entity<Publisher>(entity =>
            //{
            //    entity.HasKey(e => e.ID);
            //    entity.Property(e => e.Name).IsRequired();
            //});

            //modelBuilder.Entity<Book>(entity =>
            //{
            //    entity.HasKey(e => e.ISBN);
            //    entity.Property(e => e.Title).IsRequired();
            //    entity.HasOne(d => d.Publisher)
            //    .WithMany(p => p.Books);
            //});

            //modelBuilder.Entity<Users>();

            //modelBuilder.Entity<Products>(entity =>
            //{
            //    entity.HasKey(e => e.id);
            //    entity.HasOne(d => d.itemFamily);
            //});
        }
    }
}
