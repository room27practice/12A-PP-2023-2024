using Animals.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Animals.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<FuelCar> FuelCars { get; set; }
        public DbSet<Tank> Tanks { get; set; }

        public DbSet<ElectricCar> ElectricCars { get; set; }
        public DbSet<Batery> Batteries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tank>().HasOne(x => x.FuelCar).WithOne(c => c.Tank)
                .HasForeignKey<FuelCar>(fc=>fc.TankId);
          
            builder.Entity<Batery>().HasOne(x => x.ElectricCar).WithOne(c => c.Battery)
                 .HasForeignKey<ElectricCar>(ec => ec.BateryId);
            base.OnModelCreating(builder);
        }
    }
}