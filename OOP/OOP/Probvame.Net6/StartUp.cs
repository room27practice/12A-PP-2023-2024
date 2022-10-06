// See https://aka.ms/new-console-template for more information
using Probvame.Net6;

Uprajnenie.Animal.Test();


Console.WriteLine("Hello, World!");

int result = Sum(45, 10);
Console.WriteLine(result);
var car1 = new Car();
car1.StartEngine();
Car.Sum('S', 8);
Car.Sum(6, 8);
car1.Sum(3, 4, 6);

Car car2 = new Car();
Console.WriteLine(car2.Color);

var car3 = new Car();
var car4 = new Car("Magenta");
var car5 = new Car(1350, "Orange");

Animal.Step=2;
Animal animal1 = new Animal("Asen",10);
Animal animal2 = new Animal("Koko");

Animal.Reseed();
Animal.Step = 1;
Animal animal3 = new Animal();
Animal animal4 = new Animal();
Animal animal5 = new Animal();



Console.ReadLine();

static int Sum(int num1,int num2)
{
    return num1+num2;
}