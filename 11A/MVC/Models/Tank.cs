﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Tank
    {
        public int Id { get; set; }
       
        //ТОDO MAKE UNIQUE  
    //    public int FuelCarId { get; set; }
        public virtual FuelCar FuelCar { get; set; }

        public double MaxCapacity { get; set; }
        public double RemainingCapacity { get; set; } = 10;
        public string Type { get; protected set; }

        public Tank()
        {
            MaxCapacity = 50;
            RemainingCapacity = 50;
            Type = "Benzine";
        }
        public Tank(double MaxCapacity, string Type)
        {
            RemainingCapacity = MaxCapacity;
            this.Type = Type;
        }
    }
}
