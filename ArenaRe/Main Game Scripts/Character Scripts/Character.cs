﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// Contains the outline of everything that defines a character.
    /// </summary>
    /// <seealso cref="ArenaRe.Object" />
    class Character : Object
    {

        /// <summary>
        /// The skill points the entity can spend on increasing skills
        /// </summary>
        private int skillPoints;

        /// <summary>
        /// The total amount of skill points the entity has been awarded throughout the game.
        /// </summary>
        private int skillPointTotal;

        /// <summary>
        /// The ability points the entity can spend on learning abilities
        /// </summary>
        private int abilityPoints;

        /// <summary>
        /// The total amount of ability points the entity has been awarded throughout the game.
        /// </summary>
        private int abilityPointTotal;

        /// <summary>
        /// The amount of xp required to get another skill point
        /// </summary>
        internal int skillXP;

        /// <summary>
        /// The amount of xp required to get another ability point
        /// </summary>
        internal int abilityXP;

        /// <summary>
        /// The x location of the entity on the arena grid
        /// </summary>
        internal float xPosition;

        /// <summary>
        /// The y location of the entity on the arena grid
        /// </summary>
        internal float yPosition;

        /// <summary>
        /// The list of abilities the entity can use
        /// </summary>
        internal List<Ability> spells;

        /// <summary>
        /// Indicates whether the character has skill points.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has skill points; otherwise, <c>false</c>.
        /// </value>
        internal bool hasSkillPoints
        {
            get { return skillPoints > 0; }
        }

        /// <summary>
        /// Indicates whether the character has ability points.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has ability points; otherwise, <c>false</c>.
        /// </value>
        internal bool hasAbilityPoints
        {
            get { return abilityPoints > 0; }
        }

        /// <summary>
        /// Gets the skill points.
        /// </summary>
        /// <value>
        /// The get skill points.
        /// </value>
        internal int getSkillPoints
        {
            get { return skillPoints; }
        }

        /// <summary>
        /// Gets the ability points.
        /// </summary>
        /// <value>
        /// The get ability points.
        /// </value>
        internal int getAbilityPoints
        {
            get { return abilityPoints; }
        }
        /// <summary>
        /// Adds a skill point to the entity
        /// </summary>
        internal void addSkillPoint(int value = 1)
        {
            skillPoints += value;
            skillPointTotal += value;
        }

        /// <summary>
        /// Adds an ability point to the entity
        /// </summary>
        /// <param name="value">The value.</param>
        internal void addAbilityPoint(int value = 1)
        {
            abilityPoints+= value;
            abilityPointTotal += value;
        }

        /// <summary>
        /// Subtracts a skill point from the entity
        /// </summary>
        internal void subSkillPoint()
        {
            skillPoints--;
        }

        /// <summary>
        /// Subtracts an ability point from the ability
        /// </summary>
        internal void subAbilityPoint()
        {
            abilityPoints--;
        }

        public Character()
        {
            initializeSkills();
            //CharacterCreator.distributeSkillPoints(this);
            //CharacterCreator.distributeAbilityPoints(this);
            StatViewer.viewSkills(this);
            Helper.space(3);
            spells = new List<Ability>();
            AbilityList.InitializeAbilityList();
            spells.Add(AbilityList.testSpell);
            spells.Add(AbilityList.fireball);
            StatViewer.viewAbilities(this);
            Console.ReadLine();
        }

        /// <summary>
        /// Initializes the abilities of the character
        /// </summary>
        private void initializeAbilities()
        {
        }

        /// <summary>
        /// Returns an array of classes that inherit the Abilities class.
        /// This should only be performed once during runtime
        /// </summary>
        /// <returns></returns>
        public Ability[] getAllAbilities()
        {
            IEnumerable<Ability> abilities = typeof(Ability).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Ability)) && !t.IsAbstract).Select(t => (Ability)Activator.CreateInstance(t));
            return abilities.ToArray();
        }
    }
}
