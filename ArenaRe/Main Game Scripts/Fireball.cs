using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class Fireball : Abilities 
    {

        public Fireball()
        {
            this.xp = 0;
        }

        internal override string spellName
        {
            get { return "Fireball"; }
        }

        internal override int strength
        {
            get { return 5 + (int)Math.Floor(xp - xpModifier); }
        }

        internal override float castDifficulty
        {
            get { return 15; }
        }

        internal override int manaCost
        {
            get { return 10; }
        }

        internal override int healthCost
        {
            get { return 0; }
        }

        internal override float xpRate
        {
            get { return 5; }
        }
    }
}
