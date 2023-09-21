using System;
using System.Collections.Generic;

#nullable disable

namespace BD.Models
{
    public partial class CountriesRiver
    {
        public int RiverId { get; set; }
        public string CountryCode { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual River River { get; set; }
    }
}
