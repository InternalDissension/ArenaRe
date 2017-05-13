using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    class EffectList
    {
        static internal Effect effectSkill(Skill skill, int strength = 1, int duration = 1)
        {
            Effect effect = new Effect(skill, strength, duration);
            return effect;
        }

        static internal Effect burn;
        static internal Effect timeSlow;
        static internal Effect teleport;
    }
}
