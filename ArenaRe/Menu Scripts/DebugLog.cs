using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// A static class containing all debug/error messages for easier implementation
    /// </summary>
    static class DebugLog
    {
        public static void Log(Action<string> function)
        {
        }
        public static bool debugging = true;

        /// <summary>
        /// Outputs a message saying an object is not at a position
        /// </summary>
        internal static void NoObjectAtPosition(string position)
        {
            Console.WriteLine("INTERNAL ERROR: THERE IS NO OBJECT AT THIS POSITION: " + position);
        }
    }
}
