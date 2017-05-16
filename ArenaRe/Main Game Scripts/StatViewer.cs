using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// Contains methods to view the stats of characters
    /// </summary>
    static class StatViewer
    {

        internal static int menu(Character character, int choice  = -1)
        {
            Console.Clear();
            if (choice == -1)
            {
                Console.WriteLine(@"
Stat Menu
1. View Skills
2. View Abilities
3. Go Back");

                choice = Helper.processChoice(false);
            }

            return processChoice(choice, character);
        }

        private static int processChoice(int choice, Character character)
        {
            switch (choice)
            {
                case 1:
                    while (StatViewer.viewSkills(character) != 2);
                    break;

                case 2:
                    while(StatViewer.viewAbilities(character) != 3);
                    break;

                case 3:
                    break;

                default:
                    choice = menu(character);
                    break;
            }

            return choice;
        }

        /// <summary>
        /// Views the skills and abilities of the character
        /// </summary>
        /// <param name="character">The character.</param>
        internal static void viewCharacter(Character character)
        {
            while (menu(character) != 3) ;
        }

        /// <summary>
        /// Outputs the skills of a character.
        /// </summary>
        /// <param name="character">The character.</param>
        internal static int viewSkills(Character character)
        {
            Console.Clear();
            Console.Write("                                             ");
            Console.WriteLine("{0, -24} {1, -24} ", "Skill Name", "Level");
            Console.WriteLine("________________________________________________________________________________________________________________________");

            Skill[] skills = Helper.getCharacterSkillList(character);
            foreach (Skill skill in skills)
            {
                Console.Write("                                             ");
                Console.WriteLine("{0, -24} {1}{2}", skill.name, skill.currentLevel + "/", skill.normalLevel);
            }

            Console.WriteLine("Available Skill Points: " + character.getSkillPoints);
            Console.WriteLine(@"
1. Spend Skill Points
2. Go Back");

            int choice = Helper.processChoice(false);

            switch (choice)
            {
                case 1:
                    CharacterCreator.distributeSkillPoints(character);
                    break;

                case 2:
                    break;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

            return choice;
        }

        internal static void viewAbilityArray(Ability[] abilities)
        {
            Console.Clear();
            Console.Write(" ");
            Console.WriteLine("{0, -20} {1, -8} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12} {7, -12} {8, -12} "
                , "Ability Name", "Level", "Passive", "Strength", "Mana", "Health", "Buildup", "Duration", "Skills");
            Console.WriteLine("________________________________________________________________________________________________________________________");

            foreach (Ability ability in abilities)
            {
                string passive = ability.passive == false ? "No" : "Yes";

                Console.Write(" ");
                Console.Write("{0, -20} {1, -8} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12} {7, -12}"
                , ability.name, ability.getXP, passive, ability.strength, ability.manaCost, ability.healthCost,
                ability.buildUp, ability.duration);

                try
                {
                    for (int i = 0; i < ability.effects.Length; i++)
                    {
                        Console.Write("{0, -120}", ability.effects[i].skill.name);
                    }
                }

                catch
                { Console.WriteLine("No Effects"); }

                Console.WriteLine();

            }
        }

        /// <summary>
        /// Outputs the abilities of a character
        /// </summary>
        /// <param name="character">The character.</param>
        internal static int viewAbilities(Character character)
        {
            Console.Clear();
            Console.Write(" ");
            Console.WriteLine("{0, -20} {1, -8} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12} {7, -12} {8, -12} "
                , "Ability Name", "Level", "Passive", "Strength", "Mana", "Health", "Buildup" , "Duration", "Skills");
            Console.WriteLine("________________________________________________________________________________________________________________________");

            Ability[] abilities = character.spells.ToArray();
            foreach (Ability ability in abilities)
            {
                string passive = ability.passive == false ? "No" : "Yes";

                Console.Write(" ");
                Console.Write("{0, -20} {1, -8} {2, -12} {3, -12} {4, -12} {5, -12} {6, -12} {7, -12}"
                , ability.name, ability.getXP, passive, ability.strength, ability.manaCost, ability.healthCost, 
                ability.buildUp, ability.duration);

                try
                {
                    for (int i = 0; i < ability.effects.Length; i++)
                    {
                        Console.Write("{0, -120}", ability.effects[i].skill.name);
                    }
                }

                catch
                {
                    Console.WriteLine("{0, -120}", "No effects");
                }

                Console.WriteLine();
                
            }

            Console.WriteLine("Available Ability Points: " + character.getAbilityPoints);

            Console.WriteLine(@"
1. Spend Ability Points
2. Acquire New Abilities
3. Go Back");

            int choice = Helper.processChoice(false);

            switch (choice)
            {
                case 1:
                    CharacterCreator.distributeAbilityPoints(character);
                    break;

                case 2:
                    CharacterCreator.addNewAbility(character);
                    break;

                case 3:
                    break;

                default:
                    DebugLog.invalidInputError(choice + " is not valid");
                    break;
            }

            return choice;
        }
    }
}
