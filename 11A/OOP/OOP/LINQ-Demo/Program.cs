// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var people = new List<Person>
{
    new Person("Johnatan",17,Town.Shumen,4345,true),
    new Person("Anelia",19,Town.Turgovishte,6675),
    new Person("Azis",44,Town.Smiadovo,7731,true),
    new Person("Evil Twin Of Azis",44,Town.Smiadovo,8864,false),
    new Person("Fiki",27,Town.Shumen,3125,true),
    new Person("Galena",44,Town.Turgovishte,7643,false),
    new Person("Rumiana",30,Town.Razgrad,5163),
    new Person("Nikoleta Lozanova",29,Town.Razgrad,6969,false),
    new Person("Toni",52,Town.Shumen,8878,true),
    new Person("Eminem",50,Town.Shumen,4345,true),
    new Person("Slavi Trifonov",52,Town.Smiadovo,9853,true),
    new Person("Slim Shady",50,Town.Turgovishte,7890,true),
};


var a = default(Person);

var count = people.Count();
Console.WriteLine(count);

string[] names = people.Select(p => p.Name).ToArray();
int[] ages = people.Select(p => p.Age).ToArray();

string[] nameAges = people
  //.OrderBy(x=>x.Gender)
    .OrderByDescending(p=>p.Age)
    .ThenBy(x=>x.Name.Length)
    .Select(p => $"{p.Name}. {p.Age} years old.")
    .Skip(2)
    .Take(5)
    .ToArray();

Person[] shumenci = people.Where(p => p.Town == Town.Shumen)
    .OrderByDescending(p=>p.Age)
    .ToArray();



people.Add(new Person("Veselin Marinov", 50, Town.Smiadovo, 7765, true));


Console.WriteLine(string.Join("\n", shumenci.Select(x => $"{x.Name}. {x.ID}")));


//Console.WriteLine(string.Join("\n",names));
//Console.WriteLine(string.Join("\n",ages));
Console.WriteLine(string.Join("\n",nameAges));







public class Person
{
    public Person()
    {

    }
    public Person(string name, int age,  Town town, int iD, bool gender=false)
    {
        Name = name;
        Age = age;
        Town = town;
        ID = iD;
        Gender = gender;
    }

    public int Age { get; set; }
    public string Name { get; set; }
    public Town Town { get; set; }
    public int ID { get; set; }
    public bool Gender { get; set; }
}

public enum Town
{
    Shumen,
    Razgrad,
    Turgovishte,
    Smiadovo
}