using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ArenaRe
{
    /// <summary>
    /// Contains various functions that make life easier for the assembly
    /// </summary>
    static class Helper
    {
        /// <summary>
        /// Used for random number generation
        /// </summary>
        private static Random random = new Random(Guid.NewGuid().GetHashCode());

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

        /// <summary>
        /// Returns true if an input is an integer
        /// </summary>
        /// <returns></returns>
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
        /// Displays a set of choices to the player and returns the input of the chosen one
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        internal static int getChoice(string message, string[] options)
        {
            Console.WriteLine(message);

            for (int i = 0; i < options.Length; i++)
                Console.WriteLine((i + 1) + options[i]);

            return processChoice(false);
        }

        /// <summary>
        /// Processes the choice of the user. Returns the number pressed - 1 if startAtZero is true
        /// </summary>
        /// <returns></returns>
        internal static int processChoice(bool startAtZero)
        {
            int choice = 0;

            try
            {
                choice = int.Parse(Console.ReadLine());
            }

            catch
            {
                DebugLog.invalidInputError("Input must me numerical");
                choice = processChoice(startAtZero);
            }

            if (startAtZero)
                return choice - 1;

            return choice;
        }

        /// <summary>
        /// Returns the skills of a character in an array
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        internal static Skill[] getCharacterSkillList(Object character)
        {
            System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
            return character.GetType().GetFields(flags).Where(f => f.FieldType == typeof(Skill)).Select(f => (Skill)f.GetValue(character)).ToArray();
        }

        /// <summary>
        /// Returns all skills in an array
        /// </summary>
        /// <returns></returns>
        internal static Skill[] getAllSkillList()
        {
            Type t = typeof(Object);

            System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.NonPublic;

            return t.GetFields(flags).Where(f => f.FieldType == typeof(Skill)).Select(f => (Skill)f.GetValue(t)).ToArray();
        }

        /// <summary>
        /// Returns all abilities in an array
        /// </summary>
        /// <returns></returns>
        internal static Ability[] getAbilityList()
        {
            //Used to get the fields in AbilityList.cs
            Type a = typeof(AbilityList);

            //Used to correctly identify the access modifiers in AbilityList
            System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.NonPublic;

            //Gets every ability that has been created in AbilityList
            return a.GetFields(flags).Where(f => f.FieldType == typeof(Ability)).Select(f => (Ability)f.GetValue(a)).ToArray();
        }

        /// <summary>
        /// Spaces text vertically by number of spaces.
        /// </summary>
        /// <param name="numOfSpaces">The number of spaces.</param>
        internal static void space(int numOfSpaces)
        {
            for (int i = 0; i < numOfSpaces + 1; i++)
                Console.WriteLine();
        }

        /// <summary>
        /// Calculates the number of actions a character gets on their turn.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="enemies">The enemies.</param>
        /// <returns></returns>
        internal static int calculateActions(Character entity, Character[] enemies)
        {
            int totalEnemyInitiative = 0;
            int diffThreshold = 5;          //Actions increase by 1 for every (this value) points over enemy initiative

            for (int i = 0; i < enemies.Length; i++)
            {
                totalEnemyInitiative += enemies[i].initiative.currentLevel;
            }

            int actions = 1;

            while (entity.initiative.currentLevel >= totalEnemyInitiative + diffThreshold)
            {
                totalEnemyInitiative -= diffThreshold;
                actions++;
            }

            return actions;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Helper.randomValue(0, list.Count);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
