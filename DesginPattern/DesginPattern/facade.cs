using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class facade
    {
        class Computer
        {
            public void GetElectricShok()
            {
                Console.Write("OUCHHHHHHH");
            }
            public void MaleSound()
            {
                Console.Write("beep beep");
            }
            public void ShowScreen()
            {
                Console.Write("Loding");
            }
            public void closserverthing()
            {
                Console.Write("clossing");
            }

        }
        class ComputerFacade
        {
            private readonly Computer mcomputer;

            public ComputerFacade(Computer computer)
            {
                this.mcomputer = computer ?? throw new ArgumentNullException("coumputer","computer canot be null");

            }
            public void TurnOn()
            {
                mcomputer.GetElectricShok();
                mcomputer.MaleSound();
                mcomputer.ShowScreen();
            }

            public void TurnOf()
            {
                mcomputer.closserverthing();
            }

        }
        //use

       
    }
}

var coumputer = new CoumputerFacade(new Coumputer());
coumputer.TurnOn(); 

