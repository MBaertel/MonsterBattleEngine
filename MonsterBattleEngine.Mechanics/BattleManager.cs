using MonsterBattleEngine.Core.BattleFlow;
using MonsterBattleEngine.Core.BattleFlow.Data;
using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Systems;
using MonsterBattleEngine.Mechanics.Pipelines;
using MonsterBattleEngine.Mechanics.Systems;

namespace MonsterBattleEngine.Mechanics
{
    public class BattleManager : BattleManagerBase
    {
        protected override void Configure()
        {
            AddSystem(new DamageCalculationSystem());
            AddSystem(new DamageApplicationSystem());

            AddPipeline(new MoveResolutionPipeline());
        }
    }
}
