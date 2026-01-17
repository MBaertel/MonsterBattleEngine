using MonsterBattleEngine.Core.Combatants;
using MonsterBattleEngine.Core.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.BattleFlow.Data
{
    public class BattleState
    {
        public int TurnNumber { get; set; }
        public BattleTypes Type { get; set; }

        public IEnumerable<CombatantBase> SideACombatants { get; set; }
        public IEnumerable<CombatantBase> SideBCombatants { get; set; }
        public IEnumerable<CombatantBase> AllCombatants => SideACombatants.Concat(SideBCombatants);
         
        public IBattleEffect Weather { get; set; }
        public IBattleEffect Terrain { get; set; }
        public IEnumerable<IBattleEffect> Effects { get; } = new List<IBattleEffect>();
    }
}
