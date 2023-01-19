using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class FuelCarData : CarModel, ITravelable
    {
        private double tankCapacity;

        public FuelCarData(string? model, int startYearOfModel, double maxSpeedKmPh, double weight, double loadCappacity) : base(model, startYearOfModel, maxSpeedKmPh, weight, loadCappacity)
        {
            Tank = new Tank();
            Console.WriteLine(DateTime.UtcNow);
        }
        public FuelCarData(string? model, int startYearOfModel, double maxSpeedKmPh, double weight, double loadCappacity, Tank tank) : this(model, startYearOfModel, maxSpeedKmPh, weight, loadCappacity)
        {
            Tank = tank;             
        }
        private Tank Tank { get; set; }
        public double TravelDistanceKoef { get; protected set; } = 10;
        public double MaxTravelDistance
        {
            get { return tankCapacity; }
            set
            {
                value = Tank.MaxCapacity * TravelDistanceKoef;
                tankCapacity = value;
            }
        }

        public void Recharge() { Tank.RemainingCapacity = Tank.MaxCapacity; }
       
        public TravelInfo Travel(double distance)
        {
            double remainingCapacity = distance / TravelDistanceKoef;
            if (distance < MaxTravelDistance)
            {
                if (remainingCapacity > Tank.RemainingCapacity)
                {
                    return new TravelInfo(GetHoursForTravel(distance), distance, Model!);
                }
                else
                {
                    Console.WriteLine("Recharge needed...");
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
