using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class Calculations
    {
        /// <summary>
        /// Returns whether a designated movement is successful or stopped
        /// </summary>
        /// <param name="character"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static internal bool calcMoveChance(Character character, Character target)
        {
            float moveChance = 50
                + ((character.initiative.currentLevel - target.reaction.currentLevel)
                + (character.strength.currentLevel - target.strength.currentLevel)
                + (character.speed.currentLevel - target.speed.currentLevel));

            if (Helper.randomValue(1, 101) <= moveChance)
                return true;

            return false;
        }

        /// <summary>
        /// Returns whether an entity is granted a reaction
        /// </summary>
        /// <returns></returns>
        static internal bool calcReaction(Character entity, Character initiator)
        {
            float reactionChance = 35
                + ((initiator.initiative.currentLevel - entity.reaction.currentLevel));

            if (Helper.randomValue(1.0f, 101.0f) <= reactionChance)
                return true;

            return false;
        }

        /// <summary>
        /// Returns whether a recover is successful
        /// </summary>
        /// <param name="character"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static internal bool calcMoveFailRecover(Character character, Character target)
        {
            float recoverChance = 50
                + (((character.reaction.currentLevel / 2)
                - (target.initiative.currentLevel
                + target.reaction.currentLevel / 4))
                + (character.strength.currentLevel - target.strength.currentLevel)
                + (character.speed.currentLevel - target.speed.currentLevel));

            if (Helper.randomValue(1, 101) <= recoverChance)
                return true;

            return false;
        }

        /// <summary>
        /// Calculates the change in momentum if an entity fails to recover.
        /// 0 = nothing happens, 1 = lose an action, 2 = lose action and target gains immediate action
        /// </summary>
        /// <param name="character"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static internal int calcPunish(Character character, Character target)
        {
            float punishChance = 50 +
                ((character.wisdom.currentLevel + character.reaction.currentLevel)
                - (target.wisdom.currentLevel + target.reaction.currentLevel));

            if (Helper.randomValue(1, 101) <= punishChance)
            {
                if (Helper.randomValue(1, 101) <= punishChance)
                    return 2;

                return 1;
            }

            return 0;
        }

        static internal int calcMeleeDamage(Character character, Character target)
        { 
            return character.strength.currentLevel - target.defense.currentLevel;
        }

        static internal void applyEffect(Effect effect, Character target)
        {
            target.addEffect(effect);
        }
    }
}
