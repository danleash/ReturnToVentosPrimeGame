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
        public void crashSiteLumiere()
        {
            gold = 100;
            counter = 0;
            weapon = "Annihilator";
            position = "Lumiere Fields";
            Console.WriteLine("You have arrived on Lumiere. You need to get to the next planet.\nWhat will you do next?\nType the number 1 to approach the palace:");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                choiceAction1();
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                Console.ReadLine();
                crashSiteLumiere();
            }
        }
        public void approachPalace()
        {
            Console.Clear();
            playerHp = 20;
            alienHP = 20;
            position = "Approach Palace";
            if (counter == 0)
            {
                Console.WriteLine($"You approach the Palace but on the way you are ambushed. You currently have a {weapon} with you.");
                alienFight();
            }
            else
            {
                Console.WriteLine($"You stray from the Palace Road. You head West to where you last saw the alien.\n\nYou must fight the alien and win to gain their trust.\n\n");
                alienFight();
            }
        }
        public void alienFight()
        {
            Console.WriteLine("As you walk you bump into what seems like nothing. An alien slowly leaves it's invisible form.\n\nYou " +
                "are in danger... What will you do?\n\nType 1 to fight.\n\nType 2 to run.");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                choiceAction1();
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                Console.ReadLine();
                alienFight();
            }
        }
        public void Palace()
        {
            Console.Clear();

            position = "Palace";
            if (alienDefeated == true)
            {
                if (counter == 3)
                {
                    position = "Palace";
                    Console.WriteLine("What will you do next?\nEnter 1 to trade.\nEnter 2 to search the area.");
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        choiceAction1();
                    }
                    catch (FormatException fEx)
                    {
                        Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                        Console.ReadLine();
                        Palace();
                    }
                }
                else
                {
                    position = "Palace";
                    Console.WriteLine("You arrive at the Palace. The gaurd lets you in because you killed the alien. \nWhen you walk into the Palace, you see a Trader store. Maybe you can trade with them in order to get a new spaceship.\n What will you do?\nEnter 1 to trade.\nEnter 2 to search the area.");
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        choiceAction1();
                    }
                    catch (FormatException fEx)
                    {
                        Console.WriteLine($"{ fEx.Message} try again... Press any key to continue...");
                        Console.ReadLine();
                        Palace();
                    }
                }
            }
            else
            {
                counter = 1;
                Console.WriteLine("A gaurd is standing at the entrance to the Palace.\nHe stops you before you enter and says:\nI cannont let you in . This planet is infested with aliens and you look to weak..\nIf you kill the alien that is west from here it will prove you are worthy.");
                Console.WriteLine("Press enter to go back");
                Console.ReadLine();
                approachPalace();
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
                        Console.WriteLine($"The alien attacks back and slashes at you dealing {alienDamage} Damage!\nYou now have {playerHp = playerHp - alienDamage} HP\n\nThe alien has {alienHP} HP");
                    }
                    else
                    {
                        Console.WriteLine($"You attack the Alien dealing {playerDamage} damage! with your {weapon}");
                        Console.WriteLine($"The alien attacks back and slashes at you dealing {alienDamage} Damage!\nYou now have {playerHp = playerHp - alienDamage} HP\n\nThe alien has {alienHP -= playerDamage} HP");
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
                aliendrop = "Gem of Lumiere";
                weapon = "Annihilator";
                Console.WriteLine($"You have defeated the alien.\nThe alien dropped a {aliendrop} and 200 gold. You now have {gold = (gold + 200)} gold. \n \n");
                Console.WriteLine("After defeating the alien you approach the Palace.\n\nPress any key to continue...");
                Console.ReadLine();
                Palace();

            }
        }


        public void Trader()
        {
            position = "Trader";
            if (counter < 4)
            {
                counter = 4;
                Console.WriteLine("Good day to you sir! Thank you for dealing with that alien. It was stealing the Palace Gems!\nWhat can I do you for?\nEnter 1 to view my inventory if you want to buy items.\nEnter 2 to sell an item.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    choiceAction1();
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
                    choiceAction1();
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
        public void choiceAction1()
        {
            switch (position)
            {
                case "Crash Site : Lumiere":
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You see a palace in the distance and decide to approach it,\nmaybe there is someone who can help there.");
                            approachPalace();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to approach the palace.\n\nPress any key to continue...");
                            Console.ReadLine();
                            crashSiteLumiere();
                            break;

                    }
                    break;
                case "Approach palace":
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"You pull out your {weapon}, ready to fight.");
                            playerAttack();
                            break;
                        case 2:
                            Console.WriteLine($"You run to the palace and manage to escape, however you are hit by alien venom and lose 1 HP.\nYour HP is now {playerHp - 1}");
                            Palace();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to fight!\nEnter 2 to run!\n\nPress any key to continue...");
                            Console.ReadLine();
                            approachPalace();
                            break;
                    }
                    break;
                case "Palace":
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\nYou approach the palace trader.");
                            Trader();
                            break;
                        case 2:
                            Console.WriteLine($"You search the area and luck is on your side. You find 100 gold! You now have {gold = (gold + 100)} gold.\nPress any key to continue...");
                            Console.ReadLine();
                            counter = 3;
                            Palace();
                            break;
                        default:
                            Console.WriteLine("Invalid entry. Enter 1 to talk to Trader.\nEnter 2 to search the area. \n\nPress any key to continue...");
                            Console.ReadLine();
                            Palace();
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
                            Palace();
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


