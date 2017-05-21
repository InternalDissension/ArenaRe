using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class BattleMenu : Menu
    {
        Character player;

        private List<Character> enemies = new List<Character>();

        public BattleMenu(Character player)
        {
            Console.Clear();
            this.player = player;
            while (displayMenu() != 4)
                continue;
        }

        private Character addEnemy()
        {
            Character enemy = new Character(false);
            enemy.name = "Enemy " + (enemies.Count + 1);
            enemies.Add(enemy);
            return enemy;
        }

        protected override int displayMenu()
        {
            Console.WriteLine(@"
There are currently {0} enemies standing before you
1. Start Battle
2. Add Enemy
3. Check stats
4. Go back", enemies.Count);

            int choice = 0;

            choice = Helper.processChoice(false);

            return processMenuChoice(choice);
        }

        protected override int processMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    if (enemies.Count > 0)
                        new Battle(player, enemies);
                    break;

                case 2:
                    addEnemy();
                    break;

                case 3:
                    StatViewer.viewCharacter(player);
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
