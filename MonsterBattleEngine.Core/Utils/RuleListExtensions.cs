using MonsterBattleEngine.Core.Events;
using MonsterBattleEngine.Core.Pipelines;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Utils
{
    public static class RuleListExtensions
    {
        public static void AddRule<TIn,TOut>(this List<IPipelineRule> rules,Func<TIn,TOut> lambda)
            where TIn : IBattleEvent
            where TOut : IBattleEvent
        {
            rules.Add(new LambdaPipelineRule<TIn,TOut>(lambda));
        }
    }
}
