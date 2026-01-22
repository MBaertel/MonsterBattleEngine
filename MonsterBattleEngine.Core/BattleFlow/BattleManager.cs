using MonsterBattleEngine.Core.BattleFlow.Data;
using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.BattleFlow
{
    public class BattleManager : IBattleManager
    {
        public BattleState Battle { get; }
    }
}
