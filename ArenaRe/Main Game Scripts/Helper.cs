using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class Helper
    {
        /// <summary>
        /// Used for random number generation
        /// </summary>
        private static Random random;

        /// <summary>
        /// Initialize variables for helper functions
        /// </summary>
        public Helper()
        {
            random = new Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// Returns a random float between a max and min
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        internal static float randomValue(float min, float max)
        {
            return (float)random.NextDouble() * (min - max) + min;
        }

        /// <summary>
        /// Returns a random int between a max and min
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        internal static int randomValue(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
