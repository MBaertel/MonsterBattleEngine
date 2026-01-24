using MonsterBattleEngine.Core.Pipelines;
using MonsterBattleEngine.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Mechanics.Pipelines
{
    public class MoveResolutionPipeline : PipelineBase
    {
        public MoveResolutionPipeline() 
            : base("MoveResolutionPipeline")
        {
            _rules.AddRule<BeforeMoveResolution, BeforeAccuracyCalculated>(x => 
                BeforeAccuracyCalculated.FromBase(x));
            
            _rules.AddRule<AfterAccuracyCalculated,BeforeDamageCalculated>(x =>
                BeforeDamageCalculated.FromBase(x));

            _rules.AddRule<AfterDamageCalculated, BeforeDamageApplied>(x =>
                BeforeDamageApplied.FromBase(x, x.Damage));

            _rules.AddRule<AfterDamageApplied, BeforeStatusApplied>(x =>
                BeforeStatusApplied.FromBase(x));

            _rules.AddRule<AfterStatusApplied,AfterMoveResolution>(x =>
                AfterMoveResolution.FromBase(x));
        }
    }
}
