using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// Responsible for initializing characters
    /// </summary>
    class CharacterCreator
    {
        public CharacterCreator(Character character)
        {

        }

        /// <summary>
        /// Initializes the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="player">if set to <c>true</c> [player].</param>
        /// <returns></returns>
        internal static Character Initialize(Character character, bool player)
        {

            character.skillPoints = 20;
            character.abilityPoints = 5;

            return character;
        }

        /// <summary>
        /// Adjusts an enemy's stats based off of the current stats of the player
        /// </summary>
        /// <param name="enemy">The enemy.</param>
        /// <param name="player">The player.</param>
        private Character CreateEnemy(Character enemy)
        {
            return enemy;
        }

        private static void distributePoints(Character character)
        {
            
        }
    }
}
