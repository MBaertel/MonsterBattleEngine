using MonsterBattleEngine.Core.BattleFlow.Data;
using MonsterBattleEngine.Core.Combatants;
using MonsterBattleEngine.Core.Events;
using MonsterBattleEngine.Core.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Mechanics.Events.MoveResolutionEvents
{
    public class BeforeMoveResolution
        : MoveResolutionEvent
    {
        public BeforeMoveResolution(BattleState battle, ICombatant attacker, ICombatant defender, IMove moveUsed, Guid? causeId = null) 
            : base(battle, attacker, defender, moveUsed, causeId)
        {
        }

        public BeforeMoveResolution(IBattleEvent cause, ICombatant attacker, ICombatant defender, IMove moveUsed) 
            : base(cause, attacker, defender, moveUsed)
        {
        }
    }
}
