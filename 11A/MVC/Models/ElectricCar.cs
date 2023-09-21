using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Animals.Models.BaseStuff;

namespace Animals.Models
{
    public class ElectricCar : CarModel, ITravelable
    {
        private double capacity;

        public ElectricCar()
        {

        }

        public ElectricCar(string? model, int startYearOfModel, double maxSpeedKmPh, double weight, double loadCappacity, Batery battery = null) : base(model, startYearOfModel, maxSpeedKmPh, weight, loadCappacity)
        {
            if (battery == null)
            {
                Battery = new Batery();
            }
            else
            {
                Battery = battery;
            }
        }
        public int BateryId { get; set; }
        public virtual Batery Battery { get; set; }
        public double TravelDistanceKoef { get;  set; } = 120;
        public double MaxTravelDistance
        {
            get { return capacity; }
            set { value = TravelDistanceKoef * Battery.MaxCapacity; capacity = value; }
        }


        public void Recharge()
        {
            Battery.RemainingCapacity = Battery.MaxCapacity;
        }

        public TravelInfo Travel(double distance)
        {
            double remainingCapacity = distance / TravelDistanceKoef;
            if (distance < MaxTravelDistance)
            {
                if (remainingCapacity > Battery.RemainingCapacity)
                {
                    return new TravelInfo(GetHoursForTravel(distance), distance, Model!);
                }
                else
                {
                    Console.WriteLine("Recharge needed..." + null);
                    return new TravelInfo(GetHoursForTravel(distance), distance, Model!);
                }
            }
            else
            {
                throw new ApplicationException("ImpossibleTravel!");
            }
        }
    }
}
