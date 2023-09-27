using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_DataAnotation_FluentAPI
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
            Database.EnsureDeleted();
        }

        public DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("server=.;database=TestDB;Trusted_Connection=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Ignore<Company>();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planshet>();
            modelBuilder.Ignore<Company>();
        }
    }

    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }


        //Navigate property
        public Company Manufacture { get; set; }

    }

    //[NotMapped]
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Planshet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
