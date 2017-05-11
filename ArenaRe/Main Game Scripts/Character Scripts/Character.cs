using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// Contains the outline of everything that defines a character.
    /// </summary>
    /// <seealso cref="ArenaRe.Object" />
    class Character : Object
    {

        internal int skillPoints;
        internal int abilityPoints;
        
        internal List<Abilities> spells;
        internal List<Skills> skills;

        internal float xPosition;
        internal float yPosition;

        public Character()
        {
           
            
        }

        private void initialize()
        {
            skills = Skills.getSkills();
            skills.Find(s => s.name == "Health").currentLevel = 100;
            skills.Find(s => s.name == "Magic").currentLevel = 50;

        }

        /// <summary>
        /// Returns an array of classes that inherit the Abilities class.
        /// This should only be performed once during runtime
        /// </summary>
        /// <returns></returns>
        public Abilities[] getAllAbilities()
        {
            IEnumerable<Abilities> abilities = typeof(Abilities).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Abilities)) && !t.IsAbstract).Select(t => (Abilities)Activator.CreateInstance(t));
            return abilities.ToArray();
        }
    }
}
