using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class Item : Object
    {
        /// <summary>
        /// The cost to acquire item
        /// </summary>
        internal int cost;

        /// <summary>
        /// How many hands does the item require
        /// </summary>
        internal int handReq;

        /// <summary>
        /// The effects of this item
        /// </summary>
        internal Effect[] effects;

        private void initializeObject()
        {
            name = "Player";
            health = new Skill("Health", 100);
            strength = new Skill("Strength");
            magic = new Skill("Magic", 50);
            speed = new Skill("Speed");
            intelligence = new Skill("Intelligence");
            reaction = new Skill("Reaction");
            initiative = new Skill("Initiative");
            awareness = new Skill("Awareness");
            wisdom = new Skill("Wisdom");
            range = 1;
        }

        public Item(string name, int strength, int magic, int speed, int intelligence, int reaction, int initiative, 
           int awareness, int wisdom, int range, int cost, int handReq, int defense, Effect[] effect, bool addEffect = false)
        {
            initializeObject();

            this.name = name;
            this.strength.currentLevel = this.strength.normalLevel = strength;
            this.magic.currentLevel = this.magic.normalLevel = magic;
            this.speed.currentLevel = this.speed.normalLevel = speed;
            this.intelligence.currentLevel = this.intelligence.normalLevel = intelligence;
            this.reaction.currentLevel = this.reaction.normalLevel = reaction;
            this.initiative.currentLevel = this.initiative.normalLevel = initiative;
            this.awareness.currentLevel = this.awareness.normalLevel = awareness;
            this.wisdom.currentLevel = this.wisdom.normalLevel = wisdom;
            this.range = range;
            this.cost = cost;
            this.handReq = handReq;

            if (addEffect == false)
                effect = new Effect[] { EffectList.effectSkill(health) };

            else
                effects = effect;
        }
    }
}
