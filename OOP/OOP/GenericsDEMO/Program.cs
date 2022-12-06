using System;

namespace GenericsDEMO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<Robokiller16>();
            var konteiner = new List<object>();

            konteiner.Add("zdravei");
            konteiner.Add(15.3d);
            konteiner.Add(7);
            konteiner.Add(new Robokiller16());



            var resultaaaa = new int();

            var primer2 = new MyClass<int, bool>();
            var primer3 = new MyClass<bool, char>();

            primer2.GenMethod<string>(new string[] { "ala", "bala" });
            primer2.GenMethod<int>(new int[] { 1, 2 });


            var robokiller = new Robokiller16();

            ICollection<object> result = robokiller.MakeCollection<object>("edin", 1, "tri", true);

            ICollection<int> resultNumbers = robokiller.MakeCollection(1, 8, 17);


            var mySuperDictionary = new MyDictionary<string, bool>();

            mySuperDictionary.Add("marin", false);
            mySuperDictionary.Add("samuil", false);
            mySuperDictionary.Add("miroslav", false);
            mySuperDictionary.Add("emir", true);


            bool hasElement = mySuperDictionary.ContainsKey("marin");
            bool hasElement2 = mySuperDictionary.ContainsKey("georgi");

        }


        public class Robokiller16 : IComparable<Robokiller16>
        {
            public Robokiller16()
            { }
            public Robokiller16(int p)
            { }

            public string Name { get; set; }


            public ICollection<B> MakeCollection<B>(params B[] elements)
            {
                return elements;
            }

            int IComparable<Robokiller16>.CompareTo(Robokiller16? other)
            {
                if (this.Name == other.Name)
                {
                    return 0;
                }
                else if (this.Name.Length > other.Name.Length)
                {
                    return +1;
                }
                else
                {
                    return -1;
                }
            }
        }

        class MyClass<T, S>

        //  where T : Robokiller16, IComparable<T>,IDisposable, new() 
        {
            public MyClass()
            {
                innerCollection = new List<T>();
            }
            public MyClass(T item) : this()
            {
                Item = item;
            }
            public T Item { get; set; }
            private List<T> innerCollection;

            public B GenMethod<B>(ICollection<B> items)
         where B : IComparable<B>
            {
                // Код на метода 
                return default(B);
            }
        }

    }




    public class MyDictionary<K, V>
        where K : IComparable<K>
    {
        private List<K> keys;
        private List<V> values;

        public MyDictionary()
        {
            keys = new List<K>();
            values = new List<V>();
        }

        public void Add(K key, V value)
        {
            keys.Add(key);
            values.Add(value);
        }

        public bool ContainsKey(K key)
        {
            return keys.Contains(key);
        }

        public V GetValueByKey(K key)
        {
            return values[GetIndexOfKey(key)];
        }

        private int GetIndexOfKey(K key) =>
                    keys.IndexOf(key);




    }
}