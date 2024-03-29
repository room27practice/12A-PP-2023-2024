﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models.BaseStuff
{
    interface ITravelable
    {
        double MaxTravelDistance { get; protected set; }
        void Recharge();

        TravelInfo Travel(double distance);

        double MaxSpeedKmPh { get; }

    }
}
