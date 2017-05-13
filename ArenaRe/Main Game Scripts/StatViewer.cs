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

        /// <summary>
        /// Outputs the skills of a character.
        /// </summary>
        /// <param name="character">The character.</param>
        internal static void viewSkills(Character character)
        {
            Console.Write("                                             ");
            Console.WriteLine("{0, -24} {1, -24} ", "Skill Name", "Level");
            Console.WriteLine("________________________________________________________________________________________________________________________");

            Skill[] skills = Helper.getCharacterSkillList(character);
            foreach (Skill skill in skills)
            {
                Console.Write("                                             ");
                Console.WriteLine("{0, -24} {1}{2}", skill.name, skill.currentLevel + "/", skill.normalLevel);
            }
        }

        /// <summary>
        /// Outputs the abilities of a character
        /// </summary>
        /// <param name="character">The character.</param>
        internal static void viewAbilities(Character character)
        {
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

                for (int i = 0; i < ability.effects.Length; i++)
                {
                    Console.Write("{0, -120}", ability.effects[i].skill.name);
                }

                Console.WriteLine();
            }
        }
    }
}
