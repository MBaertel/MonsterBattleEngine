using MonsterBattleEngine.Core.Pipelines;
using MonsterBattleEngine.Core.Utils;
using MonsterBattleEngine.Mechanics.Events.MoveResolutionEvents;
using MonsterBattleEngine.Mechanics.Events.MoveResolutionEvents.AccuracyEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Mechanics.Pipelines
{
    public class MoveResolutionPipeline : PipelineBase
    {

        public override string Name => "MoveResolutionPipeline";

        public override void Configure()
        {
            _rules.AddRule<BeforeMoveResolution,BeforeAccuracyCalculated>(x =>
                BeforeAccuracyCalculated.FromBase(x));
        }

        
    }
}
