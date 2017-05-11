using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Battle starts off with the player facing opponents. The location of the battle takes place in an enclosed
 * space that is determined at the beginning of the fight. The importance of this is explained further down
 * 
 * Fighting is turned based, meaning the player will have the opportunity to take a series of actions
 * followed by the opponents. It is possible for the player to take more than one action depending on
 * their initiative skill and it is also possible for players to gain extra actions during opponent moves
 * based on their reaction skill.
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
        static internal Arena arena;

        public Battle()
        {
        }

        public Battle(Character player, List<Character> enemies)
        {
            arena = new Arena();
        }

        private void showBattleStats()
        {
            Console.WriteLine(@"");
        }

        private void battleChoice()
        {

        }

    }
}
