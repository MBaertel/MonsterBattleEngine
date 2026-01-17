using MonsterBattleEngine.Core.BattleFlow.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.BattleFlow.Interface
{
    public interface IBattleManager : IBattleEventBus
    {
        BattleState Battle { get; }
    }
}
