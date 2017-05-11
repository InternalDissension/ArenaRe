﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class ActionHandler : Battle
    {
        /// <summary>
        /// Attempts to move the character's position forward
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        static internal bool MoveForward(Character character)
        {
            if (character.xPosition == arena.arenaYPlus)
            {
                Console.WriteLine("This is as forward as it gets");
                return false;
            }

            return true;
        }

        static internal bool MoveBackward(Character character)
        {
            return true;
        }

        static internal bool MoveLeft(Character character)
        {
            return true;
        }

        static internal bool MoveRight(Character character)
        {
            return true;
        }

        static internal bool Attack(Character character, Character target)
        {
            return true;
        }

        /// <summary>
        /// Returns whether a designated movement is successful or stopped
        /// </summary>
        /// <param name="character"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static internal bool calcMoveChance(Character character, Character target)
        {
            float moveChance = 50 
                + ((character.curInitiative - target.curReaction) 
                + (character.curStrength - target.curStrength)
                + (character.curSpeed - target.curSpeed));

            if (Helper.randomValue(1, 101) <= moveChance)
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
                + (((character.curReaction / 2) - (target.curInitiative + target.curReaction / 4))
                + (character.curStrength - target.curStrength)
                + (character.curSpeed - target.curSpeed));

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
                ((character.curWisdom + character.curReaction) 
                - (target.curWisdom + target.curReaction));

            if (Helper.randomValue(1,101) <= punishChance)
            {
                if (Helper.randomValue(1, 101) <= punishChance)
                    return 2;

                return 1;
            }

            return 0;
        }
    }
}