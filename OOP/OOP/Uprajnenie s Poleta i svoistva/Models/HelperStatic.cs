namespace Uprajnenie_s_Poleta_i_svoistva
{
    public static class HelperStatic
    {
        private static int timesUsed = 5;
  
        public static double MakeDoubled(string str)
        {
            timesUsed--;
            if (timesUsed < 0)
            {
                throw new System.InvalidOperationException("Svurshiha operaciite koito se dopuskat");
            }
            return double.Parse(str);
        }
    }
}
