using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Batery
    {
        public int Id { get; set; }

        //ТОDO MAKE UNIQUE  
     //   public int ElectricCarId { get; set; }
        public virtual ElectricCar ElectricCar { get; set; }

        public double MaxCapacity { get; set; }
        public double RemainingCapacity { get; set; }
        public string Type { get; set; }
        public int LifeCycles { get; set; } = 100000;
        public Batery()
        {

            MaxCapacity = 50;
            RemainingCapacity = 50;
            Type = "Lithium-ion";
        }
        public Batery(double MaxCapacity, string Type)
        {
            RemainingCapacity = MaxCapacity;
            this.Type = Type;
        }
        public void Recharge() { RemainingCapacity = MaxCapacity; LifeCycles -= 1; if (LifeCycles == 0) { RemainingCapacity = 0; } }
    }
}
