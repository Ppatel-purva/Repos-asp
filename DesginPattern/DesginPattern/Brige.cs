using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class Brige
    {
        interface IWebpage
        {
            string GetContent()
            {

            }
            class Abuot : IWebpage
            {
                protected ITheme theme;

                public Abuot(Itheme theme)
                {
                    this.theme = theme;
                }
                public string GetContent()
                {
                    return "About page in (theme.GetColor())";
                }
            }
            interface ITheme
            {
                string GetColor();
            }
            class DarkTheme : ITheme
            {
                public GetColor()
                {
                    return "Dark black";
                }
            }
            class LightTheme : ITheme
            {
                public GetColor()
                {
                    return "white";
                }
            }

            //use


            var darktheme = new DarkTheme();
            var lighttheme = new LightTheme();

           
            var about = new Abuot(DarkTheme);
            var about = new Abuot(about);
            

            Console.WriteLine(about.GetContent());
        }
    }
}
