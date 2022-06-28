using System;
using System.Collections.Generic;
using System.Text;
using static DesginPattern.Program;

namespace DesginPattern
{
    internal class simpleFactory
    {
       


            public interface Idoor
            {
                int GetHeight();
                int GetWidth();
            }
            public class WoodenDoor : Idoor
            {
                public WoodenDoor(int height, int width)
                {
                    Height = height;
                    Width = width;
                }

                public int Height { get; set; }
                public int Width { get; set; }



            }
            public WoodenDoor(int height, int width)
            {
                this.height = height;
                this.width = width;

                public int GetHeight()
                {
                    return height;

                }
                public int GetWidth()
                {
                    return width;
                }
            }
            public static class DoorFactory
            {
                public static Idoor MakeDoor(int height, int width)
                {
                return new WoodenDoor(height, width);
                }
            }
        }
        var Door = DoorFactory.MakeDoor(100, 70);
    }

}
}
