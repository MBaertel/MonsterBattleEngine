using MonsterBattleEngine.Core.BattleFlow.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.BattleFlow.Interface
{
    public interface IBattleManager
    {
        BattleState Battle { get; }
    }
}
