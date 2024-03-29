﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Animals.Models.BaseStuff;

namespace Animals.Models
{
    public class FuelCar : CarModel, ITravelable
    {
        private double tankCapacity;

        public FuelCar()
        {        }

        public FuelCar(string? model, int startYearOfModel, double maxSpeedKmPh, double weight, double loadCappacity) : base(model, startYearOfModel, maxSpeedKmPh, weight, loadCappacity)
        {
            Tank = new Tank();
            Console.WriteLine(DateTime.UtcNow);
        }
        public FuelCar(string? model, int startYearOfModel, double maxSpeedKmPh, double weight, double loadCappacity, Tank tank) : this(model, startYearOfModel, maxSpeedKmPh, weight, loadCappacity)
        {
            Tank = tank;             
        }
        public double TravelDistanceKoef { get; set; } = 10;
        public double MaxTravelDistance
        {
            get;set;
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
        public int TankId { get; set; }
        public virtual Tank Tank { get; set; }
    }
}
