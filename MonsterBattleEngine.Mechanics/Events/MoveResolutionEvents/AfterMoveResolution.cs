using MonsterBattleEngine.Core.BattleFlow.Data;
using MonsterBattleEngine.Core.Combatants;
using MonsterBattleEngine.Core.Events;
using MonsterBattleEngine.Core.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Mechanics.Events.MoveResolutionEvents
{
    public class AfterMoveResolution
        : MoveResolutionEvent
    {
        public AfterMoveResolution(BattleState battle, ICombatant attacker, ICombatant defender, IMove moveUsed, Guid? causeId = null)
            : base(battle, attacker, defender, moveUsed, causeId)
        {

        }
        public AfterMoveResolution(IBattleEvent cause, ICombatant attacker, ICombatant defender, IMove moveUsed) : base(cause, attacker, defender, moveUsed)
        {
        }
    }
}
