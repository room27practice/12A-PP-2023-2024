using System;

namespace Error_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoSomething(6);


            int attempt = 0;
            while (true)
            {
                attempt++;
                Console.WriteLine("Dai mi chislo: ");
                int a = 0;
                try
                {
                    a = int.Parse(Console.ReadLine());
                    Console.WriteLine("Congratulations number is " + a);
                    break;
                }
                catch (OverflowException ove)
                {
                    Console.WriteLine("Vuvedi chislo v intervala -2^32 do +2^32!");
                    throw ove;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Nedei pisa simvoli osven chisla i tochki!");
                }
                catch (ArgumentNullException ae)
                {
                    Console.WriteLine("Ne moje NULL !!!");
                }
                finally
                {
                    Console.WriteLine($"Opit N{attempt}");
                }

            }



            try
            {
                // TestMethod();

            }
            catch (ArgumentNullException ex)
            {

            }
            finally
            {
                Console.WriteLine("Dovijdane");
            }
            //catch (InvalidProgramException ex)
            //{
            //    Console.WriteLine("Hvanah greshkata " +ex.Message);
            //    throw ex.InnerException;
            //}
            //catch (ArgumentException)
            //{
            //    Console.WriteLine("Neshto drugo");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Greshkata e nqkakva mnogo obshta ne znaem kakva e no q hvashtame");
            //}

            Console.WriteLine("Produljavame programata");

            //  var a = int.Parse("alabala");

            SystemException ex2 = new AccessViolationException();
        }


        public static void TestMethod()
        {
            Console.WriteLine("dobro utro 1");
            IndexOutOfRangeException ex1 = new IndexOutOfRangeException("Vutreshna greshka");
            var e2 = new InvalidProgramException("Posledna greshka", ex1);
            //  throw e2;
            var test = new BattleException();
            throw new BattleException("Igrach 1 e murtuv puk uchastva v boq ne moje");
        }





        /// <summary>
        /// Това е моя любим метод които прави чудеса!
        /// </summary>
        /// <param name="num">num представлява моето число което съм избрал</param>
        public static void DoSomething(int num)
        {
        }
    }

    /// <summary>
    /// This is Exception that my BattleGame would trhow if something bad happens!!!
    /// </summary>
    public class BattleException : ApplicationException
    {
        public BattleException(string reason) : base(reason)
        { }
        public BattleException() : base()
        { }
        public BattleException(string reason, Exception ex) : base(reason, ex)
        { }

        public BattleException(string reason, string guiltyMember) : base(reason)
        {
            GuiltyMember = guiltyMember;
        }

        public string GuiltyMember { get; set; }


    }



}
