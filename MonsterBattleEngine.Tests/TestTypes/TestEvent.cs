using MonsterBattleEngine.Core.BattleFlow.Data;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Tests.TestTypes
{
    public class TestEvent : IBattleEvent
    {
        public Guid Id { get; } = Guid.NewGuid();

        public bool Cancellable => false;

        public bool IsCancelled { get; set; } = false;

        public BattleState Battle => null;
    }

    public class TestEvent2 : IBattleEvent
    {
        public Guid Id { get; } = Guid.NewGuid();

        public bool Cancellable => false;

        public bool IsCancelled { get; set; } = false;

        public BattleState Battle => null;
    }
}
