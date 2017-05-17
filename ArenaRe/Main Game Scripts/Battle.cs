using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Battle starts off with the player facing opponents. The location of the battle takes place in an enclosed
 * space that is determined at the beginning of the fight. The importance of this is explained further down
 * 
 * Fighting is divided into turns and sub-divided into a series of phases: 
 * Action Phase
 * Assessment Phase
 * Reaction Phase
 * Resolution Phase
 * 
 * Characters have a number of "Actions" per turn based on their initiative skill and the momentum in the 
 * current battle. Actions include a player moving, attacking, and casting spells among other things.
 * The character that currently holds the turn gets to select an action during the Action Phase. During the
 * Assessment Phase, various checks are made to determine the success of the action and if any reactions are given.
 * During the reaction phase, characters may choose from a series of reactions depending on the original action
 * Reactions include moving, counter-attacking, counter-casting, or spell charging.
 * During the resolution phase, all damage and movements are resolved and the character that holds the turn may
 * take their next Action if they have one.
 * 
 * The objective is simple. The player will engage their opponents until either they are defeated or flee, or until
 * the player does the same.
 * 
 * The arena tracks the distance between entities and the environment. Entities can freely move or
 * can take actions against designated targets if within proximity.
 * Free Actions consist of: Forward, backward, left, right, defending, examining surroundings, running in a direction, 
 * or casting self-targeted abilities
 * Designated Actions consist of: Stepping through an opponent, stepping to the side, back stepping, attacking,
 * and casting targeted abilities
 * 
 * All designated actions require checks and can fail either due to poor skill or good defense
 */

namespace ArenaRe
{
    class Battle
    {
        /// <summary>
        /// The name of the current character's turn
        /// </summary>
        string c_Turn;
        static internal Arena arena;
        Character player;
        List<Character> enemies;

        public Battle()
        {
        }

        public Battle(Character player, List<Character> enemies)
        {
            Console.Clear();
            arena = new Arena();
            this.player = player;
            this.enemies = enemies;
            showBattleStats();
            Console.ReadLine();
        }

        private void showBattleStats()
        {
            Console.WriteLine("{0, 0}{1}", "Player: ", player.name);
            Console.WriteLine("{0, 0} {1, 0} {2, 0} {3} ", "Health:", player.health.currentLevel, "Mana:", player.magic.currentLevel);
            Console.WriteLine();
            int x = 0;

            for (int i = 0; i < enemies.Count; i++)
            {
                Console.Write("{0, -26}", enemies[i].name);

                if (i == 0 || (i + 1) % 4 != 0 && i != enemies.Count - 1)
                    continue;

                Console.WriteLine();

                while (x <= i)
                {
                    Console.Write("{0, 0}{1, 0}  {2, 0}{3, -8} ", "Health:", enemies[x].health.currentLevel, "Mana:", enemies[x].magic.currentLevel);
                    x++;
                }

                Helper.space(2);
            }
        }

        private void battleChoice()
        {

        }

    }
}
