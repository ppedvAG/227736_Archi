using Microsoft.EntityFrameworkCore;
using ppedv.KurvenkönigsKarren.Model;

namespace ppedv.KurvenkönigsKarren.Data.Database
{
    public class EfContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Rent> Rents { get; set; }

        readonly string conString;

        public EfContext(string conString)
        {
            this.conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(x => x.Color).HasColumnName("Farbe").HasMaxLength(95);

            modelBuilder.Entity<Rent>().HasOne(x => x.Driver).WithMany(x => x.RentsAsDriver);
            modelBuilder.Entity<Customer>().HasMany(x => x.RentsAsPayer).WithOne(x => x.Payer);
        }

    }
}