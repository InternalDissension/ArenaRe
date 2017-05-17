using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ArenaRe
{
    /// <summary>
    /// Contains functions for initializing skills and adding abilities to characters
    /// </summary>
    class CharacterCreator
    {
        public CharacterCreator(Character character)
        {

        }

        /// <summary>
        /// Initializes the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="player">if set to <c>true</c> [player].</param>
        /// <returns></returns>
        internal static Character Initialize(Character character, bool player)
        {
            if (player)
            {
                Console.Write("Name your character: ");
                character.name = Console.ReadLine();
            }
            character.addSkillPoint(20);
            character.addAbilityPoint(5);

            return character;
        }

        /// <summary>
        /// Adjusts an enemy's stats based off of the current stats of the player
        /// </summary>
        /// <param name="enemy">The enemy.</param>
        /// <param name="player">The player.</param>
        private Character CreateEnemy(Character enemy, Character player)
        {
            return enemy;
        }

        internal static void distributeSkillPoints(Character character)
        {
            int choice = 0;
            while (choice != -1 && character.hasSkillPoints)
            {
                Console.Clear();
                Helper.space(2);

                Console.WriteLine("Select which skill you'd like to upgrade:");
                Skill[] skillList = Helper.getCharacterSkillList(character);

                for (int i = 0; i < skillList.Length; i++)
                {
                    Console.Write((i + 1) + ": " + skillList[i].name);
                    Console.WriteLine(": " + skillList[i].normalLevel);
                }

                Console.WriteLine("0 to go back");
                choice = Helper.processChoice(true);

                if (choice == -1)
                    continue;

                Console.WriteLine("Upgrade " + skillList[choice].name + "? (y/n)");
                if (Console.ReadLine() == "y")
                {
                    if (skillList[choice].normalLevel + 1 < skillList[choice].maxLevel)
                    {
                        int points = investPoints();
                        while (points > character.getSkillPoints)
                        {
                            points = investPoints();
                            Console.WriteLine("Not enough points"); Helper.space(2);
                        }

                        Helper.getCharacterSkillList(character)[choice].currentLevel += points;
                        Helper.getCharacterSkillList(character)[choice].normalLevel += points;

                        while (points > 0)
                        {
                            character.subSkillPoint();
                            points--;
                        }
                    }

                    else
                        Console.WriteLine("Skill is maxed");
                }
            }

            if (!character.hasSkillPoints)
            {
                Console.WriteLine("No Skill Points");
                Console.WriteLine("Enter to continue");
                Console.ReadLine();
                return;
            }
        }

        internal static void distributeAbilityPoints(Character character)
        {

            if (!character.hasAbilityPoints)
            {
                Console.WriteLine("No Ability Points");
                Console.WriteLine("Enter to continue");
                Console.ReadLine();
                return;
            }

            int choice = -1;

            Console.WriteLine();
            Console.WriteLine("Select spell to upgrade: ");
            while (choice != 0 && character.hasAbilityPoints)
            {
                for (int i = 0; i < character.spells.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + character.spells[i].name);
                }

                choice = Helper.processChoice(true);

                if (character.spells.ElementAtOrDefault(choice) != null)
                {
                    Console.WriteLine(@"
Viewing {0}:
What would you like to upgrade?
1: Strength
2: Duration
3: Build up
4: Mana Cost
5: Health Cost
6: Go Back");

                    int choice2 = Helper.processChoice(false);

                    switch (choice2)
                    {
                        case 1:
                            character.spells[choice].strength++;
                            character.subAbilityPoint();
                            break;

                        case 2:
                            character.spells[choice].duration++;
                            character.subAbilityPoint();
                            break;

                        case 3:
                            if (Ability.isBuildUpCostValid(character.spells[choice].buildUp))
                            {
                                character.spells[choice].buildUp++;
                                character.subAbilityPoint();
                            }

                            break;

                        case 4:
                            if (Ability.isManaCostValid(character.spells[choice].manaCost))
                            {
                                character.spells[choice].manaCost--;
                                character.subAbilityPoint();
                            }
                            break;

                        case 5:
                            if (Ability.isHealthCostValid(character.spells[choice].healthCost))
                            {
                                character.spells[choice].healthCost--;
                                character.subAbilityPoint();
                            }
                            break;

                        case 6:
                            break;

                        default:
                            choice = -1;
                            break;
                    }
                }

                else
                    DebugLog.invalidInputError(choice + " is not valid");
            }

        }

        /// <summary>
        /// Outputs the list of abilities not in the character's spells List
        /// and allows the adding of them provided the character has ability points
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        internal static int addNewAbility(Character character)
        {
            Console.Clear();
            List<Ability> abilityList = Helper.getAbilityList().ToList();
            StatViewer.viewAbilityArray(abilityList.ToArray());

            Helper.space(2);

            Console.WriteLine("Select spell: ");
            //Iterate through abilityList variable and list all ability names
            for (int i = 0; i < abilityList.Count; i++)
            {
                if (character.spells.Contains(abilityList[i]))      //If the character has the ability
                {
                    abilityList.RemoveAt(i);                            //Remove it and continue
                    i--;
                    continue;
                }
                    Console.WriteLine((i + 1) + ": " + abilityList[i].name);   //List it
            }

            Console.WriteLine((abilityList.Count + 1) + ": Go back");

            int choice = Helper.processChoice(true);

            if (choice == abilityList.Count)
                return choice;

            else
            {
                try
                {
                    //Output choice to the user
                    Console.WriteLine("Are you sure you want to add: " + abilityList[choice].name + "? (y/n)");
                }

                catch
                {
                    DebugLog.invalidInputError(choice + " is not a valid input");
                    choice = addNewAbility(character);
                }

                //If user enters y
                if (Console.ReadLine() == "y")

                    //If the user has enough ability points to acquire the ability, add it
                    if (character.getAbilityPoints >= abilityList[choice].acquireCost)
                    {
                        character.spells.Add(abilityList[choice]);
                        character.subAbilityPoint();
                    }

                    //Otherwise let the user know that they have insufficient points
                    else
                        Console.WriteLine("Not enough ability points");
                //Else recall the function
                else
                    choice = addNewAbility(character);
            }

            return choice;
        }

        private static int investPoints()
        {
            Console.WriteLine("How many points would you like to invest? (0 to cancel)");
            int points = Helper.processChoice(false);

            return points;
        }
    }
}
