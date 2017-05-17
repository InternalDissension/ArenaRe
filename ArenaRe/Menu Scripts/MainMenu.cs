using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class MainMenu : Menu
    {
        Character player;
        bool running = true;

        public MainMenu()
        {
            Object obj = new Object();
            Initialization();
            while (running)
                displayMenu();
            
        }

        /// <summary>
        /// Initializes all necesssary static classes and functions to run the game.
        /// </summary>
        private void Initialization()
        {
            //Initialize the all abilities
            AbilityList.InitializeAbilityList();

        }

        /// <summary>
        /// Displays the menu and its options
        /// </summary>
        /// <returns></returns>
        protected override int displayMenu()
        {
            int choice = 0;
            Console.Clear();
            Console.WriteLine(@"
Welcome to Revelation Motherfucker

1. Battle
2. View Character
3. Get tips
4. Save Game
5. Load Game
6. Quit (Just close the application ass-wipe)");
            Console.Write("Choice: ");

            choice = Helper.processChoice(false);

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
                    if (player == default(Character))
                        player = new Character(true);

                    BattleMenu bm = new BattleMenu(player);
                    break;

                case 2:
                    if (player == default(Character))
                        player = new Character(true);

                    StatViewer.viewCharacter(player);
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 6:
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
