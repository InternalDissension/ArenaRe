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

        internal static void distributePoints(Character character)
        {
            System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
            Skills[] skillList = character.GetType().GetFields(flags).Where(f => f.FieldType == typeof(Skills)).Select(f => (Skills)f.GetValue(character)).ToArray();

            Console.WriteLine(skillList.Length + " Printing list of skills");
            for (int i = 0; i < skillList.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + skillList[i].name);
            }

            Console.ReadLine();
        }
    }
}
