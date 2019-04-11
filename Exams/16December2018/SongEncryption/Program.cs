using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex valid = new Regex(@"^([A-Z][a-z\s']*):([\sA-Z]*)$");
            
            while (true)
            {
                string incripted = "";
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                var match = valid.Match(input);
                if (match.Length == input.Length)
                {
                    var SingerAndSong = input.Split(":");
                    var song = SingerAndSong[1];
                    int keyAndSinger = SingerAndSong[0].Length;
                    int songName = SingerAndSong[1].Length;
                    
                    for (int i = 0; i < keyAndSinger; i++)
                    {
                        char charecter = input[i];

                        if (charecter == ' ')
                        {
                            incripted+= charecter;
                        }
                        else if (charecter == '\'')
                        {
                            incripted += charecter;
                        }
                        else
                        {

                            int increment = charecter + keyAndSinger;
                            int remeinder = 0;
                            if (i==0)
                            {
                                if (increment > 90)
                                {
                                    remeinder = increment - 90;
                                    increment = 64 + remeinder;
                                }
                            }
                            else
                            {
                                if (increment > 122)
                                {
                                    remeinder = increment - 122;
                                    increment = 96 + remeinder;
                                }
                            }
                            char incrementToChar = (char)increment;
                            incripted += incrementToChar;
                        }
                    }
                    incripted += '@';
                    for (int i = 0; i < songName; i++)
                    {
                        char charecter = song[i];

                        if (charecter == ' ')
                        {
                            incripted += charecter;
                        }
                        else if (charecter == '\'')
                        {
                            incripted += charecter;
                        }
                        else
                        {

                            int increment = charecter + keyAndSinger;
                            int remeinder = 0;
                            if (increment > 90)
                            {
                               remeinder = increment - 90;
                               increment = 64 + remeinder;
                            }
                            
                            
                            char incrementToChar = (char)increment;
                            incripted += incrementToChar;
                        }
                    }

                       Console.WriteLine($"Successful encryption: {incripted}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                
                
            }
            
        }
    }
}
