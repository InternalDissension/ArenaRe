using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class BattleMenu : Menu
    {
        private List<Character> enemies;

        public BattleMenu()
        {
            while (displayMenu() != 4)
                continue;
        }

        private void addEnemy()
        {

        }

        protected override int displayMenu()
        {
            Console.WriteLine(@"
There are currently [0] enemies standing before you
1. Start Battle
2. Add Enemy
3. Check stats
4. Go back", enemies.Count);

            int choice = 0;

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

        protected override int processMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    break;

                case 2:
                    addEnemy();
                    break;

                case 3:
                    break;

                case 4:
                    break;

                default:
                    choice = displayMenu();
                    break;
            }

            return choice;
        }
    }
}
