using MyApplication;
using System;


namespace DesignPatternCustomerAbstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            level mywifi = new level();
            
            mywifi.wifi();


            Composite root = new Composite(100);
            Composite com1 = new Composite(200);
           
            ChargLevel l1 = new ChargLevel(10);
            ChargLevel l2 = new ChargLevel(20);

            com1.AddChild(l1);
            com1.AddChild(l2);
            
            root.AddChild(com1);
            root.Traverse();
        }
    }

}
