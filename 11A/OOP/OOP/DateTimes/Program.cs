using System.Globalization;

namespace DateTimes
{

    static class GlobalConstants
    {
        public static string TimeFormat1 = "MM-dd/yyyy HH:mm:ss";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           string time1 = "02-23/2022 13:58:24";//




            string[] times = {
                "02-23/2022 13:58:24",
                "03-07/2014 04:23:30",
                "12-24/1999 11:48:05",
                "09-15/2001 08:00:01",
                "12-12/2030 12:12:21",
            };

            var deadLine = DateTime.UtcNow;
            deadLine.AddMonths(3);
            if (DateTime.UtcNow<=deadLine)
            {
                Console.WriteLine("Is premium active");
            }
            else
            {
                Console.WriteLine("Premium membership has expired");
            }

            int timeZoneShift = (DateTime.Now - DateTime.UtcNow).Hours;

            var defaultDateTime = new DateTime();

            var date1 = DateTime.ParseExact("02-23/2022 13:58:24",GlobalConstants.TimeFormat1, CultureInfo.InvariantCulture);
            var date2 = DateTime.ParseExact("12-12/2030 12:12:21", GlobalConstants.TimeFormat1, CultureInfo.InvariantCulture);

            bool sravnenie = date1 > date2;
            bool obr_sravnenie = date1 < date2;

            TimeSpan razlika = date2 - date1;
            razlika.Add(new TimeSpan(5));

            
            DateTime[] dates = times.Select(t =>DateTime.ParseExact(t, GlobalConstants.TimeFormat1, CultureInfo.InvariantCulture)).ToArray();

            foreach (var data in dates)
            {
                //Console.WriteLine($"{data.Hour} : {data.Minute} - {data.Second}s");

                Console.WriteLine(data.ToString("H:m:s [MMM] - ddd"));
            }


            Console.WriteLine(date1.Year);
            //"2-23-2022" "23-2-2022" "02 23 2022"  "02/23/2022"   "Feb/23/2022"
            //

            Console.WriteLine("Hello, World!");
        }
    }
}