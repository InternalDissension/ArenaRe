using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// Used during AI Character Creation to add more variety to characters
    /// </summary>
    class ProbabilityHelper
    {
        internal float[] actions;
        internal float[] goals;
        /// <summary>
        /// Initializes the probability of abilities being selected
        /// </summary>
        private void initializeAbilities()
        {
            int total = Helper.getAbilityList().Length;
            for (int i = 0; i < Helper.getAbilityList().Length; i++)
            {
                Helper.getAbilityList()[i].probability = 100.0f / total;
            }
        }

        private void intializeActions(Enum action)
        {
            actions = new float[action.GetType().GetEnumValues().Length];
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i] = 100.0f / actions.Length;
            }
        }

        private void initializeGoals(Enum goal)
        {
            goals = new float[goal.GetType().GetEnumValues().Length];

            for (int i = 0; i < goals.Length; i++)
                goals[i] = 100.0f / goals.Length;
        }
    }
}
