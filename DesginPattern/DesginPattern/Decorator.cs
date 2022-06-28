 using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class Decorator
    {
        interface ICoffee
        {
            int GetCost();
            string GetDescription();
        }
        class SimpleCoffee: ICoffee
        {
            public int GetCost()
            {
                return 5;
            }
            public string GetDescription()
            {
              return "SimpleCoffee";
            }
        }
        class MilkCoffee: ICoffee
        {
            private readonly ICoffee mCoffee;
            public MilkCoffee(ICoffee coffee)
            {
                mCoffee = coffee ?? throw new ArgumentNullException("coffee","coffee shpold not null");
            }
            public int GetCost()
            {
                return mCoffee.GetCost()+1;
            }
            public static GetDescription()
            {
                return static.Concat(MilkCoffee.GetDescription(), "vanila");
            }
        }
       
    }

}

//use
var mCoffee = new SingleCoffee();
var mDescription = mCoffee.GetDescription();
var mCost = mCoffee.GetCost();

Console.WriteLine("{ mCoffee.GetCost():c}");
