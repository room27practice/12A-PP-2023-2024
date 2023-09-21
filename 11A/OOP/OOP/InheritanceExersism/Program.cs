class Program
{
    static void Main()
    {

        //var p1 = new Person("Kostadin", 5);
        //var p2 = new Child("Kostadin", 20);

        //p2.Age = 20;

        ////  var p2 = new Person("Konstantin", -5);
        //p1.Age = 15;
        //p1.Age = -15;
        while (true)
        {

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            try
            {
                Person ch1 = new Child(name, age);
                Person ch2 = new Employee(name,age);


                Console.WriteLine(ch1);
                Console.WriteLine("Success!!! " + ch1.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Console.WriteLine("Failure!");
            }

        }

    }
}




public class Child : Person
{
    public Child(string name, int age) : base(name, age)
    { }

    public override sealed int Age
    {
        get => base.Age; set
        {
            if (value > 15)
            {
                throw new ArgumentException("Age of child must be below 15 years");
            }

            base.Age = value;
        }
    }

    public override string ToString()
    {
        return "I am a kiddo";
    }



}


public abstract class Person
{
    private int age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public virtual int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            this.age = value;
        }

    }

    public override  string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}.I am person.";
    }

}




