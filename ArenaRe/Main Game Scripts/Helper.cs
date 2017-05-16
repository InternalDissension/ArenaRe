﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// Contains various functions that make life easier for the assembly
    /// </summary>
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
        internal static Skill[] getCharacterSkillList(Character character)
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
    }
}
