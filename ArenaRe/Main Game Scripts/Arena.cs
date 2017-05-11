using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class Arena
    {
        /// <summary>
        /// The northern boundary of the battle
        /// </summary>
        internal int arenaYPlus;

        /// <summary>
        /// The southern boundary of the battle
        /// </summary>
        internal int arenaYMinus;

        /// <summary>
        /// The eastern boundary of the battle
        /// </summary>
        internal int arenaXPlus;

        /// <summary>
        /// The western boundary of the battle
        /// </summary>
        internal int arenaXMinus;

        /// <summary>
        /// The list of positions the arena contains
        /// </summary>
        IDictionary<PositionClass, Object> positions;

        /// <summary>
        /// Create an arena of specified size
        /// </summary>
        /// <param name="yPlus"></param>
        /// <param name="yMinus"></param>
        /// <param name="xPlus"></param>
        /// <param name="xMinus"></param>
        public Arena(int yPlus, int yMinus, int xPlus, int xMinus)
        {
            arenaXPlus = xPlus;             //Set eastern boundary to value
            arenaXMinus = xMinus;           //Set western boundary to value

            arenaYPlus = yPlus;             //Set northern boundary to value
            arenaYMinus = yMinus;           //Set southern boundary to value

            positions = buildArena();       //Store the positions between boundaries
        }

        /// <summary>
        /// Create an arena with its default size
        /// </summary>
        public Arena()
        {
            arenaXPlus = 10;            //Set eastern boundary
            arenaXMinus = -10;          //Set western boundary

            arenaYPlus = 10;            //Set northern boundary
            arenaYMinus = -10;          //Set southern boundary

            positions = buildArena();   //Store positions between boundaries
        }

        /// <summary>
        /// Checks if a position is occupied. Returns true if it is. False if it is NOT
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        internal bool checkPosition(PositionClass position)
        {
            //If the object at the specified position is not null, return true
            if (positions[position] != null)
                return true;

            return false;
        }

        /// <summary>
        /// Returns the object occupying a position if one exists, otherwise returns null
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        internal Object getObjectAtPosition(PositionClass position)
        {
            //If there is an object here, return it
            if (positions[position] != null)
                return positions[position];

            //Print the given position to the console if debugging and return null
            DebugLog.Log(s => DebugLog.NoObjectAtPosition(position.getXPosition + "|" + position.getYPosition) );
            return null;
        }

        /// <summary>
        /// Returns all positions in arena
        /// </summary>
        internal IDictionary<PositionClass, Object> getPositions
        {
            get { return positions; }
        }

        /// <summary>
        /// Returns a list of positions that are used as the arena of the battle
        /// </summary>
        /// <returns></returns>
        private IDictionary<PositionClass, Object> buildArena()
        {
            IDictionary<PositionClass, Object> positions = new Dictionary<PositionClass, Object>();

            for (int i = arenaXMinus; i < arenaXPlus; i++)
                for (int x = arenaYMinus; x < arenaYPlus; x++)
                    positions.Add(new PositionClass(i, x), null);

            return positions;
        }
    }
}
