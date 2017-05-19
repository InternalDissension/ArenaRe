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
            MoveForward,
            MoveBack,
            MoveRight,
            MoveLeft,
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
            Defend,
            DefendAlly,
            Backstab,
            Retreat,
            Heal,
            HealAlly,
            PositionMelee,
            PositionDefend,
            PositionCast
        }
        public AI()
        {
        }
    }
}
