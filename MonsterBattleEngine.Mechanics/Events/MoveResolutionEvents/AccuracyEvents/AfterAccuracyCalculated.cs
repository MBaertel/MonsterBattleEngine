using MonsterBattleEngine.Core.BattleFlow.Data;
using MonsterBattleEngine.Core.Combatants;
using MonsterBattleEngine.Core.Events;
using MonsterBattleEngine.Core.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Mechanics.Events.MoveResolutionEvents.AccuracyEvents
{
    public class AfterAccuracyCalculated
        : MoveResolutionEvent
    {
        public bool IsHit { get; }
        public AfterAccuracyCalculated(IBattleEvent cause, ICombatant attacker, ICombatant defender, IMove moveUsed,bool isHit)
            : base(cause, attacker, defender, moveUsed)
        {
            IsHit = isHit;
        }

        public AfterAccuracyCalculated(BattleState battle, ICombatant attacker, ICombatant defender, IMove moveUsed,bool isHit, Guid? causeId = null)
            : base(battle, attacker, defender, moveUsed, causeId)
        {
            IsHit = isHit;
        }

        public static AfterAccuracyCalculated FromBase(MoveResolutionEvent evt,bool isHit) =>
            new AfterAccuracyCalculated(evt, evt.Attacker, evt.Defender, evt.MoveUsed,isHit);
    }
}
