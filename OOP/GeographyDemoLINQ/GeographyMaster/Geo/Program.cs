using Geo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geo
{
    internal class Program
    {
        static void Main()
        {

            using (var db = new GeographyDBContext())
            {
                #region AddingNewRiver
                //Country countryFd = db.Countries.FirstOrDefault(x => x.CountryCode == "BG");
                //River newRiver = new River("Lom", 92500, 1240, 739, "Black Sea");

                //var newRiverCountry = new CountriesRiver()
                //{
                //    River = newRiver
                //};

                //countryFd.CountriesRivers.Add(newRiverCountry);

                ////countryFd.Rivers
                ////    .Add(newRiver);
                //db.SaveChanges();
                #endregion

                var riverNames = db.Rivers
                    .Where(r => r.CountriesRivers.Any(c => c.CountryCode == "BG"))
                    .Select(r => r.RiverName).Distinct()
                    .ToArray();

                List<River> approvedRivers = new List<River>();
                foreach (var rName in riverNames)
                {
                    approvedRivers
                        .Add(db.Rivers.FirstOrDefault(r => r.RiverName == rName));
                }

                var countryFound = db.Countries
                    .Include(x => x.CountriesRivers)
                    .ThenInclude(x => x.River)
                    .First(x => x.CountryName == "Bulgaria");

                countryFound.CountriesRivers = countryFound.CountriesRivers
                    .Where(x => approvedRivers.Contains(x.River)).ToList();

                db.SaveChanges();

                //var countryFound = db.Countries
                //    .Include(x => x.CountriesRivers)
                //    .ThenInclude(x => x.River)
                //    .First(x => x.CountryName == "China");

                //var riverNames2 = countryFound.CountriesRivers
                //    .OrderBy(r => r.River.Length)
                //    .Select(x => $"{x.River.RiverName}: {x.River.Length}km")
                //    .ToArray();


               // Console.WriteLine(String.Join("\n", riverNames));
                //Console.WriteLine(new String('=', 20));
                //Console.WriteLine(String.Join("\n", riverNames2));






            }





        }
    }
}
