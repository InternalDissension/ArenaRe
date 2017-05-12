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
        public static bool debugging = true;

        public static void Log(Action<string> function, string message)
        {
            if (debugging)
                function(message);
        }

        public static void Error(Action<string> function, string message)
        {
            function(message);
        }


        /// <summary>
        /// Outputs a message saying an object is not at a position
        /// </summary>
        internal static void NoObjectAtPositionLog(string position)
        {
            Console.WriteLine("INTERNAL ERROR: THERE IS NO OBJECT AT THIS POSITION: " + position);
        }

        internal static void invalidInputError(string message)
        {
            Console.WriteLine("Invalid Input. " + message);
        }
    }
}
