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

        internal static bool tryParse()
        {
            int choice = 0;

            try
            {
                choice =int.Parse(Console.ReadLine());
            }

            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Processes the choice of the user. Returns the number pressed - 1 (user enters 1, returns 0)
        /// </summary>
        /// <returns></returns>
        internal static int processChoice()
        {
            int choice = 0;

            try
            {
                choice = int.Parse(Console.ReadLine()) - 1;
            }

            catch
            {
                DebugLog.invalidInputError("Input must me numerical");
                choice = processChoice();
            }

            return choice;
        }

        internal static void confirmChoice(string choiceName)
        {

        }
    }
}
