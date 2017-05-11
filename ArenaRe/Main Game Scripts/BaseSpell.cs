using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class BaseSpell : Abilities
    {
        public BaseSpell()
        {
            this.xp = 0;
        }

        internal override string spellName
        {
            get { return "0"; }
        }

        internal override int strength
        {
            get { return 0; }
        }

        internal override float castDifficulty
        {
            get { return 0; }
        }

        internal override int manaCost
        {
            get { return 0; }
        }

        internal override int healthCost
        {
            get { return 0; }
        }

        internal override float xpRate
        {
            get { return 0; }
        }
    }
}
