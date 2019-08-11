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
            weapon = "VentosBlast";
            position = "Ventos Prime HQ";
            Console.WriteLine("You have finally reached Ventos Prime.\nWhat will you do next?\nType the number 1 to approach VP HQ:");
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
       
      


        public void VPHQ()
        {
            position = "Trader";
            if (counter < 4)
            {
                counter = 4;
                Console.WriteLine("Welcom back Agent.\nWhat can I do you for?\nEnter 1 to view my inventory if you want to buy items.\nEnter 2 to sell an item.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    choiceAction();
                }
                catch (FormatException fEx)
                {
                    Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                    Console.ReadLine();
                    VPHQ();
                }
            }
            else if (counter >= 4)
            {
                Console.WriteLine("\nWhat can I do you for?\nEnter 1 to view my inventory if you want to buy items.\nEnter 2 to sell an item.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    choiceAction();
                }
                catch (FormatException fEx)
                {
                    Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                    Console.ReadLine();
                    VPHQ();
                }
            }
        }
        public void leavePlanet()
        {
            if (HasSpaceShip == true)
            {
                Console.WriteLine("You can now leave to the next planet.\nYou climb aboard your Space Ship and prepare for lift off.\n\nPress any key to take off!");
                Console.ReadLine();
            }
            else
            {
                VPHQ();
            }
        }
        public void choiceAction()
        {
            switch (position)
            {
                case "VPHQ1":
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You see VPHQ in the distance and decide to approach it");
                            VPHQ();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to approach VPHQ.\n\nPress any key to continue...");
                            Console.ReadLine();
                            crashSiteVentosPrime();
                            break;

                    }
                    break;
                
                    
                case "VPHQ2":
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\nYou approach the Ventos Prime HQ.");
                            VPHQ();
                            break;
                        case 2:
                            Console.WriteLine($"You search the area and luck is on your side. You find 100 gold! You now have {gold = (gold + 100000)} gold.\nPress any key to continue...");
                            Console.ReadLine();
                            counter = 3;
                            VPHQ();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to talk to Trader.\nEnter 2 to search the area. \n\nPress any key to continue...");
                            Console.ReadLine();
                            VPHQ();
                            break;
                    }
                    break;
                case "Trader":
                    switch (choice)
                    {
                        
                        case 1:
                            sell();
                            HasItem = false;
                            Console.ReadLine();
                            VPHQ();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to buy from Trader.\nEnter 2 to sell to Trader.\n\nPress any key to continue...");
                            Console.ReadLine();
                            VPHQ();
                            break;
                    }
                    break;


            }
        }
    }
}

