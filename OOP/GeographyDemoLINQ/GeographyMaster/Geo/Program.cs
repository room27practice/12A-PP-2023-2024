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

                //  PrintOrderedRiversDataAboutCountry(db, "RU");


                //Напишете метод които да извади списък с планините имащи най-високи върхове
                //Mountain[]
                PrintHighestMountains(db, 10);

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

        private static void PrintHighestMountains(GeographyDBContext db, int count = 5)
        {
            var highestMountains = db.Mountains
                .OrderByDescending(m => m.Peaks.Max(p => p.Elevation))
                .Include(m => m.Peaks)
                .Where(m => m.Peaks.Count() > 1)
                .Take(count)
                .ToArray();

            foreach (var m in highestMountains)
            {
                Peak highestPeak = m.Peaks.OrderByDescending(p => p.Elevation).First();
                Console.WriteLine("Mountain Name:" + m.MountainRange);
                Console.WriteLine($"Highest Peak: {highestPeak.PeakName}. Elevation {highestPeak.Elevation} m");
            }
        }

        private static void PrintOrderedRiversDataAboutCountry(GeographyDBContext db, string countryCode)
        {
            var countryFd = db.Countries
                .Include(x => x.CountriesRivers)
                .ThenInclude(x => x.River)
                .First(x => x.CountryCode == countryCode);

            var orderedRiversOfCountryFd = countryFd.CountriesRivers
                .OrderBy(r => r.River.Length)
                .Select(x => $"{x.River.RiverName}: {x.River.Length}km")
                .ToArray();


            Console.WriteLine(new String('=', 20));
            Console.WriteLine(String.Join("\n", orderedRiversOfCountryFd));
        }

        private static void DeleteAllDuplicatingRivers(GeographyDBContext db, string countryCode)
        {
            string[] riverNames = db.Rivers
                .Where(r => r.CountriesRivers.Any(c => c.CountryCode == countryCode))
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
                .First(x => x.CountryCode == countryCode);

            countryFound.CountriesRivers = countryFound.CountriesRivers
                .Where(x => approvedRivers.Contains(x.River)).ToList();

            db.SaveChanges();
        }

        private static void PrintDataAboutCountry(GeographyDBContext db)
        {
            Country countryFound = null;
            while (countryFound == null)
            {
                Console.WriteLine("Choose country to display:");
                Console.WriteLine("[CountryName] or [CountryId]"); //BG Bulgaria BULgaria
                string countryID = Console.ReadLine().ToLower();//bulgariaN134324234 //BG 

                countryFound = db.Countries
                    .Include(x => x.CountriesRivers)
                    .ThenInclude(x => x.River)

                    .Include(x => x.MountainsCountries)
                    .ThenInclude(x => x.Mountain)
                    .ThenInclude(x => x.Peaks)

                    .Include(x => x.MountainsCountries)
                    .ThenInclude(x => x.Mountain)
                    .ThenInclude(x => x.MountainsCountries)
                    .ThenInclude(x => x.CountryCodeNavigation)

                    .FirstOrDefault(
                    x => countryID.StartsWith(x.CountryName.ToLower())
                    || countryID.StartsWith(x.CountryCode.ToLower()));

            }

            PrintData(countryFound);
        }

        private static void RegisterNewRiver(GeographyDBContext db, Country countryFd, River newRiver)
        {
            var newRiverCountry = new CountriesRiver()
            {
                River = newRiver
            };

            countryFd.CountriesRivers.Add(newRiverCountry);
            //За .NET6
            //countryFd.Rivers
            //    .Add(newRiver);
            db.SaveChanges();
        }

        private static void PrintData(Country countryFound)
        {
            Console.WriteLine($"CountryFound: {countryFound.CountryName}");
            Console.WriteLine($"Area: {countryFound.AreaInSqKm} km2");
            Console.WriteLine($"Population: {countryFound.Population} km2");
            Console.WriteLine(new String('=', 30));
            Console.WriteLine($"Rivers: {countryFound.CountriesRivers.Count()}");
            foreach (River river in countryFound.CountriesRivers.Select(x => x.River).ToArray())
            {
                Console.WriteLine($"\t {river.ToString()}");
            }
            Console.WriteLine(new String('=', 30));
            Console.WriteLine($"Mountains: {countryFound.MountainsCountries.Count()}");
            foreach (Mountain mountain in countryFound.MountainsCountries.Select(x => x.Mountain).ToArray())
            {
                Console.WriteLine($"{mountain.MountainRange}. Countries: {string.Join("; ", mountain.MountainsCountries.Select(c => c.CountryCodeNavigation.CountryName))}");
                foreach (Peak p in mountain.Peaks.OrderByDescending(x => x.Elevation))
                {
                    Console.WriteLine(new String('=', 15));
                    Console.WriteLine($"\t {p.PeakName}. Elevation: {p.Elevation}");
                }
            }
        }
    }


    public class MiniMountainDTO
    {
        public MiniMountainDTO(int peakHeight, string peakName, string mountainName)
        {
            PeakHeight = peakHeight;
            PeakName = peakName;
            MountainName = mountainName;
        }
        public MiniMountainDTO()
        {

        }
        public int PeakHeight { get; set; }
        public string PeakName { get; set; }
        public string MountainName { get; set; }
    }
}
