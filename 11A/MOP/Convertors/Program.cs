using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Convertors
{
    internal class Program
    {
        static void Main(string[] args)
        {



            // NumericalConvertor.Greeting();

            // string result = NumericalConvertor.FromIntToBinary(int.MinValue);
            //  Console.WriteLine(result);

            //  Console.WriteLine(Convert.ToString(17878, 2));
            // Console.WriteLine(NumericalConvertor.FromHexToDecimal("FFF43Fa"));


            Console.WriteLine(ConvertWordsToBinary("Hello world"));
        }

        public static string ConvertWordsToBinary(string sentence)
        {
            List<string> results = new List<string>();
            foreach (char character in sentence)
            {
                results.Add(NumericalConvertor.FromIntToBinary(character));
            }

            return string.Join(" ", results.Select(num =>
            {
                if (num.Length < 8)
                {
                    return new string('0', 8 - num.Length) + num;
                }
                return num;
            }));
        }

    }

    public static class NumericalConvertor
    {
        public static int FromBinaryToInt(string binaryNum)
        {
            //"10101010101010101010101" 
            var binaryArr = binaryNum.ToCharArray();

            int _base = 1;
            int _value = 0;
            for (int i = binaryNum.Length - 1; i >= 0; i--)
            {
                _value += (binaryNum[i] - '0') * _base;
                _base *= 2;
            }
            return _value;
        }

        public static string FromIntToBinary(int num)
        {
            List<int> binaryList = new List<int>();
            while (num != 0)
            {
                binaryList.Add((num % 2));
                num /= 2;
            }

            binaryList.Reverse();
            var result = string.Join("", binaryList);
            return result;
        }


        public static long FromHexToDecimal(string hex)
        {
            //21fA ->=10*16^0 + 15*16^1 + 1*16^2 + 2*16^3= 8698
            //0123456789ABCDEF [osnova=16]
            hex = hex.ToUpper();
            var arr = hex.ToCharArray();
            Array.Reverse(arr);
            string reversedHex = new string(arr);
            long baseOnPower = 1;
            long result = 0;
            for (int i = 0; i < reversedHex.Length; i++)
            {
                char current = reversedHex[i]; //0-9 A-F
                int value = char.IsDigit(current) ? current - '0' : 10 + current - 'A';
                result += value * baseOnPower;
                baseOnPower *= 16;
            }
            return result;
        }

        public static void Greeting()
        {
            Console.WriteLine("Hello gospodin Hristov.");//-darkmagic
        }
    }


}