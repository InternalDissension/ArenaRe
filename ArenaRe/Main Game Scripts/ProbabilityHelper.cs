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
        List<int> goalChance;
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

        private void changeActionProbability(int action, float change)
        {
            //If the change in probability brings the value above 100, alter the change so that the probability is 100
            if (change + actions[action] > 100)
                change = 100 - actions[action];

            //Increase the chance of the probability
            actions[action] += change;

            //Divide the change by the number of actions and disperse it to the other actions
            float disperse = change / (actions.Length - 1);
            for(int i = 0; i <actions.Length; i++)
            {
                if (i == action)
                    continue;

                actions[i] -= disperse;
            }
        }

        private void changeGoalProbability(int goal, float change)
        {
            //If the change in probability brings the value above 100, alter the change so that the probability is 100
            if (change + goals[goal] > 100)
                change = 100 - goals[goal];

            //Increase the chance of the probability
            goals[goal] += change;

            //Divide the change by the number
            float disperse = change / (goals.Length - 1);
            for (int i = 0; i < goals.Length; i++)
            {
                if (i == goal)
                    continue;

                goals[i] -= disperse;
            }
        }

        /// <summary>
        /// Gets a new goal for the AI based on probability
        /// </summary>
        /// <returns></returns>
        private int getGoal()
        {
            Helper.Shuffle(goalChance);
            Helper.Shuffle(goalChance);

            float x = 0;
            int value = Helper.randomValue(1, 101);

            return goalChance[value];

           /* for (int i = 0; i < goals.Length; i++)
            {
                x += goals[i];
                if (value < x)
                    return i;
            }*/
        }

        /// <summary>
        /// Initializes the goalChance list so that it reflects the probability of all goals
        /// </summary>
        private void initializeGoalChance()
        {
            goalChance = new List<int>();

            for (int i = 0; i < goals.Length; i++)
            {
                int chance = (int)Math.Round(goals[i]);

                for (int x = 0; x < chance; x++)
                    goalChance.Add(i);
            }
        }
    }
}
