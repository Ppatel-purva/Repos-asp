using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class Proxy
    {
        interface Idoor
        {
            void open();
            void close();
        }
        class Lab : Idoor
        {
            public void close()
            {
                Console.WriteLine("close the door");

            }
            public void Open()
            {
                Console.WriteLine("open the door");
            }
        }
        //proxy

        class SecuredDoor : Idoor
        {
            private Idoor mDoor;
            public SecuredDoor(Idoor door)
            {
                mDoor = door ?? throw new ArgumentNullException("door" , "door can not be null");
            }

            public void Open(string password)
            {
                if (Authenticate(password))
                {
                    mDoor.open();
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
                mDoor.close();
            }
        }
    }
}
