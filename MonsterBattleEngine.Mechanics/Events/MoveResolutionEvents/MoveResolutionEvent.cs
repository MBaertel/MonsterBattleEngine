using MonsterBattleEngine.Core.BattleFlow.Data;
using MonsterBattleEngine.Core.Combatants;
using MonsterBattleEngine.Core.Events;
using MonsterBattleEngine.Core.Moves;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MonsterBattleEngine.Mechanics.Events.MoveResolutionEvents
{
    public class MoveResolutionEvent
        : EventBase
    {
        public override string Name => "Move Resolution Event";

        public ICombatant Attacker { get; }
        public ICombatant Defender { get; }
        public IMove MoveUsed { get; }

        public MoveResolutionEvent(BattleState battle,ICombatant attacker,ICombatant defender,IMove moveUsed,Guid? causeId = null)
            : base(battle, causeId, false)
        {
            Attacker = attacker;
            Defender = defender;
            MoveUsed = moveUsed;
        }

        public MoveResolutionEvent(IBattleEvent cause,ICombatant attacker, ICombatant defender, IMove moveUsed)
            : base(cause)
        {
            Attacker = attacker;
            Defender = defender;
            MoveUsed = moveUsed;
        }
    }
}
