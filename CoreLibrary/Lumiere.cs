using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    class Lumiere : BuyOrSell
    {
        int choice;
        public void crashSite()
        {
            gold = 100;
            counter = 0;
            weapon = "CellBlaster";
            position = "Crash site";
            Console.WriteLine("You have crash-landed on an alien planet. Your ship is badly damaged, and you are lost.\nWhat will you do next?\nType the number 1 to approach alien village:");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                choiceAction();
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                Console.ReadLine();
                crashSite();
            }
        }
        public void approachVillage()
        {
            Console.Clear();
            playerHp = 15;
            alienHP = 15;
            position = "Approach village";
            if (counter == 0)
            {
                Console.WriteLine($"You approach the village but on the way you are attacked by an alien. You currently have a {weapon} with you.");
                alienFight();
            }
            else
            {
                Console.WriteLine($"You leave the village entrance. You head north to where you last saw the alien.\n\nYou must fight the alien and win to gain their trust.\n\n");
                alienFight();
            }
        }
        public void alienFight()
        {
            Console.WriteLine("The alien leaps down from the rocky terrain and shreiks into the air.\n\nYou " +
                "are in danger... What will you do?\n\nType 1 to fight.\n\nType 2 to run.");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                choiceAction();
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                Console.ReadLine();
                alienFight();
            }
        }
        public void Village()
        {
            Console.Clear();

            position = "Village";
            if (alienDefeated == true)
            {
                if (counter == 3)
                {
                    position = "Village";
                    Console.WriteLine("What will you do next?\nEnter 1 to trade.\nEnter 2 to search the area.");
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        choiceAction();
                    }
                    catch (FormatException fEx)
                    {
                        Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                        Console.ReadLine();
                        Village();
                    }
                }
                else
                {
                    position = "Village";
                    Console.WriteLine("You arrive at the village. The gaurd lets you in because you killed the alien. \nWhen you walk into the village, you see a general store. Maybe you can trade with them in order to get a new spaceship.\n What will you do?\nEnter 1 to trade.\nEnter 2 to search the area.");
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        choiceAction();
                    }
                    catch (FormatException fEx)
                    {
                        Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                        Console.ReadLine();
                        Village();
                    }
                }
            }
            else
            {
                counter = 1;
                Console.WriteLine("A gaurd is standing at the entrance to the village.\nHe stops you before you enter and says:\nWe cannot let you in there are dangerous aliens on this planet, and I do not know you.\nIf you kill the alien that is north from here it will prove you are trustworthy.");
                Console.WriteLine("Press enter to go back");
                Console.ReadLine();
                approachVillage();
            }
        }
        public void playerAttack()
        {
            position = "playerAttack";

            int playerDamage = 0;
            int alienDamage = 0;
            do
            {
                if (weapon == ("CellBlaster"))
                {
                    Random ranum = new Random();
                    playerDamage = ranum.Next(1, 7);
                    Random aliendam = new Random();
                    alienDamage = aliendam.Next(1, 3);
                    if (alienHP < 0)
                    {
                        alienHP = 0;
                        Console.WriteLine($"You attack the Alien dealing {playerDamage} damage! with your {weapon}");
                        Console.WriteLine($"The alien attacks back and vomits venom at you dealing {alienDamage} Damage!\nYou now have {playerHp = playerHp - alienDamage} HP\n\nThe alien has {alienHP} HP");
                    }
                    else
                    {
                        Console.WriteLine($"You attack the Alien dealing {playerDamage} damage! with your {weapon}");
                        Console.WriteLine($"The alien attacks back and vomits venom at you dealing {alienDamage} Damage!\nYou now have {playerHp = playerHp - alienDamage} HP\n\nThe alien has {alienHP -= playerDamage} HP");
                    }
                }


            } while (alienHP > 0);
            {
                alienBeat();
            }

        }
        public void alienBeat()
        {
            if (alienHP <= 0)
            {
                alienDefeated = true;
                HasItem = true;
                aliendrop = "Golden Horn";
                weapon = "Annihilator";
                Console.WriteLine($"You have defeated the alien.\nThe alien dropped a {aliendrop} and 100 gold. You now have {gold = (gold + 100)} gold. \n \n");
                Console.WriteLine("After defeating the alien you approach the village.\n\nPress any key to continue...");
                Console.ReadLine();
                Village();

            }
        }


        public void Trader()
        {
            position = "Trader";
            if (counter < 4)
            {
                counter = 4;
                Console.WriteLine("Good day to you sir! Thank you for dealing with that alien out side of town! He ate my wife and kids a few weeks ago.\nWhat can I do you for?\nEnter 1 to view my inventory if you want to buy items.\nEnter 2 to sell an item.");
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
                    Trader();
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
                Trader();
            }
        }
        public void choiceAction()
        {
            switch (position)
            {
                case "Crash site":
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You see a village in the distance and decide to approach it,\nmaybe there is someone who can help there.");
                            approachVillage();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to approach the village.\n\nPress any key to continue...");
                            Console.ReadLine();
                            crashSite();
                            break;

                    }
                    break;
                case "Approach village":
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You pull out your {weapon}, ready to fight.");
                            playerAttack();
                            break;
                        case 2:
                            Console.WriteLine($"You run to the village and manage to escape, however you are hit by alien venom and lose 1 HP.\nYour HP is now {playerHp - 1}");
                            Village();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to fight!\nEnter 2 to run!\n\nPress any key to continue...");
                            Console.ReadLine();
                            approachVillage();
                            break;
                    }
                    break;
                case "Village":
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\nYou approach the village trader.");
                            Trader();
                            break;
                        case 2:
                            Console.WriteLine($"You search the area and luck is on your side. You find 100 gold! You now have {gold = (gold + 100)} gold.\nPress any key to continue...");
                            Console.ReadLine();
                            counter = 3;
                            Village();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to talk to Trader.\nEnter 2 to search the area. \n\nPress any key to continue...");
                            Console.ReadLine();
                            Village();
                            break;
                    }
                    break;
                case "Trader":
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
                            sell();
                            HasItem = false;
                            Console.ReadLine();
                            Trader();
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


