using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    class BuyOrSell : PlayerStats
    {
        public int Armor { get; set; }
        public bool HasArmor { get; set; }
        public int SpaceShip { get; set; }
        public bool HasSpaceShip { get; set; }
        public int HealingPotion { get; set; }
        public bool HasItem { get; set; }
        
             public void buy()
            {
            Console.Clear();
            counter = 4;
                Console.WriteLine($"Here is what we have for sale:\nHealing Potion (restores health by 5) for: {HealingPotion} gold." +
                    $"\nArmor (decreases damage inflicted on you from enemies by 10%) for : {Armor} gold.\nSpace Ship (can take you to the nearest planet) for : {SpaceShip} gold." +
                    $"\nEnter 1 to buy a Healing Potion\n\nEnter 2 to buy armor\n\nEnter 3 to buy a Space Ship that will get you to the next planet.");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    if(gold >= HealingPotion)
                    {
                        gold -= HealingPotion;
                        playerHp += 5;
                        Console.WriteLine($"{HealingPotion} gold has been deducted. You drink the potion.\n\nYou now have {playerHp} health");
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough money press any key to continue...");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    if (gold >= Armor)
                    {
                        gold -= Armor;
                        int armorResistance = (playerHp / 10);
                        playerHp += armorResistance;
                        Console.WriteLine($"{Armor} gold has been deducted. You put on the armor.\n\nYou now have {armorResistance} resistance to enemy attacks.");
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough money press any key to continue...");
                        Console.ReadLine();
                    }
                    break;
                case 3:
                    if (gold >= SpaceShip)
                    {
                        gold -= SpaceShip;
                        Console.WriteLine($"{SpaceShip} gold has been deducted.\nYou did it, you survived this planet!");
                        HasSpaceShip = true;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough money press any key to continue...");
                        Console.ReadLine();
                    }
                    break;
            }
            }
            public void sell()
            {
            Console.Clear();
            counter++;
            Console.WriteLine($"What do you wish to sell?\n\nThe trader will only buy your {aliendrop} that you have aquired for 500 gold.\n\nPress 1 to sell your {aliendrop}.");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        if (HasItem == true)
                        {
                            gold += 500;
                            HasItem = false;
                            Console.WriteLine($"You sold your {aliendrop}");
                        }
                        else
                        {
                            Console.WriteLine("You already sold all of your items. Press any key to continue...");
                            Console.ReadLine();
                        }
                        break;
                }
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                Console.ReadLine();
                sell();
            }
            
            }

        
    }
}
