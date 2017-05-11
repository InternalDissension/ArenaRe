using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        internal static void distributeSkillPoints(Character character)
        {
            System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
            Skill[] skillList = character.GetType().GetFields(flags).Where(f => f.FieldType == typeof(Skill)).Select(f => (Skill)f.GetValue(character)).ToArray();

            Console.WriteLine(skillList.Length + " Printing list of skills");
            for (int i = 0; i < skillList.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + skillList[i].name);
            }

            Console.ReadLine();
        }

        internal static void distributeAbilityPoints(Character character)
        {
            Type a = typeof(AbilityList);
            System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic;
            Ability[] abilityList = a.GetFields(flags).Where(f => f.FieldType == typeof(Ability)).Select(f => (Ability)f.GetValue(a)).ToArray();

            for (int i = 0; i < abilityList.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + abilityList[i].spellName);
            }

            Console.ReadLine();
        }
    }
}
