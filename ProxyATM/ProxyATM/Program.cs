using System;

namespace ProxyATM
{
    internal class Program
    {                                                                                                             
        static void Main(string[] args)
        {
           
            var atm = new SecuredDoor(new Atm());
            atm.open("invalid");

            atm.open("purva");
            atm.close();
        }
    }
}
