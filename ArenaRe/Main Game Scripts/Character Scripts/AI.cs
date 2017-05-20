using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaRe
{
    /// <summary>
    /// Handles the processing of enemy actions during a battle. One should exist for every enemy
    /// </summary>
    /// <seealso cref="ArenaRe.Character" />
    class AI : Character
    {
        private enum Title
        {
            Healer,
            Fighter,
            Guardian,
            Assassin,
            Warmonger,
            Duelist,
            Wildcaster,
            BeastTamer
        }

        private enum Action
        {
            MoveTo,
            Attack,
            CastOnSelf,
            CastAtTarget,
            Run,
            StepThrough,
            SideStep,
            WaitForHeal,
            Shieldbash
        }

        private enum Goal
        {
            Melee,
            Cast,
            DefendAlly,
            Retreat,
            Heal,
            HealAlly
        }

        Goal[] goal;
        Title[] titles;
        Action action;
        public AI()
        {
        }
    }
}
