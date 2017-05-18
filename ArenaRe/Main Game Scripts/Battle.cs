using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Battle starts off with the player facing opponents. The location of the battle takes place in an enclosed
 * space that is determined at the beginning of the fight. The importance of this is explained further down
 * 
 * Fighting is divided into turns and sub-divided into a series of phases: 
 * Initiation Phase
 * Resolution Phase I
 * Reaction Phase
 * Resolution Phase II
 * 
 * Characters have a number of "Actions" per turn based on their initiative skill and the momentum in the 
 * current battle. Actions include a player moving, attacking, and casting spells among other things.
 * 
 * The character that currently holds the turn gets to select an action during the Action Phase. 
 * 
 * During the Assessment Phase, various checks are made to determine the success of the action and if 
 * any reactions are given.
 * 
 * During the reaction phase, characters may choose from a series of reactions depending on the original action
 * Reactions include moving, counter-attacking, casting, or spell charging.
 * 
 * During the resolution phase, all damage and movements are resolved and the character that holds the turn may
 * take their next Action if they have one.
 * 
 * The objective is simple. The player will engage their opponents until either they are defeated or flee, or until
 * the player does the same.
 * 
 * The arena tracks the distance between entities and the environment. Entities can freely move or
 * can take actions against designated targets if within proximity.
 * Free Actions consist of: Forward, backward, left, right, defending, examining surroundings, running in a direction, 
 * or casting self-targeted abilities
 * Designated Actions consist of: Stepping through an opponent, stepping to the side, back stepping, attacking,
 * and casting targeted abilities
 * 
 * All designated actions require checks and can fail either due to poor skill or good defense
 */

namespace ArenaRe
{
    class Battle
    {
        /// <summary>
        /// The name of the current character's turn
        /// </summary>
        static internal Arena arena;
        Character player;
        List<Character> enemies;
        List<Character> characters;
        private bool battleActive = true;

        public Battle()
        {
        }

        public Battle(Character player, List<Character> enemies)
        {
            Console.Clear();
            arena = new Arena();
            this.player = player;
            this.enemies = enemies;
            showBattleStats();
            Console.ReadLine();
        }

        /// <summary>
        /// Gets information on the position of an enemy in relation to the player
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="enemy">The enemy.</param>
        /// <returns></returns>
        private string getPositionToPlayer(Character player, Character enemy)
        {
            string xDirection = " Horizontal";
            string yDirection = " Forward";

            int xDiff = Math.Abs(player.xPosition - enemy.xPosition);
            int yDiff = Math.Abs(player.yPosition - enemy.yPosition);

            if (enemy.xPosition > player.xPosition)
                xDirection = "Right";
            else if (enemy.xPosition < player.xPosition)
                xDirection = "Left";

            if (enemy.yPosition > player.yPosition)
                yDirection = "In front";
            else if (enemy.yPosition < player.yPosition)
                yDirection = "Behind";

            return yDiff + yDirection + "|" + xDiff + xDirection;
        }

        private void showBattleStats()
        {
            Console.WriteLine("{0, 0}{1}", "Player: ", player.name);
            Console.WriteLine("{0, 0} {1, 0} {2, 0} {3} ", "Health:", player.health.currentLevel, "Mana:", player.magic.currentLevel);
            Console.WriteLine();
            int x = 0;

            for (int i = 0; i < enemies.Count; i++)
            {
                Console.Write("{0, -26}", enemies[i].name);

                if (i == 0 || (i + 1) % 4 != 0 && i != enemies.Count - 1)
                    continue;

                Console.WriteLine();
                int t = x;
                while (x <= i)
                {
                    Console.Write("{0, 0}{1, 0}  {2, 0}{3, -8} ", "Health:", enemies[x].health.currentLevel, "Mana:", enemies[x].magic.currentLevel);
                    x++;
                }
                Console.WriteLine();

                while (t <= i)
                {
                    Console.Write("{0, -26}", getPositionToPlayer(player, enemies[t]));
                    t++;
                }

                Helper.space(2);
            }
        }

        /// <summary>
        /// Controls the cycle of turns and phases
        /// </summary>
        private void combatCycle()
        {
            while (battleActive)
            {
                characters = determineTurnOrder();

                for (int turnNum = 0; turnNum < characters.Count; turnNum++)
                {
                    if (characters[turnNum] == player)
                        characters[turnNum].actions = Helper.calculateActions(player, enemies.ToArray());

                    else
                    {
                        Character[] p = new Character[] { player };
                        characters[turnNum].actions = Helper.calculateActions(characters[turnNum], p);
                    }

                    combatPhases(characters[turnNum]);                    
                }
            }
        }

        /// <summary>
        /// Controls the action cycle
        /// </summary>
        /// <param name="initiator">The character.</param>
        private void combatPhases(Character initiator)
        {
            //Action Phase
            while (initiator.actions > 0)
            {
                Console.WriteLine("It is currently " + initiator.name + "'s turn");

                if (initiator != player)
                {
                    Console.WriteLine("Enter to begin next action");
                    Console.ReadLine();
                    //AI Selection
                }

                else
                {
                    //Combat Description
                }

                initiator.actions--;
            }
            //End Action Phase

            //Assessment Phase
            //Reaction Phase
            //Resolution Phase
        }

        private int viewCombatOptions()
        {
            Console.WriteLine(@"
1. Move
2. Attack
3. Rally (Boost Defense)
4. Cast
5. Examine");

            int choice = Helper.processChoice(false);
            return processCombatOption(choice);
        }

        private int processCombatOption(int choice)
        {
            switch (choice)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                default:
                    choice = viewCombatOptions();
                    break;
            }
            return choice;
        }

        private void actionPhase(bool player)
        {
            if (player)
                viewCombatOptions();
            //else
                //AI selection
        }

        private void assessmentPhase()
        {       
        }

        /// <summary>
        /// Calculates who is granted reactions for this Action
        /// </summary>
        /// <param name="initiator">The initiator.</param>
        private void calcReactions(Character initiator)
        {
            foreach (Character c in characters)
            {
                if (c == initiator)
                    continue;

                c.canReact = ActionHandler.calcReaction(c, initiator);
            }
        }

        private void reactionPhase()
        {

        }

        private void resolutionPhase()
        {

        }

        private List<Character> determineTurnOrder()
        {
            List<Character> turnOrder = new List<Character>();
            turnOrder.Add(player);
            turnOrder.AddRange(enemies);
            return (List<Character>)turnOrder.OrderBy(i => i.initiative.currentLevel);
        }

        private void battleChoice()
        {

        }

    }
}
