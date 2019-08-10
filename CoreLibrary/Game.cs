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
            p2.crashSite();
            Omia p3 = new Omia();
            p3.crashSite();
            Deluvia p4 = new Deluvia();
            p4.crashSite();
            Ventos_Prime p5 = new Ventos_Prime();
            p5.crashSite();
            Console.WriteLine("Thanks for playing hope you liked it!\n\nCreated by Alex Madrigal and Dan Leash");


        }
    }
}
