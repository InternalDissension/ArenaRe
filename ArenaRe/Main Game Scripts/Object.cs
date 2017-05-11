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
        internal Skills health;

        /// <summary>
        /// The strength of an entity
        /// </summary>
        internal Skills strength;
    }
}
