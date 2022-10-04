using System;
using System.Linq;

namespace Uprajnenie_s_Poleta_i_svoistva
{
    public class Country
    {
        private string designation;
        public int Id { get; set; }
        public string Name { get; set; }
        public double PopulationInMilions { get; set; }
        public string Designation
        {
            get
            {
                return designation;
            }

            set
            {
                bool lenghtTooMuch = value.Length > 2;
                bool nonLettersUsed = value.Any(x => !Char.IsLetter(x));
                if (lenghtTooMuch)
                {
                    Console.WriteLine("Incorrect Data. Designation must be exactly 2 symbols long!");
                }
                if (nonLettersUsed)
                {
                    Console.WriteLine("Incorrect Data. Only letters must be used!");
                }
                if (!lenghtTooMuch && !nonLettersUsed)
                {
                    designation = value.ToUpper();
                }
            }
        }
        public string ContinentName { get; set; }
        public string Languages { get; set; }
        public string Description { get; set; }




    }
}
