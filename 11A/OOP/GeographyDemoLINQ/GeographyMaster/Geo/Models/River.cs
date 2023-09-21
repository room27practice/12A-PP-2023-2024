using System;
using System.Collections.Generic;

#nullable disable

namespace Geo.Models
{
    public partial class River
    {
        public River()
        {
            CountriesRivers = new HashSet<CountriesRiver>();
        }

        public River(string riverName, int length, int drainageArea, int averageDischarge, string outflow)
        {
            RiverName = riverName;
            Length = length;
            DrainageArea = drainageArea;
            AverageDischarge = averageDischarge;
            Outflow = outflow;
        }

        public int Id { get; set; }
        public string RiverName { get; set; }
        public int Length { get; set; }
        public int DrainageArea { get; set; }
        public int AverageDischarge { get; set; }
        public string Outflow { get; set; }

        public virtual ICollection<CountriesRiver> CountriesRivers { get; set; }

        public override string ToString()
        {
            return $"{RiverName}. Length {Length} km. Outflow: {Outflow}";
        }

    }
}
