using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Pipelines
{
    public class LambdaPipelineRule<TIn,TOut> : PipelineRuleBase<TIn,TOut>
        where TIn : IBattleEvent 
        where TOut : IBattleEvent
    {
        private Func<TIn,TOut> _lambda;

        public LambdaPipelineRule(Func<TIn,TOut> lambda)
        {
            _lambda = lambda;
        }

        protected override TOut Transform(TIn evt) =>
            _lambda(evt);
    }
}
