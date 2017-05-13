using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class Effect
    {
        /// <summary>
        /// The skill that is effected
        /// </summary>
        internal Skill skill
        {
            get;
        }

        /// <summary>
        /// The strength of the effect. Pass a negative value for negative effects
        /// </summary>
        internal int strength
        {
            get;
        }

        /// <summary>
        /// The number of turns the effect lasts
        /// </summary>
        internal int duration
        {
            get;
            set;
        }

        /// <summary>
        /// The position of the entity after the effect
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        internal int[] position
        {
            get;
        }

        public Effect(Skill skill, int strength = 1, int duration = 1)
        {
            this.skill = skill;
            this.strength = strength;
            this.duration = duration;
        }

        public Effect(int[] position)
        {
            this.position = position;
        }
    }
}
