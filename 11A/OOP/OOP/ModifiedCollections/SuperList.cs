using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedCollections
{
    public class SuperList:List<string>
    {
        public SuperList():base()
        {

        }

        public SuperList(string author, string designation)
        {
            Author = author;
            Designation = designation;
        }

        public string Author { get; set; }
        public string Designation { get; set; }
        public int FavouriteElementIndex { get; set; }


        public string[] GetEvenIndexThings()
        {
            List<string> result=new List<string>();
            for (int i = 0; i < this.Count; i+=2)
            {
                result.Add(this[i]);
            }
            return result.ToArray();
        }

        public string[] GetOddIndexThings()
        {
            List<string> result = new List<string>();
            for (int i = 1; i < this.Count; i += 2)
            {
                result.Add(this[i]);
            }
            return result.ToArray();
        }



    }
}
