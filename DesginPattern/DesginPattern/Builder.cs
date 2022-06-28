using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class Builder
    {
        class Burger
        {
            private string Cheese;
            private string Paparony;
            private string size;
            private string lotuse;
        }
        public BurgerBuilder(int size)
        {
            this.size = size;
        }
        public BurgerBuilder AddCheese()
        {
            this.AddCheese = true;
            return this;
        }
        public Burger Build()
        {
            return new Burger(this);
        }
        var burgr = new BurgerBuilder(4).AddCheese().AddPepperoni().AddLotaus().Build();
        Console.WriteLine(Burger.GetDesc());
    }
}
