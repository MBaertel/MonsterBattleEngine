using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Types
{
    public interface ICombatantType
    {
        public string Id { get; }
        public IReadOnlyDictionary<string, float> Effectiveness { get; }
        public float GetEffectivenessAgainst(string otherTypeId);
    }
}
