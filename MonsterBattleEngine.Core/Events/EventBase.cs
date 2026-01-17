using MonsterBattleEngine.Core.BattleFlow.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Events
{
    public record EventBase(
        BattleState Battle,
        bool Cancellable = false
    ) : IBattleEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public bool IsCancelled { get; set; } = false;
    }
}
