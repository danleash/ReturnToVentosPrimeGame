using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    class Omia : BuyOrSell
    {
        int choice;
        public void crashSiteOmia()
        {
            gold = 100;
            counter = 0;
            weapon = "Particle Seperator";
            position = "Omia Lake";
            Console.Clear();
            Console.WriteLine("You have landed on the planet Omia.\nYour ship is out of fuel and hit an asteroid belt upon entering the atmosphere, your ship is toast...\n\nYou see an alien castle not too far from you. What will you do next?\nType the number 1 to approach alien castle:");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                choiceAction();
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                Console.ReadLine();
                crashSiteOmia();
            }
        }
        public void approachCastle()
        {
            Console.Clear();
            playerHp = 28;
            alienHP = 20;
            position = "Approach Castle";
            if (counter == 0)
            {
                Console.WriteLine($"You approach the Castle but on the way you are attacked by an alien. You currently have a {weapon} with you.");
                alienFight();
            }
            else
            {
                Console.WriteLine($"You leave the Castle entrance. You head south to the Omia Lake where you last saw the alien.\n\nYou must fight the alien and win.\n\n");
                alienFight();
            }
        }
        public void alienFight()
        {
            Console.WriteLine("The alien drags you underwater.\n\nYou " +
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
        public void Castle()
        {
            Console.Clear();

            position = "Castle";
            if (alienDefeated == true)
            {
                if (counter == 3)
                {
                    position = "Castle";
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
                        Castle();
                    }
                }
                else
                {
                    position = "Castle";
                    Console.WriteLine("You arrive at the Castle. The Gaurd lets allows entry for killing the alien. \nWhen you walk into the Castle, you see a Trader. Maybe you can trade with them in order to get a new spaceship.\n What will you do?\nEnter 1 to trade.\nEnter 2 to search the area.");
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        choiceAction();
                    }
                    catch (FormatException fEx)
                    {
                        Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                        Console.ReadLine();
                        Castle();
                    }
                }
            }
            else
            {
                counter = 1;
                Console.WriteLine("A gaurd is standing at the entrance to the Castle.\nHe stops you before you enter and says:\nYour entry is denied. We have alien beings lurking in Omian Lands.\nIf you kill the alien that is south from here I will allow your entrance.");
                Console.WriteLine("Press enter to go back");
                Console.ReadLine();
                approachCastle();
            }
        }
        public void playerAttack()
        {
            position = "playerAttack";

            int playerDamage = 0;
            int alienDamage = 0;
            do
            {
                if (weapon == "Particle Seperator")
                {
                    Random ranum = new Random();
                    playerDamage = ranum.Next(6, 10);
                    Random aliendam = new Random();
                    alienDamage = aliendam.Next(5, 7);
                    if (alienHP < 0)
                    {
                        alienHP = 0;
                        Console.WriteLine($"You attack the Alien dealing {playerDamage} damage! with your {weapon}");
                        Console.WriteLine($"The alien slams you with it's enormous tail  dealing {alienDamage} Damage!\nYou now have {playerHp = playerHp - alienDamage} HP\n\nThe alien has {alienHP} HP");
                    }
                    else
                    {
                        Console.WriteLine($"You attack the Alien dealing {playerDamage} damage! with your {weapon}");
                        Console.WriteLine($"The alien lungese at you with its claws dealing {alienDamage} Damage!\nYou now have {playerHp = playerHp - alienDamage} HP\n\nThe alien has {alienHP -= playerDamage} HP");
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
                aliendrop = "Sphere of Light";
                weapon = "Lightning Blaster";
                Console.WriteLine($"You have defeated the alien.\nThe alien dropped a {aliendrop}, a {weapon} weapon, and 500 gold. You now have {gold = (gold + 500)} gold. \n \n");
                Console.WriteLine("After defeating the alien you approach the village.\n\nPress any key to continue...");
                Console.ReadLine();
                Castle();

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
                case "Omia Lake":
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You see a Castle in the distance and decide to approach it,\nmaybe there is someone who can help there.");
                            approachCastle();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to approach the village.\n\nPress any key to continue...");
                            Console.ReadLine();
                            crashSiteOmia();
                            break;

                    }
                    break;
                case "Approach Castle":
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You pull out your {weapon}, ready to fight.");
                            playerAttack();
                            break;
                        case 2:
                            Console.WriteLine($"You run to the Castle and manage to escape, however you are hit by alien venom and lose 1 HP.\nYour HP is now {playerHp - 1}");
                            Castle();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to fight!\nEnter 2 to run!\n\nPress any key to continue...");
                            Console.ReadLine();
                            approachCastle();
                            break;
                    }
                    break;
                case "Castle":
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\nYou approach the Castle trader.");
                            Trader();
                            break;
                        case 2:
                            Console.WriteLine($"You search the area and luck is on your side. You find 100 gold! You now have {gold = (gold + 100)} gold.\nPress any key to continue...");
                            Console.ReadLine();
                            counter = 3;
                            Castle();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to talk to Trader.\nEnter 2 to search the area. \n\nPress any key to continue...");
                            Console.ReadLine();
                            Castle();
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
                        case 3:
                                Castle();
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


