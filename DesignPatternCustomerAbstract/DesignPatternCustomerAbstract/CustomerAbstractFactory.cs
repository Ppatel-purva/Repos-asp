using System;
using System.Collections;

namespace MyApplication
{
    
    abstract class Customer
    {
      
        public abstract void CustomerInvoice();

        public void wifi()
        {
            Console.WriteLine("connect your wifi");
        }
    }


    class level : Customer
    {
        public override void CustomerInvoice()
        {
           
            Console.WriteLine("your invoice: 10%");
        }
    }
    abstract class Component
    {
        abstract public void AddChild(Component c);
        abstract public void Traverse();
    }
   
    class ChargLevel : Component
    {
        private int value = 0;
        public ChargLevel(int val)
        {
            value = val;
        }
        public override void AddChild(Component c)
        {
            
        }
        public override void Traverse()
        {
            Console.WriteLine("ChargLevel:" + value);
        }
    }
    
    class Composite : Component
    {
        private int value = 0;
        private ArrayList ComponentList = new ArrayList();
        public Composite(int val)
        {
            value = val;
        }
        public override void AddChild(Component c)
        {
            ComponentList.Add(c);
        }
        public override void Traverse()
        {
            Console.WriteLine("Composite:" + value);
            foreach (Component c in ComponentList)
            {
                c.Traverse();
            }
        }
    }
    
}