using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// This class keeps track of all skills in the game.
    /// Add new skills to the getSkills method
    /// </summary>
    class Skill
    {
        /// <summary>
        /// The name of the skill
        /// </summary>
        internal string name;

        /// <summary>
        /// The current level of the skill
        /// </summary>
        internal int currentLevel;

        /// <summary>
        /// The normal level of the skill before depletion
        /// </summary>
        internal int normalLevel;

        /// <summary>
        /// The maximum level of the skill
        /// </summary>
        internal int maxLevel;

        /// <summary>
        /// Creates a new skill by name and gives it a value of 5.
        /// </summary>
        /// <param name="name">The name.</param>
        public Skill(string name)
        {
            this.name = name;
            currentLevel = 5;
            normalLevel = 5;
            maxLevel = 1000;
        }

        /// <summary>
        /// Creates a new skill by name and sets its value to curLevel
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="curLevel">The current level.</param>
        public Skill(string name, int curLevel)
        {
            this.name = name;
            currentLevel = curLevel;
            normalLevel = curLevel;
            maxLevel = 1000;
        }

        public Skill()
        {
        }
    }
}
