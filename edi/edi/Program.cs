using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "D:/edifile.txt";
            var text = File.ReadAllText(path, Encoding.UTF8);
            Console.WriteLine(text);
            Console.WriteLine("----------------------");
            char[] delimiterChars = { '~' };
            string[] words = text.Split(delimiterChars);
            Console.WriteLine(delimiterChars);
            foreach (var word in words)
            {
                System.Console.WriteLine($"{word}");
            }


        }
    }
}   
