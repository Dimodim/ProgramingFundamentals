using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>();
            var wordsAndDefinitions = Console.ReadLine().Split(" | ").ToArray();
            for (int i = 0; i < wordsAndDefinitions.Length; i++)
            {
                string[] splited = wordsAndDefinitions[i].Split(": ").ToArray();
                if (!dictionary.ContainsKey(splited[0]))
                {
                    dictionary.Add(splited[0], new List<string>());
                }
                dictionary[splited[0]].Add(splited[1]);
            }
            var wordsToPrint = Console.ReadLine().Split(" | ").ToArray();
            var listOrEnd = Console.ReadLine();
            if (listOrEnd == "End")
            {
                var print = new Dictionary<string, List<string>>();
                foreach (var word in wordsToPrint)
                {
                    if (dictionary.ContainsKey(word))
                    {
                        var curentWordValue = dictionary[word];
                        print[word] = curentWordValue;
                    }
                }
                foreach (var word in print.OrderBy(x=>x.Key))
                {
                    Console.WriteLine(word.Key);
                    foreach (var item in word.Value.OrderByDescending(x=>x.Length))
                    {
                        Console.WriteLine(" -"+item);
                    }
                }
            }
            else
            {
                var print = new List<string>();
                foreach (var word in dictionary.OrderBy(x=>x.Key))
                {
                    print.Add(word.Key);
                }
                Console.WriteLine(string.Join(" ",print));
            }
            

        }
    }
}
