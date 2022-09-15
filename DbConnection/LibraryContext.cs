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
        public DbSet<Book> Book { get; set; }

        public DbSet<Publisher> Publisher { get; set; }


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

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.ISBN);
                entity.Property(e => e.Title).IsRequired();
                entity.HasOne(d => d.Publisher)
                .WithMany(p => p.Books);
            });

            modelBuilder.Entity<Users>();
        }
    }
}
