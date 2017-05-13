using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ArenaRe
{
    /// <summary>
    /// Contains functions for initializing skills and adding abilities to characters
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
            character.addSkillPoint(20);
            character.addAbilityPoint(5);

            return character;
        }

        /// <summary>
        /// Adjusts an enemy's stats based off of the current stats of the player
        /// </summary>
        /// <param name="enemy">The enemy.</param>
        /// <param name="player">The player.</param>
        private Character CreateEnemy(Character enemy, Character player)
        {
            return enemy;
        }

        internal static void distributeSkillPoints(Character character)
        {

            Skill[] skillList = Helper.getCharacterSkillList(character);

            Console.WriteLine(skillList.Length + " Printing list of skills");
            for (int i = 0; i < skillList.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + skillList[i].name);
            }

            Console.ReadLine();
        }

        internal static void distributeAbilityPoints(Character character)
        {
            for (int i = 0; i < character.spells.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + character.spells[i].name);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Outputs the list of abilities not in the character's spells List
        /// and allows the adding of them provided the character has ability points
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        internal static int addNewAbility(Character character)
        {
            Ability[] abilityList = Helper.getAbilityList();

            //Iterate through abilityList variable and list all ability names
            for (int i = 0; i < abilityList.Length; i++)
            {
                if (!character.spells.Contains(abilityList[i]))     //If the character doesn't have the ability
                    Console.WriteLine((i + 1) + ": " + abilityList[i].name);   //List it
            }

            int choice = Helper.processChoice();

            try
            {
                //Output choice to the user
                Console.WriteLine("Are you sure you want to add: " + abilityList[choice] + "? (y/n)");
            }

            catch
            {
                DebugLog.invalidInputError(choice + " is not a valid input");
                choice = addNewAbility(character);
            }

            //If user enters y
            if (Console.ReadLine() == "y")

                //If the user has enough ability points to acquire the ability, add it
                if (character.getAbilityPoints >= abilityList[choice].acquireCost)
                    character.spells.Add(abilityList[choice]);

                //Otherwise let the user know that they have insufficient points
                else
                    Console.WriteLine("Not enough ability points");
            //Else recall the function
            else
                choice = addNewAbility(character);

            return choice;
        }
    }
}
