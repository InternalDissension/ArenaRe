using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    static class AbilityList
    {
        internal static Ability fireball = new Ability("Fireball", 1.0f, 5, 10, 0, 1, null, 0, 0, false);
        internal static Ability testSpell;
        

        internal static void viewAllAbilities()
        {

        }

        internal static void InitializeAbilityList()
        {
            Object obj = new Object();
            obj.initializeSkills();
            //fireball = new Ability("Fireball", 1.0f, 5, 10, 0, 1, null, 0, 0, false);
            Skill[] skills = new Skill[] { obj.reaction, obj.wisdom, obj.health, obj.intelligence };
            testSpell = new Ability("Test", 1, 5, 5, 5, 1, skills, 5, 5, false);
            //Console.WriteLine("test: " + testSpell.skillEnhance[0].name);
        }
    }
}
