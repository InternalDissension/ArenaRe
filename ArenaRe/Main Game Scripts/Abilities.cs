using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    abstract class Abilities
    {
        /// <summary>
        /// Name of the spell
        /// </summary>
        internal abstract string spellName
        {
            get;
        }

        /// <summary>
        /// How difficult is this spell to cast?
        /// </summary>
        internal abstract float castDifficulty
        {
            get;
        }

        /// <summary>
        /// How much damage does this spell do before resistance?
        /// </summary>
        internal abstract int strength
        {
            get;
        }

        /// <summary>
        /// How much mana does the spell cost?
        /// </summary>
        internal abstract int manaCost
        {
            get;
        }

        /// <summary>
        /// How much health does the spell cost?
        /// </summary>
        internal abstract int healthCost
        {
            get;
        }

        /// <summary>
        /// How much experience does the entity have in this spell?
        /// </summary>
        internal int xp = 0;

        /// <summary>
        /// How much does experience increase the strength of a spell?
        /// </summary>
        internal float xpModifier
        {
            get { return xp * 0.82f; }
        }

        /// <summary>
        /// How easy is the spell to learn?
        /// </summary>
        internal abstract float xpRate
        {
            get;
        }
    }
}
