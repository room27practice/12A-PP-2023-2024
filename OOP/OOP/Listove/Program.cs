class Program
{
    public static void Main()
    {
        List<int> nums = new List<int>();

        //  nums[8] = 45;

        MyList<int> myNums = new MyList<int>();
        MyList<bool> myNums2 = new MyList<bool>();

        myNums.AuthorName = "Marin";
        myNums2.AuthorName = "Samuil";

        MyList<int>.ProjectName = "SuperDobriq proekt bate bate";
        MyList<string>.ProjectName = "Alabale";
        Console.WriteLine(MyList<string>.ProjectName);

        var myPeople = new MyList<Person>();


        myNums.Push(2);
        int lastEl = myNums.Pop();

        var words = "Marin,Samuil,Miroslav,Emir,Georgi,Sunai,Denian,Kostadin,Idriz,Shukri,Berk,Giunai,Hristomir";

        foreach (string word in words.Split(",").OrderBy(x => x))
        {
         // sp1.Push(word);
        }

    }
}

class  Person : IComparable<Person>
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }

    public int CompareTo(Person other)
    {
        return this.Age - other.Age;
    }
}


public class MyList<T> : List<T>
       where T : IComparable<T>
{
    public MyList()
    { }

    public MyList(T something)
    { }

    public static string ProjectName { get; set; }
    public string AuthorName { get; set; }
    public void Push(T element)
    {
        this.Add(element);
    }

    public T Pop()
    {
        if (!this.Any())
        {
            throw new InvalidOperationException("Collection is empty");
        }

        var result = this.Last();
        this.RemoveAt(this.Count() - 1);
        return result;
    }

    public T Dequeue()
    {
        if (!this.Any())
        {
            throw new InvalidOperationException("Collection is empty");
        }

        var result = this.First();
        this.RemoveAt(0);
        return result;
    }

    public T PeekFront()
    {
        if (!this.Any())
        {
            return default(T);
        }

        var result = this.Last();
        return result;
    }

    public T PeekBack()
    {
        if (!this.Any())
        {
            return default(T);
        }

        var result = this.First();
        return result;
    }


    public List<T> GetEvens()
    {
        var result = new List<T>();
        for (int i = 0; i < this.Count(); i += 2)
        {
            result.Add(this[i]);
        }

        return result;
    }

    public IEnumerable<T> GetOdds()
    {
        for (int i = 1; i < this.Count(); i += 2) yield return this[i];
    }

    public List<T> GetNmin(int count) =>
                                        this.OrderBy(x => x).Take(count).ToList();

    public List<T> GetNmax(int count)
    {
        var ordered = this.OrderByDescending(x => x).ToArray();
        var result = new List<T>();
        for (int i = 0; i < count; i++)
        {
            result[i] = ordered[i];
        }
        return result;
    }
    public override string ToString()
    {
        return $"I am custumized list with {this.Count()} elements";
    }
}



public class SpecialList<T>
{
    private List<T> hiddenList = new List<T>();
    public static string ProjectName { get; set; }
    public string AuthorName { get; set; }

    public void Push(T element)
    {
        hiddenList.Add(element);
    }

    public T Pop()
    {
        if (!hiddenList.Any())
        {
            throw new InvalidOperationException("Collection is empty");
        }
        var result = hiddenList.Last();
        hiddenList.RemoveAt(hiddenList.Count() - 1);
        return result;
    }

    public T Dequeue()
    {
        if (!hiddenList.Any())
        {
            throw new InvalidOperationException("Collection is empty");
        }

        var result = hiddenList.First();
        hiddenList.RemoveAt(0);
        return result;
    }

    public T PeekFront()
    {
        if (!hiddenList.Any())
        {
            return default(T);
        }

        var result = hiddenList.Last();
        return result;
    }

    public T PeekBack()
    {
        if (!hiddenList.Any())
        {
            return default(T);
        }

        var result = hiddenList.First();
        return result;
    }


    public List<T> GetEvens()
    {
        var result = new List<T>();
        for (int i = 0; i < hiddenList.Count(); i += 2)
        {
            result.Add(hiddenList[i]);
        }

        return result;
    }

    public IEnumerable<T> GetOdds()
    {
        for (int i = 1; i < hiddenList.Count(); i += 2)
        {
            yield return hiddenList[i];
        }
    }

    //public List<T> GetNmin(int count) =>
    //                hiddenList.OrderBy(x => x).Take(count).ToList();
    //public List<T> GetNmax(int count)
    //{
    //    var ordered = hiddenList.OrderByDescending(x => x).ToArray();
    //    var result = new List<T>();
    //    for (int i = 0; i < count; i++)
    //    {
    //        result[i] = ordered[i];
    //    }
    //    return result;
    //}

    public override string ToString()
    {
        return $"I am custumized list with {hiddenList.Count()} elements";
    }

}


