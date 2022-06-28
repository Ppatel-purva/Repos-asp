using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class structurel
    {
        interface ILion
        {
            void Roar();
        }

        class AfricanLion : ILion
        {
            public void Roar()
            {

            }
        }
        class AsiaLion : ILion
        {
            public void Roar()
            {

            }
        }
        class Hunter
        {
            public void Hunt(ILion lion)
            {

            }
        }
        class WildDog
        {
            public void Bark()
            {

            }
        }
        class WildDogAdapter : ILion
        {
            private WildDog mDog;
            public WildDogAdapter(WildDog dog)
            {
                this.mDog = dog;
            }
            public void Roar()
            {
                mDog.Bark();
            }
        }
        //use:

        var WildDog = new WildDog();
        var WildDogAdapter = new WildDogAdapter(WildDog);


        var Hunter = new Hunter();
        Hunter.HuntNewStruct;
        
            
    }
}

    