// See https://aka.ms/new-console-template for more information
using ModifiedCollections;


var test1 = new SuperList("Asen","za hartia");

test1.Add("alabala");
test1.Add("portokala");
test1.Add("ole ole");
test1.Add("eha");
test1.Add("super");

Console.WriteLine(test1[1]);
Console.WriteLine(test1.Designation);

Console.WriteLine(string.Join("; ", test1.GetOddIndexThings()));//алабала оле оле супер

