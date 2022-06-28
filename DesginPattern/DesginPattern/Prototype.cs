using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class Prototype
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public Sheep(string name, string category)
        {
            Name = name;
            Category = category;
        }
        public Sheep clone()
        {
            return MemberwiseClone() as Sheep;

        }
        var orginal = new sheep("dolly", "mountain");
        Console.writeLine("")
    }
}
