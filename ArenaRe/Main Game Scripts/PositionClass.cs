using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// Used for adding xy to the arena grid
    /// </summary>
    class PositionClass
    {
        /// <summary>
        /// X Position
        /// </summary>
        private int xPosition;

        /// <summary>
        /// Y Position
        /// </summary>
        private int yPostion;

        /// <summary>
        /// Add a new position to the arena grid
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public PositionClass(int x, int y)
        {
            xPosition = x;
            yPostion = y;
        }

        /// <summary>
        /// Initialize position class
        /// </summary>
        public PositionClass()
        {

        }

        /// <summary>
        /// Return the x of this position
        /// </summary>
        internal int getXPosition
        {
            get { return xPosition; }
        }

        /// <summary>
        /// Return the y of this position
        /// </summary>
        internal int getYPosition
        {
            get { return yPostion; }
        }

    }
}
