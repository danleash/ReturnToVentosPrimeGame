using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    class Kamos
    {
        PlayerStats p = new PlayerStats();
        int choice;
        public void crashSite()
        {
            p.gold = 100;
            p.weapon = "CellBlaster";
            p.position = "Crash site";
            Console.WriteLine("You have crash-landed on an alien planet. Your ship is badly damaged, and you are lost." +
                "\nWhat will you do next?\n Type the number 1 to approach alien village:");
            choice = Convert.ToInt32(Console.ReadLine());
            choiceAction();
        }
        public void approachVillage()
        {
            p.playerHp = 15;
            p.position = "Approach village";
            Console.WriteLine($"You approach the village but on the way you are attacked by an alien. You currently have a {p.weapon} with you.\nType 1 to fight!\nType2 to run to the village.");
            choice = Convert.ToInt32(Console.ReadLine());
            choiceAction();
        }
        public void alienFight()
        {
            Console.WriteLine("The alien leaps down from the rocky terrain and shreeiks into the air.\nYou " +
                "are in danger...\n What will you do?\n\nType 1 to fight. Type 2 to run.");
        choice = Convert.ToInt32(Console.ReadLine());
            choiceAction();
        }
            public void playerAttack()
            {
            p.alienHP = p.playerHp + 5;
                p.position = "playerAttack";

                int playerDamage = 0;

                if (p.weapon == ("CellBlaster"))
                {
                    Random ranum = new Random();
                    playerDamage = ranum.Next(1, 7);
                    Console.WriteLine($"You attack the Alien dealing {playerDamage} damage! with your {p.weapon}");
                Console.ReadLine();
                }
                else if (p.weapon==string.Empty)
                {
                    Random ranum = new Random();
                    playerDamage = ranum.Next(1, 5);
                    Console.WriteLine($"You attack the Monster with your fists dealing {playerDamage} damage!");
                }

                
            if (p.alienHP > 0)
            {
                p.alienHP-= playerDamage;
                playerAttack();
            }
            else if (p.alienHP == 0)
            {
                p.weapon = "Annihilator";
                Console.WriteLine($"You have defeated the alien.\nThe alien dropped a {p.weapon} and {p.gold}");
                Console.WriteLine("After defeating the alien you approach the village");
                approachVillage();

            }
            }
        public void Village()
        {
            p.position = "Village";
            Console.WriteLine("You arrive at the village. The gaurd lets you in because you killed the alien. When you walk into the village, you see a general store. Maybe you can trade with them in order to get a new spaceship.");

        }
            public void choiceAction()
            {
                switch (p.position)
                {
                    case "Crash site":
                        switch (choice) {
                            case 1:
                                Console.WriteLine($"You see a village in the distance and decide to approach it, maybe there is someone who can help there.");
                                approachVillage();
                                break;
                        }
                        break;
                    case "Approach village":
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine($"You pull out your {p.weapon}, ready to fight.");
                                playerAttack();
                                break;
                            case 2:
                                Console.WriteLine($"You run to the village and manage to escape, however you are hit by alien venom and lose 1 HP. Your HP is now {p.playerHp - 1}");
                                break;
                        }
                        break;
                case "Village":
                    switch (choice)
                    {
                        case 1:
                            break;
                    }
                    break;
                }
            }
        }
    }
