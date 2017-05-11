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
        /// The maximum health of an entity
        /// </summary>
        internal int health;

        /// <summary>
        /// The current health of an entity
        /// </summary>
        internal int curHealth;

        /// <summary>
        /// The total strength of an entity
        /// </summary>
        internal int strength;
        
        /// <summary>
        /// The current strength of an entity
        /// </summary>
        internal int curStrength;
    }
}
