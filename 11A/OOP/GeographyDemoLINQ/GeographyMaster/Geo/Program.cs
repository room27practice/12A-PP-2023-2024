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
                // Country countryFd = db.Countries.FirstOrDefault(x => x.CountryCode == "BG");
                // River newRiver = new River("Lom", 92500, 1240, 739, "Black Sea");
                //  RegisterNewRiver(db, countryFd, newRiver);
                #endregion

                //  PrintDataAboutCountry(db);
                //  DeleteAllDuplicatingRivers(db,"BG");

                  DBMaster.PrintOrderedRiversDataAboutCountry(db, "RU");


                //Напишете метод които да извади списък с планините имащи най-високи върхове
                //Mountain[]
                DBMaster.PrintHighestMountains(db, 10);

                var mountains = db.Mountains
                    .Where(m => m.Peaks.Any())

                    .Where(m => !m.Peaks.Any(p => p.PeakName.StartsWith("E")))
                    .OrderByDescending(m => m.Peaks.Max(p => p.Elevation))
                    .Select(m => new MiniMountainDTO()
                    {
                        MountainName = m.MountainRange == "Karakorum" ? "KARAKORUM" : m.MountainRange,
                        PeakHeight = m.Peaks.OrderByDescending(p => p.Elevation).First().Elevation,
                        PeakName = m.Peaks.OrderByDescending(p => p.Elevation).First().PeakName,
                    })
                    .Take(5)
                    .ToArray();





            }
        }








  
    }
}
