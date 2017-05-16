using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    static class AbilityList
    {
        internal static Ability fireball;

        internal static Ability testSpell;

        static Object obj = new Object();
        
        internal static void viewAllAbilities()
        {

        }

        /// <summary>
        /// Initializes all abilities that enhance skills.
        /// </summary>
        internal static void InitializeAbilityList()
        {
            obj.initializeSkills();

            fireball = new Ability("Fireball", 1.0f, 5, 10, 0, 1, null, 0, 0, false);
            initializeTestSpell();
        }

        private static void initializeTestSpell()
        {
            Effect[] e = new Effect[] { EffectList.effectSkill(obj.health) };
            testSpell = new Ability("Test", 1, 5, 5, 5, 1, e, 1, 5, false);
        }

        private static void initializeFireball()
        {
            Effect[] e = new Effect[] { new Effect(obj.health) };
        }

        internal static void initializeTeleport()
        {

        }


    }
}
