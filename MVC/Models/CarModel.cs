using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public abstract class CarModel
    {
        protected CarModel(string? model, int startYearOfModel, double maxSpeedKmPh, double weight, double loadCappacity)
        {
            Model = model;
            StartYearOfModel = startYearOfModel;
            MaxSpeedKmPh = maxSpeedKmPh;
            Weight = weight;
            LoadCappacity = loadCappacity;
        }

        public string? Model { get; } = "Mustang";
        public int StartYearOfModel { get; }
        public double MaxSpeedKmPh { get; }
        public double Weight { get; }
        public double LoadCappacity { get; }

        public double GetHoursForTravel(double distance)
        {
            double hours = distance / (double)MaxSpeedKmPh;
            return hours;
        }
    }
}
