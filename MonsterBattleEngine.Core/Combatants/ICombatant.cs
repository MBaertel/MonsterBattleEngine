using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Combatants
{
    public interface ICombatant
    {
        string Id { get; }
        string Name { get; }
        CombatantStats BaseStats { get; }

        void TakeDamage(int amount);
        void Heal(int amount);
    }
}
