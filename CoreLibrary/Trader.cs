using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoreLibrary
{

    public class Trader
    {
        enum TraderItems { ShipPart, GunUpgrade}



        public void sell()
        {
            Console.WriteLine();



        }

        public void Buy()
        {
            Console.WriteLine("What do you want to buy?");

            if (TraderItems.ShipPart)
            {
                player.gold - 200;

                playerItems.add(ShipPart);
            }

        }



    }
}