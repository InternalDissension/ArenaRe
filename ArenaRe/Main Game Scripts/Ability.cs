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
        internal string name
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
        /// What effects does this ability apply
        /// </summary>
        /// <value>
        /// The skill enhance.
        /// </value>
        internal Effect[] effects;

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

        /// <summary>
        /// How many abilityPoints are required to get the ability
        /// </summary>
        /// <value>
        /// The acquire cost.
        /// </value>
        internal int acquireCost
        {
            get;
        }

        /// <summary>
        /// How many turns the ability lasts. 0 for instant cast
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        internal int duration
        {
            get;
        }

        /// <summary>
        /// How many turns before the spell becomes active
        /// </summary>
        /// <value>
        /// The build up.
        /// </value>
        internal int buildUp
        {
            get;
        }

        /// <summary>
        /// Is the ability passive or does it require activating
        /// </summary>
        /// <value>
        ///   <c>true</c> if passive; otherwise, <c>false</c>.
        /// </value>
        internal bool passive
        {
            get;
        }

        internal Character target;

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
        public Ability(string name, float difficulty, int strength, int manaCost, int healthCost, int acquireCost, 
                        Effect[] effect, int duration, int buildUp, bool passive)
        {
            this.name = name;
            castDifficulty = difficulty;
            this.strength = strength;
            this.manaCost = manaCost;
            this.healthCost = healthCost;
            this.acquireCost = acquireCost;
            this.effects = effect;
            this.duration = duration;
            this.buildUp = buildUp;
            this.passive = passive;
        }

        internal Ability addXPToAbility(Ability ability, int xp)
        {
            ability.xp += xp;
            return ability;
        }
    }
}
