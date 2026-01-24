using MonsterBattleEngine.Core.BattleFlow.Data;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Tests.TestTypes
{
    public class TestEvent(BattleState battle = null,Guid? causeId = null,bool isCancelled = false) 
        :EventBase(battle,causeId,isCancelled)
    {
        public override string Name => "TestEvent";
    }

    public class TestEvent2(BattleState battle = null, Guid? causeId = null, bool isCancelled = false)
        : EventBase(battle, causeId, isCancelled)
    {
        public override string Name => "TestEvent2";
    }
}
