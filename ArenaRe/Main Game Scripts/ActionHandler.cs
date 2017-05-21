using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    static class ActionHandler
    {
        /// <summary>
        /// Attempts to move the character's position forward
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        static internal bool MoveForward(Character character, int arenaYPlus)
        {
            if (character.yPosition == arenaYPlus)
            {
                Console.WriteLine("This is as forward as it gets");
                return false;
            }

            else
                character.yPosition ++;

            return true;
        }

        static internal bool MoveBackward(Character character, int arenaYMinus)
        {
            if (character.yPosition == arenaYMinus)
            {
                Console.WriteLine("Can't go any further back");
                return false;
            }

            else
                character.yPosition--;

            return true;
        }

        static internal bool MoveLeft(Character character, int arenaXMinus)
        {
            if (character.xPosition == arenaXMinus)
            {
                Console.WriteLine("Can't go any further left");
                return false;
            }

            else
                character.xPosition--;
            return true;
        }

        static internal bool MoveRight(Character character, int arenaXPlus)
        {
            if (character.xPosition == arenaXPlus)
            {
                Console.WriteLine("Can't go any further right");
                return false;
            }

            else
                character.xPosition++;
            return true;
        }

        static internal bool MoveForwardRight(Character character, int arenaXPlus, int arenaYPlus)
        {
            if (character.xPosition == arenaXPlus || character.yPosition == arenaYPlus)
            {
                Console.WriteLine("Can't go that way");
                return false;
            }

            else
            {
                character.xPosition++;
                character.yPosition++;
            }

            return true;
        }

        static internal bool MoveForwardLeft(Character character, int arenaXMinus, int arenaYPlus)
        {
            if (character.xPosition == arenaXMinus || character.yPosition == arenaYPlus)
            {
                Console.WriteLine("Can't go that way");
                return false;
            }

            else
            {
                character.xPosition--;
                character.yPosition++;
            }
            return true;
        }

        static internal bool MoveBackRight(Character character, int arenaXPlus, int arenaYMinus)
        {
            if (character.xPosition == arenaXPlus || character.yPosition == arenaYMinus)
            {
                Console.WriteLine("Can't go that way");
                return false;
            }

            else
            {
                character.xPosition++;
                character.yPosition--;
            }
            return true;
        }

        static internal bool MoveBackLeft(Character character, int arenaXMinus, int arenaYMinus)
        {
            if (character.xPosition == arenaXMinus || character.yPosition == arenaYMinus)
            {
                Console.WriteLine("Can't go that way");
                return false;
            }

            else
            {
                character.xPosition--;
                character.yPosition--;
            }

            return true;
        }

        static internal bool inAttackRange(Character character, Character target)
        {
            if (Math.Abs(character.xPosition - target.xPosition) > character.range
            && Math.Abs(character.yPosition - target.yPosition) > character.range)
            {
                Console.WriteLine("Not in range. Must be within" + character.range + " units");
                Console.ReadLine();
                return false;
            }

            return true;
        }

        static internal bool Attack(Character character, Character target)
        {

            if (Calculations.calcMoveChance(character, target))
            {
                int damage = Calculations.calcMeleeDamage(character, target);
                Console.WriteLine("Attack hits for " + damage);
                Console.ReadLine();

                target.health.currentLevel -= damage;
            }

            else
            {
                Console.WriteLine("Missed");
                Console.ReadLine();
            }
            return true;
        }

        /// <summary>
        /// Casts an ability from character to target 
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        static internal bool Cast(Character character, Character target)
        {
            if (character.spells.Count < 1)
            {
                Console.WriteLine("No spells");
                return false;
            }
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
                return Cast(character, target);
            }

            return true;
        }
    }
}
