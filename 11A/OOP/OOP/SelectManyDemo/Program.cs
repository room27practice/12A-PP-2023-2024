namespace SelectManyDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PetOwner[] petOwners = 
                {
                
                new PetOwner { Name="Higa",
              Pets = new List<string>{ "Scruffy", "Sam" ,"Johny","Linkoln","Shaize","Vurst","Brunhilde","Dusty"} },
          new PetOwner { Name="Ashkenazi",
              Pets = new List<string>{ "Walker", "Sugar" } },
          new PetOwner { Name="Price",
              Pets = new List<string>{ "Scratches", "Diesel" } },
          new PetOwner { Name="Hines",
              Pets = new List<string>{ "Dusty" } } 
                       
            };

            string[] allPetNames = petOwners.SelectMany(p => p.Pets).Distinct().ToArray();
            
            string[] allOwnerNames = petOwners.Select(p => p.Name).ToArray();


            Console.WriteLine(string.Join(", ", allPetNames));
        }
    }

    internal class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }
}