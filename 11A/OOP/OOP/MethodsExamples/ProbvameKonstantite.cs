namespace MethodsExamples
{
    internal class ProbvameKonstantite
    {
        #region OtherStuff
        private int precision; //поле
        private const int PRECISION = 5; //константа

        public ProbvameKonstantite()
        {
            precision = 3;
        }

        public ProbvameKonstantite(string name):this()
        {
            Name = name;
        }

        public string Name { get; set; }
        #endregion
        public void DoSomething()
        {
            var veg1 = new Vegetable(150,"Pomelo");
        }

        private class Vegetable 
        {
            public Vegetable(int calories, string name)
            {
                Calories = calories;
                Name = name;
            }

            public int Calories { get; set; }
            public string Name { get; set; }
        }

    }
}
