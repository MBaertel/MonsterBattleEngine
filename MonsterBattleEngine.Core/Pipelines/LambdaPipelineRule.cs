using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Pipelines
{
    public class LambdaPipelineRule<TIn,TOut> : PipelineRuleBase<TIn>
        where TIn : IBattleEvent 
        where TOut : IBattleEvent
    {
        private Func<TIn,TOut> _lambda;

        public LambdaPipelineRule(IBattleEventBus bus,Func<TIn,TOut> lambda)
            :base(bus)
        {
            _lambda = lambda;
        }

        protected override void OnEventCompleted(TIn evt)
        {
            Raise(_lambda(evt));
        }
    }
}
