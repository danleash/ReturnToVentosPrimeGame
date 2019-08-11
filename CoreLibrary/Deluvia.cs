using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    class Deluvia : BuyOrSell
    {
        int choice;
        public void crashSiteDeluvia()
        {
            gold = 100;
            counter = 0;
            weapon = "Plasma Blade";
            position = "Ruins";
            Console.WriteLine("You have reached the quiet ruin of Deluvia.\nWhat will you do next?\nType the number 1 to approach alien village:");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                choiceAction();
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                Console.ReadLine();
                crashSiteDeluvia();
            }
        }
        public void approachCave()
        {
            Console.Clear();
            playerHp = 15;
            alienHP = 15;
            position = "Approach Cave";
            if (counter == 0)
            {
                Console.WriteLine($"You approach the Cave but on the way you are attacked by an alien. You currently have a {weapon} with you.");
                alienFight();
            }
            else
            {
                Console.WriteLine($"You leave the Cave entrance. You head east to where you last saw the alien.\n\nYou must fight the alien and win to gain their trust.\n\n");
                alienFight();
            }
        }
        public void alienFight()
        {
            Console.WriteLine("You feel the ground shake and start to crack. An alien shoots out of the ground.\n\nYou " +
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
        public void Cave()
        {
            Console.Clear();

            position = "Cave";
            if (alienDefeated == true)
            {
                if (counter == 3)
                {
                    position = "Cave";
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
                        Cave();
                    }
                }
                else
                {
                    position = "Cave";
                    Console.WriteLine("You arrive at the Cave. The gaurd lets you in because you killed the alien. \nWhen you walk into the village, you see a cavetrader. Maybe you can trade with them in order to get a new spaceship.\n What will you do?\nEnter 1 to trade.\nEnter 2 to search the area.");
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        choiceAction();
                    }
                    catch (FormatException fEx)
                    {
                        Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                        Console.ReadLine();
                        Cave();
                    }
                }
            }
            else
            {
                counter = 1;
                Console.WriteLine("A gaurd is standing at the entrance to the Cave.\nHe stops you before you enter and says:\nThis is the last safe cave of Deluvia. I cannot let outsiders in.\nIf you kill the alien that is east from here it will prove you are trustworthy.");
                Console.WriteLine("Press enter to go back");
                Console.ReadLine();
                approachCave();
            }
        }
        public void playerAttack()
        {
            position = "playerAttack";

            int playerDamage = 0;
            int alienDamage = 0;
            do
            {
                if (weapon == ("Plasma Blade"))
                {
                    Random ranum = new Random();
                    playerDamage = ranum.Next(1, 7);
                    Random aliendam = new Random();
                    alienDamage = aliendam.Next(1, 3);
                    if (alienHP < 0)
                    {
                        alienHP = 0;
                        Console.WriteLine($"You attack the Alien dealing {playerDamage} damage! with your {weapon}");
                        Console.WriteLine($"The alien attacks and lunges a boulder at you dealing {alienDamage} Damage!\nYou now have {playerHp = playerHp - alienDamage} HP\n\nThe alien has {alienHP} HP");
                    }
                    else
                    {
                        Console.WriteLine($"You attack the Alien dealing {playerDamage} damage! with your {weapon}");
                        Console.WriteLine($"The alien shoots shards of stone from its mouth at you dealing {alienDamage} Damage!\nYou now have {playerHp = playerHp - alienDamage} HP\n\nThe alien has {alienHP -= playerDamage} HP");
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
                aliendrop = "StoneHeart";
                weapon = "The Blade of Deluvia";
                Console.WriteLine($"You have defeated the alien.\nThe alien dropped a {aliendrop} and 500 gold. You now have {gold = (gold + 500)} gold. \n \n");
                Console.WriteLine("After defeating the alien you approach the Cave.\n\nPress any key to continue...");
                Console.ReadLine();
                Cave();

            }
        }


        public void Trader()
        {
            position = "Trader";
            if (counter < 4)
            {
                counter = 4;
                Console.WriteLine("Good day to you sir! Thank you for dealing with that alien. It wiped out almost all our Army. \nWhat can I do you for?\nEnter 1 to view my inventory if you want to buy items.\nEnter 2 to sell an item.\nEnter 3 to exit.");
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
                case "Cave":
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You see a Cave in the distance and decide to approach it,\nmaybe there is someone who can help there.");
                            approachCave();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to approach the Cave.\n\nPress any key to continue...");
                            Console.ReadLine();
                            crashSiteDeluvia();
                            break;

                    }
                    break;
                case "Approach Cave":
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You pull out your {weapon}, ready to fight.");
                            playerAttack();
                            break;
                        case 2:
                            Console.WriteLine($"You run to the Cave and manage to escape, however you are hit by alien venom and lose 1 HP.\nYour HP is now {playerHp - 1}");
                            Cave();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to fight!\nEnter 2 to run!\n\nPress any key to continue...");
                            Console.ReadLine();
                            approachCave();
                            break;
                    }
                    break;
                case "Cave2":
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\nYou approach the Cave trader.");
                            Trader();
                            break;
                        case 2:
                            Console.WriteLine($"You search the area and luck is on your side. You find 100 gold! You now have {gold = (gold + 100)} gold.\nPress any key to continue...");
                            Console.ReadLine();
                            counter = 3;
                            Cave();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to talk to Trader.\nEnter 2 to search the area. \n\nPress any key to continue...");
                            Console.ReadLine();
                            Cave();
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
                            Cave();
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

