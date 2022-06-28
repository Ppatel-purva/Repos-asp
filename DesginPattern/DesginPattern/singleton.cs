using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class singleton
    {
        public class President
        {
            static President intance;

        }
        private President()
        {

        }
        public static President GetInstance()
        {
            if(GetInstance == null)
            {
                GetInstance = new President();
            }
            return instance;
        }
    }

    President biden = President.GetInstance();
    President trump = President.GetInstance();

}
