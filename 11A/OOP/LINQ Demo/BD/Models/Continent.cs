﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BD.Models
{
    public partial class Continent
    {
        public Continent()
        {
            Countries = new HashSet<Country>();
        }

        public string ContinentCode { get; set; }
        public string ContinentName { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
