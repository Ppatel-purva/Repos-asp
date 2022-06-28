using System;
using System.IO;
using System.Text;

namespace clientConsolAppTextfile
{
    internal class Program
    {
        static void Main(string[] args)
        {



            //var path = "D:/textfile/sender.text";
            //var text = File.ReadAllText(path, Encoding.UTF8);
            //Console.WriteLine(text);

            
                Console.WriteLine("Enter messege");
                string message = Console.ReadLine();
                string path = @"D:/textfile/sender.text";
                File.WriteAllText(path,message);

        }
    }
}
