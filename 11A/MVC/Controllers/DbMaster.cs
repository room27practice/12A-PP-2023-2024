using Animals.Data;
using Animals.Models;
using Microsoft.EntityFrameworkCore;

namespace Animals.Controllers
{
    public class DbMaster
    {
        private readonly ApplicationDbContext db;

        public DbMaster(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<FuelCar> GetAllFuelCars()
        {
            return db.FuelCars.Include(c=>c.Tank).ToList();
        }
    }
}
