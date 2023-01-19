using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models.BaseStuff
{
    public class TravelInfo
    {

        public double TravelTime { get; set; }
        public double Distance { get; protected set; }
        public string ModelCar { get; protected set; }

        public TravelInfo(double TravelTime, double Distance, string ModelCar)
        {
            this.TravelTime = TravelTime;
            this.Distance = Distance;
            this.ModelCar = ModelCar;
        }

        public override string ToString()
        {
            return $"{ModelCar}, traveled {Distance} km, for {TravelTime} hours";
        }
    }
}
