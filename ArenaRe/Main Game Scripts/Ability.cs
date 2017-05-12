using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class Ability
    {
        /// <summary>
        /// Name of the spell
        /// </summary>
        internal string spellName
        {
            get;
        }

        /// <summary>
        /// How difficult is this spell to cast?
        /// </summary>
        internal float castDifficulty
        {
            get;
        }

        /// <summary>
        /// How much damage does this spell do before resistance?
        /// </summary>
        internal int strength
        {
            get;
        }

        /// <summary>
        /// How much mana does the spell cost?
        /// </summary>
        internal int manaCost
        {
            get;
        }

        /// <summary>
        /// How much health does the spell cost?
        /// </summary>
        internal int healthCost
        {
            get;
        }

        internal int acquireCost
        {
            get;
        }

        /// <summary>
        /// How much experience does the entity have in this spell?
        /// </summary>
        private int xp = 0;

        internal int getXP
        {
            get { return xp; }
        }

        /// <summary>
        /// How much does experience increase the strength of a spell?
        /// </summary>
        internal float xpModifier
        {
            get { return xpModifier; }
            set { xpModifier = value; }
        }

        /// <summary>
        /// How easy is the spell to learn?
        /// </summary>
        internal float xpRate
        {
            get { return xpRate; }
            set { xpRate = value; }
        }

        /// <summary>
        /// Creates a new ability
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="difficulty">The cast difficulty</param>
        /// <param name="strength">The strength</param>
        /// <param name="manaCost">The mana cost</param>
        /// <param name="healthCost">The health cost</param>
        public Ability(string name, float difficulty, int strength, int manaCost, int healthCost, int acquireCost)
        {
            spellName = name;
            castDifficulty = difficulty;
            this.strength = strength;
            this.manaCost = manaCost;
            this.healthCost = healthCost;
            this.acquireCost = acquireCost;
        }

        internal Ability addXPToAbility(Ability ability, int xp)
        {
            ability.xp += xp;
            return ability;
        }
    }
}
