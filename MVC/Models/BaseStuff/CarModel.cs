using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models.BaseStuff
{
    public abstract class CarModel
    {
        public int Id { get; set; }

        public CarModel()
        { }

        protected CarModel(string? model, int startYearOfModel, double maxSpeedKmPh, double weight, double loadCappacity)
        {
            Model = model;
            StartYearOfModel = startYearOfModel;
            MaxSpeedKmPh = maxSpeedKmPh;
            Weight = weight;
            LoadCappacity = loadCappacity;
        }

        public string? Model { get; set; }
        public int StartYearOfModel { get; set; }
        public double MaxSpeedKmPh { get; set; }
        public double Weight { get; set; }
        public double LoadCappacity { get; set; }

        public double GetHoursForTravel(double distance)
        {
            double hours = distance / (double)MaxSpeedKmPh;
            return hours;
        }
    }
}
