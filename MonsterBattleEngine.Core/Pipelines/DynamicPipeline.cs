using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterBattleEngine.Core.Pipelines
{
    public class DynamicPipeline : PipelineBase
    {
        private readonly Dictionary<IPipelineRule, int> _rulePriorities;
        public DynamicPipeline(string name) 
            : base(name)
        {
            _rulePriorities = new Dictionary<IPipelineRule, int>();
        }

        public void AddRule<TIn, TOut>(Func<TIn, TOut> lambda, int priority = -1)
            where TIn : IBattleEvent
            where TOut : IBattleEvent
        {
            var rule = new LambdaPipelineRule<TIn, TOut>(lambda);
            AddRule(rule,priority);
        }

        public void AddRule(IPipelineRule rule,int priority = -1)
        {
            _rules.Add(rule);
            _rulePriorities[rule] = priority;

            _rules.OrderByDescending(x => _rulePriorities[x]);
        }
    }
}
