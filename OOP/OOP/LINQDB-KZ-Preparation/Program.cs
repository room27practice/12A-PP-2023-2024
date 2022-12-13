using LINQDB_KZ_Preparation.Contracts;
using LINQDB_KZ_Preparation.Models;
using LINQDB_KZ_Preparation.Services;

namespace LINQDB_KZ_Preparation
{
    public class TestClass
    {
        public TestClass(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public string AutoNameAge => $"{Age} {Name} {Age}";

        public int Age { get; set; }
        public string Name { get; set; }


        public string GetNameAndAge()
        {
            return $"{Name} {Age}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
          
            
            IDBMaster db = new DBMaster();

            var test = new TestClass(24, "Genadi");
             // TestAutoPropertiesDemo(db, test);
            //  DemoStuff(db);


            Application(db);

        }

        private static void TestAutoPropertiesDemo(IDBMaster db, TestClass test)
        {
            Console.WriteLine(test.AutoNameAge);



            List<Employee> emps = db.GetAll<Employee>();
            List<Project> projs = db.GetAll<Project>();
        }

        private static void Application(IDBMaster db)
        {
            Dictionary<int, string> departaments = db.GetDepatamentsNames();

        nachalo:
            Console.WriteLine("Vsichki departamenti:");
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("[" + string.Join("]\n[", departaments.Select(x => $"{x.Key} {x.Value}")) + "]");
            Console.WriteLine(new string('=', 20));

            int chosenDepartment = 0;//3
            while (true)
            {
                Console.Write("Izberi departament: ");
                try
                {
                    chosenDepartment = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Input - Error Brutal Fatal.");
                    continue;
                }
                if (departaments.ContainsKey(chosenDepartment))
                {
                    Console.WriteLine($"Chosen Department {departaments[chosenDepartment]}");
                    break;
                }
                else
                {
                    Console.WriteLine("Id Not Recognised.");
                }
            }

            PersonDataMiniDTO[] employeesInDepartment = db.GetAllEmpsFromDepartment(chosenDepartment);

            Console.WriteLine(new string('=', 20));
            Console.WriteLine("All Employess:");
            Console.WriteLine(new string('=', 40));
            foreach (var emp in employeesInDepartment)
            {
                Console.WriteLine(emp);
            }
            goto nachalo;
        }

        private static void DemoStuff(IDBMaster db)
        {
            Console.WriteLine("Hello, World!");

            List<Project> projects = db.GetAllProjects();

            Employee employee = db.GetEmployeeById(5);

            var allAddressesOfEmpsWithUnfinishedBusiness = db.GetAddressesOfEmployeesWithUnfinishedProjects();


            List<Project> projectsAfterDate = db.GetProjectsStartedAfterDate(new DateTime(2003, 1, 6));

            foreach (var item in projects)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}