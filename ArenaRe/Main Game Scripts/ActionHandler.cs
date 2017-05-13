using System;
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
                + ((character.initiative.currentLevel - target.reaction.currentLevel) 
                + (character.strength.currentLevel - target.strength.currentLevel)
                + (character.speed.currentLevel - target.speed.currentLevel));

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

            if (Helper.randomValue(1,101) <= punishChance)
            {
                if (Helper.randomValue(1, 101) <= punishChance)
                    return 2;

                return 1;
            }

            return 0;
        }

        static internal int Cast(Character character)
        {
            for(int i = 0; i < character.spells.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + character.spells[i].name);
            }

            int choice = Helper.processChoice();

            try
            {
                character.spells[choice].target = character;
                for (int i = 0; i < character.spells[choice].effects.Length; i++)
                {
                    Skill skill = Helper.getCharacterSkillList(character).Where(s => s.name == character.spells[choice].effects[choice].skill.name).Single();
                    int strength = character.spells[i].strength;
                    int duration = character.spells[i].duration;
                    character.spells[i].target.effects.Add(new Effect(skill, strength, duration));
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine("It failed");
                choice = Cast(character);
            }

            return choice;
        }
    }
}
