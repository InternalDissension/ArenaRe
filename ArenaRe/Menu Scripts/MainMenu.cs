using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class MainMenu : Menu
    {
        public MainMenu()
        {
            Object obj = new Object();
            displayMenu();
        }

        /// <summary>
        /// Displays the menu and its options
        /// </summary>
        /// <returns></returns>
        protected override int displayMenu()
        {
            int choice = 0;

            Console.WriteLine(@"
Welcome to Revelation Motherfucker

1. Battle some punks
2. Get tips
3. Quit (Just close the application ass-wipe)");
            Console.Write("Choice: ");

            try
            {
                choice = int.Parse(Console.ReadLine());
            }

            catch
            {
                choice = displayMenu();
            }

            return processMenuChoice(choice);
        }

        /// <summary>
        /// Processes the chosen option on the menu
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        protected override int processMenuChoice(int choice)
        {
            switch(choice)
            {
                case 1:
                    Character c = new Character();
                    break;

                case 2:
                    break;

                case 3:
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    processMenuChoice(displayMenu());
                    break;
            }

            return choice;
        }
    }
}
