using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExtensionClass
{
    public static class SwissKnife
    {
        public static int SumOfNumbersAndAge(this Person p, int num1, int num2)
        {
            Console.WriteLine("Extension Method was started for " + p.Name);

            return num1 + num2 + p.Age;
        }

        public static double? ToDouble(this string str)// [t4324,2S => 4@3^24Щ.2
        {
            string allowedSymbols = "1234567890.";
            bool isMinusValue = str.StartsWith("-");
            string bulletProofString = string.Join("", str.Replace(",", ".").Replace(" ", "")
                .Where(x => allowedSymbols.Contains(x)));
            try
            {
                var result = double.Parse(bulletProofString);
                return isMinusValue ? -result : result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid Number Given {ex.Message}");
                return null;
            }
        }

        public static ICollection<T> GetEvens<T>(this ICollection<T> list)
        {
            var result = new List<T>();

            for (int i = 0; i < list.Count; i += 2)
            {
                result.Add(list.ToArray()[i]);
            }
            return result;
        }

        public static T To<T>(this string str)=>
                     (T)Convert.ChangeType(str, typeof(T));



        public static IEnumerable<B> MySelect<T,B>(this ICollection<T> input,Func<T,B> func)
        {
            foreach (var item in input)
            {
                yield return func(item);
            }
        }
        
    }
}