using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Deciphering
{
    class Program
    {

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string decripted = "";
            string[] replaceString = Console.ReadLine().Split();
            Regex patern = new Regex (@"[d-z#|{}]");
            if (patern.IsMatch(input))
            {
                foreach (var charecter in input)
                {

                    int charToNumber = charecter-3;

                    char numToChar = (char)charToNumber;

                    decripted += numToChar;
                }
                
                if (decripted.Contains(replaceString[0]))
                {
                    decripted=decripted.Replace(replaceString[0], replaceString[1]);
                }
                Console.WriteLine(decripted);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
            
        }
    }
}
