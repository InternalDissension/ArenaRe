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

        static internal bool MoveForwardRight(Character character)
        {
            return true;
        }

        static internal bool MoveForwardLeft(Character character)
        {
            return true;
        }

        static internal bool MoveBackRight(Character character)
        {
            return true;
        }

        static internal bool MoveBackLeft(Character character)
        {
            return true;
        }

        static internal bool Attack(Character character, Character target)
        {
            if (Calculations.calcMoveChance(character, target))
            {
                int damage = Calculations.calcMeleeDamage(character, target);
                Console.WriteLine("Attack hits for " + damage);

                target.health.currentLevel -= damage;
            }
            return true;
        }

        /// <summary>
        /// Casts an ability from character to target 
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        static internal int Cast(Character character, Character target)
        {
            for(int i = 0; i < character.spells.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + character.spells[i].name);
            }

            int choice = Helper.processChoice(true);

            try
            {
                character.spells[choice].target = target;
                for (int i = 0; i < character.spells[choice].effects.Length; i++)
                {
                    Skill skill = Helper.getCharacterSkillList(character).Where(s => s.name == character.spells[choice].effects[choice].skill.name).Single();
                    int strength = (int)Math.Floor(character.spells[i].strength);
                    int duration = character.spells[i].duration;
                    character.spells[i].target.effects.Add(new Effect(skill, strength, duration));
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                //Console.WriteLine("It failed");
                choice = Cast(character, target);
            }

            return choice;
        }
    }
}
