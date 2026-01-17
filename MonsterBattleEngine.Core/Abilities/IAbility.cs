using MonsterBattleEngine.Core.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Abilities
{
    public interface IAbility
    {
        string Id { get; }
        string DisplayName { get; }
        string Description { get; }
        List<IBattleEffect> Effects { get; }
    }
}
