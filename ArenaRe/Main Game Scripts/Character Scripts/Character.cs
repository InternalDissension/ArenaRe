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

        /// <summary>
        /// The skill points the entity can spend on increasing skills
        /// </summary>
        internal int skillPoints;

        /// <summary>
        /// The ability points the entity can spend on learning abilities
        /// </summary>
        internal int abilityPoints;

        /// <summary>
        /// The list of abilities the entity can use
        /// </summary>
        internal List<Abilities> spells;

        /// <summary>
        /// Determines move order and number of actions per turn
        /// </summary>
        internal Skills initiative;

        /// <summary>
        /// Determines movement distance and influences reaction
        /// </summary>
        internal Skills speed;

        /// <summary>
        /// Determines the amount of abilities an entity can cast
        /// </summary>
        internal Skills magic;

        /// <summary>
        /// Determines the likelihood of gaining counter actions
        /// </summary>
        internal Skills reaction;

        /// <summary>
        /// Determines how much xp an entity gets for using abilities
        /// </summary>
        internal Skills intelligence;

        /// <summary>
        /// Determines how well an entity can alter the momentum of a battle
        /// </summary>
        internal Skills wisdom;

        /// <summary>
        /// Determines how likely an entity is to notice the environment
        /// </summary>
        internal Skills awareness;

        /// <summary>
        /// The x location of the entity on the arena grid
        /// </summary>
        internal float xPosition;

        /// <summary>
        /// The y location of the entity on the arena grid
        /// </summary>
        internal float yPosition;

        public Character()
        {
            initialize();
            CharacterCreator.distributePoints(this);
        }

        /// <summary>
        /// Initializes the character
        /// </summary>
        private void initialize()
        {
            this.health = new Skills("Health", 100);
            this.strength = new Skills("Strength");

            magic = new Skills("Magic", 50);
            speed = new Skills("Speed");
            intelligence = new Skills("Intelligence");
            reaction = new Skills("Reaction");
            initiative = new Skills("Initiative");
            awareness = new Skills("Awareness");
            wisdom = new Skills("Wisdom");
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
