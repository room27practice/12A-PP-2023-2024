namespace Uprajnenie_s_Poleta_i_svoistva
{
    public class Town
    {
        public Town(int id, string name, int population, string postCode)
        {
            Id = id;
            Name = name;
            Population = population;
            PostCode = postCode;
        }


        public Town(int id, string name, int population, string postCode, Country country)
        {
            Id = id;
            Name = name;
            Population = population;
            PostCode = postCode;
            Country = country;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string PostCode { get; set; }
        public Country Country { get; set; }
        public Town Region { get; set; }
    }
}
