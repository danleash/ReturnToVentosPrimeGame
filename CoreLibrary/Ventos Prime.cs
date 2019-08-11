using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    class Ventos_Prime : BuyOrSell
    {
        int choice;
        public void crashSiteVentosPrime()
        {
            gold = 1000000;
            counter = 0;
            weapon = "The Blade of Deluvia";
            position = "Ventos Prime HQ";
            Console.Clear();
            Console.WriteLine($"You have finally reached Ventos Prime, your home planet.\n\nYou are greeted as a hero and given a reward for your bravery.\n\nYou now have {gold} gold!\nWhat will you do next?\nType the number 1 to approach VP HQ:");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                choiceAction();
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                Console.ReadLine();
                crashSiteVentosPrime();
            }
        }
       
      


        public void Trader()
        {
            position = "VPHQ";
            if (counter < 4)
            {
                counter = 4;
                Console.WriteLine("Welcom back Wessex. You are a true hero.\nWhat can I do you for?\nEnter 1 to view my inventory if you want to buy items.\nEnter 2 to finally return home.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    choiceAction();
                }
                catch (FormatException fEx)
                {
                    Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                    Console.ReadLine();
                    Trader();
                }
            }
            else if (counter >= 4)
            {
                Console.WriteLine("What can I do you for?\nEnter 1 to view my inventory if you want to buy items.\nEnter 2 to finally return home.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    choiceAction();
                }
                catch (FormatException fEx)
                {
                    Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                    Console.ReadLine();
                    Trader();
                }
            }
        }
        public void leavePlanet()
        {
            if (HasSpaceShip == true)
            {
                Console.WriteLine("After years of inter-gallactic travel, you decide that maybe home isn't home for you after all.\n\nSo you board your ship, now being extremely wealthy,\nand take off hoping for a new adventure!\n\nTHE END!");
                Console.ReadLine();
            }
            else
            {
                Trader();
            }
        }
        public void choiceAction()
        {
            switch (position)
            {
                case "Ventos Prime HQ":
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You see VPHQ in the distance and decide to approach it.\nYou are greeted by your favorite merchant.");
                           Trader();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to approach VPHQ.\n\nPress any key to continue...");
                            Console.ReadLine();
                            crashSiteVentosPrime();
                            break;

                    }
                    break;
                
                    
                case "VPHQ":
                    switch (choice)
                    {
                        case 1:
                            SpaceShip = 400;
                            HealingPotion = 50;
                            Armor = 100;
                            buy();
                            leavePlanet();
                            break;
                        case 2:
                            Console.WriteLine("You return home this time as a wealthy, brave man!\n\nYou retire the rest of your days in harmony.");
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to buy from Trader.\nEnter 2 to sell to Trader.\n\nPress any key to continue...");
                            Console.ReadLine();
                            Trader();
                            break;
                    }
                    break;


            }
        }
    }
}

