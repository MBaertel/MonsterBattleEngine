using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Types
{
    public class CombatantType : ICombatantType
    {
        public string Id { get; set; }
        public IReadOnlyDictionary<string, float> Effectiveness { get; set; } = new Dictionary<string, float>();

        public CombatantType(string id,Dictionary<string,float> effectivenes)
        {
            Id = id;
            Effectiveness = effectivenes.AsReadOnly();
        }

        public float GetEffectivenessAgainst(string otherTypeId)
            => Effectiveness.TryGetValue(otherTypeId, out var multiplier) ? multiplier : 1f;
    }
}
