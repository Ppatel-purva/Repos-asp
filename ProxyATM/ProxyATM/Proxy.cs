using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyATM
{
    internal class Proxy
    {
        interface IAtmPin
        {
            void open();
            void close();
        }
        class Atm : IAtmPin
        {
            void IAtmPin.close()
            {
                Console.WriteLine("close the atm");

            }
            void IAtmPin.open()
            {
                Console.WriteLine("open the atm");
            }

            
        }
        //proxy

        class SecuredDoor : IAtmPin
        {
            private IAtmPin mAtm;
            public SecuredDoor(IAtmPin atm)
            {
                mAtm = atm ?? throw new ArgumentNullException("AtmPin", "AtmPin can not be null");
            }

            public void Open(string password)
            {
                if (Authenticate(password))
                {
                    mAtm.open();
                }
                else
                {
                    Console.WriteLine("NO ,get lost");
                }
            }
            private bool Authenticate(string password)
            {
                return password == "purva";
            }
            public void close()
            {
                mAtm.close();
            }

            public void open()
            {
                throw new NotImplementedException();
            }
        }

    }
}


