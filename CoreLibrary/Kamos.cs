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
            p.position = "Crash site";
            Console.WriteLine("You have crash-landed on an alien planet. Your ship is badly damaged, and you are lost." +
                "\nWhat will you do next?\n Type the number 1 to (TODO):");
             choice= Convert.ToInt32(Console.ReadLine());
            choiceAction(); 
        }
        public void choiceAction()
        {
            switch (p.position)
            {
                case "Crash site":
                    switch (choice) {
                        case 1:
                    Console.WriteLine("This will happen...");
                            break;
            }
                    break;
            }
        }
    }
}
