using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class AbstractFactory
    {
        interface IDoor
        {
            void GetDescription();
        }
        class WoodenDoor : IDoor
        {
            public void GetDescription()
            {
                Console.WriteLine("wooden door");
            }
        }
        class IranDoor : IDoor
        {
            public void GetDescription()
            {
                Console.WriteLine("iren door");
            }
        }
        interface IDoorFittingExpert
        {
            void GetDescription() { }
        }
        class Carpenter : IDoorFittingExpert
        {
            public void GetDescription() 
            {
                Console.WriteLine("fitting  door");
            }
        }
        IDoor MakeDoor();
        IDoorFittingExpert MakeFeetingExpeet();

    }
    class woodenDoorFactory : IDoorFactory
    {
        public IDoor MakeDoor()
        {
            return woodenDoor();
        }
        public IDoorFittingExpert MakeFittingExport()
        {
            return new Carpenter();
        }

        private class Carpenter
        {
            public Carpenter()
            {
            }
        }
    }
}
