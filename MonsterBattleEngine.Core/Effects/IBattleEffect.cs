using MonsterBattleEngine.Core.Combatants;
using MonsterBattleEngine.Core.Events;
using MonsterBattleEngine.Core.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Effects
{
    public interface IBattleEffect : ISystem
    {
        CombatantBase Owner { get; }
    }
}
