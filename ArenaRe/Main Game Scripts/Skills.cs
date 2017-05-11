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
    class Skills
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

        public Skills(string name)
        {
            this.name = name;
            currentLevel = 5;
            normalLevel = 5;
            maxLevel = 1000;
        }

        public Skills()
        {

        }

        /// <summary>
        /// Initialize all skills used in the game and return the list
        /// </summary>
        /// <returns></returns>
        static internal List<Skills> getSkills()
        {
            List<Skills> skills = new List<Skills>();

            skills.Add(new Skills("Health"));
            skills.Add(new Skills("Magic"));
            skills.Add(new Skills("Speed"));
            skills.Add(new Skills("Strength"));
            skills.Add(new Skills("Intelligence"));
            skills.Add(new Skills("Initiative"));
            skills.Add(new Skills("Reaction"));
            skills.Add(new Skills("Awareness"));
            skills.Add(new Skills("Wisdom"));

            return skills;
        }
    }
}
