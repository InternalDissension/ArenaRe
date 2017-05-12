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

            character.addSkillPoint(20);
            character.addAbilityPoint(5);

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
            for (int i = 0; i < character.spells.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + character.spells[i].spellName);
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
            //Used to get the fields in AbilityList.cs
            Type a = typeof(AbilityList);

            //Used to correctly identify the access modifiers in AbilityList
            System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Static 
                | System.Reflection.BindingFlags.NonPublic;

            //Gets every ability that has been created in AbilityList
            Ability[] abilityList = a.GetFields(flags).Where(f => f.FieldType == typeof(Ability)).Select(f => (Ability)f.GetValue(a)).ToArray();

            //Iterate through abilityList variable
            for (int i = 0; i < abilityList.Length; i++)
            {
                if (!character.spells.Contains(abilityList[i]))     //If the character doesn't have the ability
                    Console.WriteLine((i + 1) + ": " + abilityList[i].spellName);   //List it
            }

            int choice = 0; //Initialize choice variable

            //Try to convert the user input into a number
            try
            {
                choice = int.Parse(Console.ReadLine()) - 1;
            }

            //If the input is not a number, output a message to the user and recursively call the function
            catch
            {
                Console.WriteLine("Invalid input. Input must be numerical");
                Console.ReadLine();
                choice = addNewAbility(character);
            }

            //Output choice to the user
            Console.WriteLine("Are you sure you want to add: " + abilityList[choice] + "? (y/n)");

            //If user enters y
            if (Console.ReadLine() == "y")

                //Try to add the ability choice that the user input
                try
                {
                    //If the user has enough ability points to acquire the ability, add it
                    if (character.getAbilityPoints >= abilityList[choice].acquireCost)
                        character.spells.Add(abilityList[choice]);

                    //Otherwise let the user know that they have insufficient points
                    else
                        Console.WriteLine("Not enough ability points");
                }

                //If the ability choice is invalid, output a message and recursively call the function
                catch
                {
                    DebugLog.Log(DebugLog.invalidInputError, "The choice input does not exist.");
                    choice = addNewAbility(character);
                }
            else
                choice = addNewAbility(character);

            return choice;
        }
    }
}
