using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Concretes.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<GearType> GearTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<RentDetail> RentDetails { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8,0,27));
            optionsBuilder.UseMySql("server=localhost;database=car_rental_db;user=root;password=123456789",serverVersion);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Car>().HasQueryFilter(p => p.Deleted == false);
            modelBuilder.Entity<Brand>().HasQueryFilter(b => b.IsDeleted == false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
