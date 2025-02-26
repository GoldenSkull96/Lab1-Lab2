using System.Linq.Expressions;
using Newtonsoft.Json;
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello world");
        try
        {
            bool correct = false;
            int x = 0;
            while (!correct)
            {
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    correct = true;
                }
                else
                {
                    Console.WriteLine("uncorrected");
                }
            }
            switch (x)
            {
                case 1:
                    {
                        var people = create();
                        while (people.Count > 1)
                        {
                            remove(ref people);
                            foreach (int num in people)
                            {
                                Console.Write($"{num} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                case 2:
                    {
                        var random = new Random();
                        var List = list();
                        var Dictionary = dictionary();
                        var NewDictionary = new Dictionary<int, List<int>>();
                        int n = 1;
                        foreach (int l in List)
                        {
                            NewDictionary[l] = Dictionary[n++];
                        }
                        Console.WriteLine("list");
                        foreach (int l in List)
                        {
                            Console.Write(l + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("dictionary");
                        for (int i = 1; i < Dictionary.Count; i++)
                        {
                            Console.WriteLine($"dictionary_list {i}");
                            foreach (int l in Dictionary[i])
                            {
                                Console.Write(l + " ");
                            }
                            Console.WriteLine();
                        }
                        string json = JsonConvert.SerializeObject(NewDictionary);
                        var des = JsonConvert.DeserializeObject<Dictionary<int, List<int>>>(json);
                        Console.WriteLine(json);
                    }
                    break;
                case 3:
                    {
                        var line = "ab a ab abc_ b";
                        var c = 'c';
                        List<string> line2 = line.Split(' ').Where(x => x.Contains(c) && x.LastIndexOf(c) == (x.Length - 1)).ToList();
                        if (line2.Count == 1)
                        {
                            Console.WriteLine(line2[0]);
                        }
                        else if (line2.Count > 1)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("ERROR");
        }
    static void remove(ref List<int> list)
        {
            var Remove = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 1)
                {
                    Remove.Add(list[i]);
                }
            }
            for (int i = 0; i < Remove.Count; i++)
            {
                list.Remove(Remove[i]);
            }
        }
        static List<int> create()
        {
            var list = new List<int>();
            bool correct = false;
            int n = 0;
            while (!correct)
            {
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    correct = true;
                }
                else
                {
                    Console.WriteLine("uncorrected");
                }
            }
            for (int i = 1; i <= n; i++)
            {
                list.Add(i);
            }
            foreach (int num in list)
            {
                Console.Write($"{num} ");
            }
            Console.Write("\r\n");
            return list;
        }
        static List<int> list()
        {
            var ran = new Random();
            var hash = new HashSet<int>();
            for (int i = 0; i < 5; i++)
            {
                hash.Add(ran.Next(1, 11));
            }
            var r = hash.ToArray();
            var list = new List<int>();
            foreach (int i in r)
            {
                list.Add(i);
            }
            return list;
        }
        static Dictionary<int, List<int>> dictionary()
        {
            var ran = new Random();
            var dictionary = new Dictionary<int, List<int>>();
            for (int i = 1; i < 6; i++)
            {
                dictionary[i] = list();
            }
            return dictionary;
        }
    } 
}