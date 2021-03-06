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
        /// The statuses of health
        /// </summary>
        internal enum healthStatus
        {
            Untouched,
            Scratched,
            Bruised,
            Scarred,
            Severe,
            Critical
        }

        internal string calcStatus()
        {
            string[] status = Enum.GetNames(typeof(healthStatus));

            healthStatus s = 0;

            if (health.currentLevel == health.normalLevel)
                s = healthStatus.Untouched;

            else if (health.currentLevel > 0.9 * health.normalLevel)
                s = healthStatus.Scratched;

            else if (health.currentLevel > .75 * health.normalLevel)
                s = healthStatus.Bruised;

            else if (health.currentLevel > .50 * health.normalLevel)
                s = healthStatus.Scarred;

            else if (health.currentLevel > .20 * health.normalLevel)
                s = healthStatus.Severe;

            else if (health.currentLevel > 0)
                s = healthStatus.Critical;

                return status[(int)s];
        }

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
        internal int xPosition;

        /// <summary>
        /// The y location of the entity on the arena grid
        /// </summary>
        internal int yPosition;

        /// <summary>
        /// The number of actions the entity gets per turn
        /// </summary>
        internal int actions;

        /// <summary>
        /// Determines if the character gains a reaction
        /// </summary>
        internal bool canReact;

        /// <summary>
        /// The list of abilities the entity can use
        /// </summary>
        internal List<Ability> spells;

        /// <summary>
        /// Effects that are currently attached to the entity
        /// </summary>
        internal List<Effect> effects;

        /// <summary>
        /// Effects are to be removed following in the cleanup phase
        /// </summary>
        private List<Effect> removeEffects;

        /// <summary>
        /// Items the player currently has
        /// </summary>
        internal List<Item> items;

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

        }

        public Character(bool player)
        {
            initializeSkills();

            spells = new List<Ability>();
            effects = new List<Effect>();
            removeEffects = new List<Effect>();

            CharacterCreator.Initialize(this, player);
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

        internal void addEffect(Effect effect)
        {
            effects.Add(effect);
        }

        private void updateEffects()
        {
            foreach (Effect effect in effects)
            {
                Helper.getCharacterSkillList(this).First(s => s.name == effect.skill.name).currentLevel -= effect.strength;
                effect.duration--;
                if (effect.duration < 1)
                    removeEffects.Add(effect);
            }
        }

        private void removeEffectsFrom()
        {
            foreach (Effect effect in removeEffects)
            {
                effects.Remove(effects.Where(e => e == effect).Single());
            }

            removeEffects = new List<Effect>();
        }

        internal void addItem(Item item)
        {
            items.Add(item);

            for (int i = 0; i < Helper.getCharacterSkillList(this).Length; i++)
            {
                Helper.getCharacterSkillList(this)[i].currentLevel += Helper.getCharacterSkillList(item).Where(t => t.name == Helper.getCharacterSkillList(this)[i].name).Single().currentLevel;
            }
            
        }

        internal void removeItem(Item item)
        {
            for (int i = 0; i < Helper.getCharacterSkillList(this).Length; i++)
            {
                Helper.getCharacterSkillList(this)[i].currentLevel -= Helper.getCharacterSkillList(item).Where(t => t.name == Helper.getCharacterSkillList(this)[i].name).Single().currentLevel;
            }

            items.Remove(item);
        }
    }
}
