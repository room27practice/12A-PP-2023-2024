class Program
{
    public static void Main()
    {
        List<int> nums = new List<int>();

      //  nums[8] = 45;


        MyList myNums = new MyList();
        MyList myNums2 = new MyList();

        myNums.AuthorName = "Marin";
        myNums2.AuthorName = "Samuil";

        MyList.ProjectName = "SuperDobriq proekt bate bate";
        Console.WriteLine(MyList.ProjectName);


        myNums.Push(2);
        int lastEl = myNums.Pop();



        SpecialList sp1 = new SpecialList();
        

        var words = "Marin,Samuil,Miroslav,Emir,Georgi,Sunai,Denian,Kostadin,Idriz,Shukri,Berk,Giunai,Hristomir";

        foreach (string word in words.Split(",").OrderBy(x => x))
        {
            sp1.Push(word);
        }



    }
}
public class MyList : List<int>
{
    public static string ProjectName { get; set; }
    public string AuthorName { get; set; }

    public void Push(int element)
    {
        this.Add(element);
    }

    public int Pop()
    {
        if (!this.Any())
        {
            throw new InvalidOperationException("Collection is empty");
        }

        var result = this.Last();
        this.RemoveAt(this.Count() - 1);
        return result;
    }

    public int Dequeue()
    {
        if (!this.Any())
        {
            throw new InvalidOperationException("Collection is empty");
        }

        var result = this.First();
        this.RemoveAt(0);
        return result;
    }

    public int PeekFront()
    {
        if (!this.Any())
        {
            return default(int);
        }

        var result = this.Last();
        return result;
    }

    public int PeekBack()
    {
        if (!this.Any())
        {
            return default(int);
        }

        var result = this.First();
        return result;
    }


    public List<int> GetEvens()
    {
        var result = new List<int>();
        for (int i = 0; i < this.Count(); i += 2)
        {
            result.Add(this[i]);
        }

        return result;
    }

    public IEnumerable<int> GetOdds()
    {
        for (int i = 1; i < this.Count(); i += 2)
        {
            yield return this[i];
        }
    }

    public List<int> GetNmin(int count) =>
                    this.OrderBy(x => x).Take(count).ToList();
    public List<int> GetNmax(int count)
    {
        var ordered = this.OrderByDescending(x => x).ToArray();
        var result = new List<int>();
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



public class SpecialList
{
    private List<string> hiddenList = new List<string>();
    public static string ProjectName { get; set; }
    public string AuthorName { get; set; }

    public void Push(string element)
    {
        hiddenList.Add(element);
    }

    public string Pop()
    {
        if (!hiddenList.Any())
        {
            throw new InvalidOperationException("Collection is empty");
        }       
        var result = hiddenList.Last();
        hiddenList.RemoveAt(hiddenList.Count() - 1);
        return result;
    }

    public string Dequeue()
    {
        if (!hiddenList.Any())
        {
            throw new InvalidOperationException("Collection is empty");
        }

        var result = hiddenList.First();
        hiddenList.RemoveAt(0);
        return result;
    }

    public string PeekFront()
    {
        if (!hiddenList.Any())
        {
            return default(string);
        }

        var result = hiddenList.Last();
        return result;
    }

    public string PeekBack()
    {
        if (!hiddenList.Any())
        {
            return default(string);
        }

        var result = hiddenList.First();
        return result;
    }


    public List<string> GetEvens()
    {
        var result = new List<string>();
        for (int i = 0; i < hiddenList.Count(); i += 2)
        {
            result.Add(hiddenList[i]);
        }

        return result;
    }

    public IEnumerable<string> GetOdds()
    {
        for (int i = 1; i < hiddenList.Count(); i += 2)
        {
            yield return hiddenList[i];
        }
    }

    public List<string> GetNmin(int count) =>
                    hiddenList.OrderBy(x => x).Take(count).ToList();
    public List<string> GetNmax(int count)
    {
        var ordered = hiddenList.OrderByDescending(x => x).ToArray();
        var result = new List<string>();
        for (int i = 0; i < count; i++)
        {
            result[i] = ordered[i];
        }
        return result;
    }

    public override string ToString()
    {
        return $"I am custumized list with {hiddenList.Count()} elements";
    }

}


