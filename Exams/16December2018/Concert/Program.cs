using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var bandNameAndMembers = new Dictionary<string, List<string>>();
            var bandTime = new Dictionary<string, int>();
            int totalTime = 0;

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "start of concert")
                {
                    break;
                }
                else
                {
                    var commandGroupTime = input.Split("; ", StringSplitOptions.RemoveEmptyEntries);
                    string command = commandGroupTime[0];
                    string groupName = commandGroupTime[1];
                    if (command == "Add")
                    {
                        var members = commandGroupTime[2].Split(", ", StringSplitOptions.RemoveEmptyEntries);
                        if (!bandNameAndMembers.ContainsKey(groupName))
                        {
                            bandNameAndMembers.Add(groupName, new List<string>());
                        }
                        foreach (var member in members)
                        {
                            if (!bandNameAndMembers[groupName].Contains(member))
                            {
                                bandNameAndMembers[groupName].Add(member);
                            }
                        }
                    }
                    else if (command == "Play")
                    {
                        int time = int.Parse(commandGroupTime[2]);
                        totalTime += time;
                        if (!bandTime.ContainsKey(groupName))
                        {
                            bandTime.Add(groupName, 0);
                        }
                            bandTime[groupName] += time;
                    }
                }

            }
            string bandName = Console.ReadLine();
            Console.WriteLine($"Total time: {totalTime}");
            foreach (var band in bandTime.OrderByDescending(b => b.Value).ThenBy(b => b.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }
            Console.WriteLine(bandName);
            foreach (var member in bandNameAndMembers[bandName])
            {
                Console.WriteLine($"=> {member}");
            }

        }
    }
}
