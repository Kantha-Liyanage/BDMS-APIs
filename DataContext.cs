using BDMS_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace BDMS_APIs
{
    public class DataContext : DbContext
    {
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }

        //Constructor with DbContextOptions and the context class itself
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=bms.c3jqmjuhy912.us-east-1.rds.amazonaws.com; database=BDMS; user=admin; password=BloodDonation2022");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Donor>();
            modelBuilder.Entity<Hospital>();
        }
    }
}

