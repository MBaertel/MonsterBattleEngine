using MonsterBattleEngine.Core.Effects;
using MonsterBattleEngine.Core.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MonsterBattleEngine.Core.Combatants
{
    public abstract class CombatantBase
    {
        public string Id { get; }
        public string Name { get; }

        public int? Level { get; }
        public List<ICombatantType> Types { get; } = new List<ICombatantType>();

        public CombatantStats BaseStats { get; }
        public int CurrentHp { get; protected set; }
        public bool IsAlive => CurrentHp > 0;

        public List<IBattleEffect> StatusEffects { get; } = new();

        protected CombatantBase(string id, CombatantStats baseStats, List<ICombatantType> types = null,int? level = null, string name = null)
        {
            Id = id;
            Name = name ?? id;
            Level = level;
            Types = types ?? new List<ICombatantType>();
            BaseStats = baseStats;
            CurrentHp = baseStats.Hp;
        }

        public void TakeDamage(int amount)
        {
            CurrentHp -= amount;
            if (CurrentHp < 0) CurrentHp = 0;
        }

        public void Heal(int amount)
        {
            CurrentHp += amount;
            if (CurrentHp > BaseStats.Hp) CurrentHp = BaseStats.Hp;
        }

        public float GetTypeEffectiveness(string targetTypeId) => Types?
            .Select(t => t.GetEffectivenessAgainst(targetTypeId))
            .Aggregate((acc,m) => acc * m) ?? 1f;
    }
}
