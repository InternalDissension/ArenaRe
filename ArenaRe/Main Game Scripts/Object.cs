using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// This class serves as a partial template for items and characters. It's main purpose is for the
    /// classification of all entities that occupy the Arena to considered as "Objects"
    /// </summary>
    class Object
    {
        /// <summary>
        /// The name of the entity
        /// </summary>
        internal string name;

        /// <summary>
        /// The health of an entity
        /// </summary>
        internal Skill health;

        /// <summary>
        /// Determines the amount of abilities an entity can cast
        /// </summary>
        internal Skill magic;

        /// <summary>
        /// The strength of an entity
        /// </summary>
        internal Skill strength;

        /// <summary>
        /// Determines move order and number of actions per turn
        /// </summary>
        internal Skill initiative;

        /// <summary>
        /// Determines movement distance and influences reaction
        /// </summary>
        internal Skill speed;

        /// <summary>
        /// Determines the likelihood of gaining counter actions
        /// </summary>
        internal Skill reaction;

        /// <summary>
        /// Determines how much xp an entity gets for using abilities
        /// </summary>
        internal Skill intelligence;

        /// <summary>
        /// Determines how well an entity can alter the momentum of a battle
        /// </summary>
        internal Skill wisdom;

        /// <summary>
        /// Determines how likely an entity is to notice the environment
        /// </summary>
        internal Skill awareness;

        /// <summary>
        /// Initializes variables used for child classes. Contains the complete list of skills in constructor
        /// </summary>
        public Object()
        {
        }

        internal void initializeSkills()
        {
            health = new Skill("Health", 100);
            strength = new Skill("Strength");
            magic = new Skill("Magic", 50);
            speed = new Skill("Speed");
            intelligence = new Skill("Intelligence");
            reaction = new Skill("Reaction");
            initiative = new Skill("Initiative");
            awareness = new Skill("Awareness");
            wisdom = new Skill("Wisdom");
        }
    }
}
