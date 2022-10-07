// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

PlaceOrder(14);
PlaceOrder(14, false);
PlaceOrder(14, false, 3);
PlaceOrder(14, true, 3);

PlaceOrder(forksNumber: 10, mealId: 15);
var data = new int[] { 5, 6, 6 }; 
PlaceMultipleOrders( mealIds:data);
PlaceMultipleOrders(data);
PlaceMultipleOrders( 5,6,6);


static void PlaceOrder(int mealId, bool hasSalt = true, int forksNumber = 1)
{


}


static void PlaceMultipleOrders(params int[] mealIds)
{}



public class Test
{
    static void TestSomething()
    {
        DoSomething(b:1);
    }

static void DoSomething(int a) { }

static void DoSomething(params int[] b) { }

}