using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public class Game
    {
        public void CreateGame()
        {
            Kamos p1 = new Kamos();
            p1.crashSite();
            Lumiere p2 = new Lumiere();
            p2.crashSiteLumiere();
            Omia p3 = new Omia();
            p3.crashSiteOmia();
            Deluvia p4 = new Deluvia();
            p4.crashSiteDeluvia();
            Ventos_Prime p5 = new Ventos_Prime();
            p5.crashSiteVentosPrime();
            Console.Clear();
            Console.WriteLine("Thanks for playing hope you liked it!\n\nCreated by Dan Leash and Alex Madrigal");
            Console.ReadLine();

        }
    }
}
