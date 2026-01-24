using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterBattleEngine.Core.Pipelines
{
    public class DynamicPipeline : PipelineBase
    {
        private string _name;

        public override string Name => _name;

        public DynamicPipeline(string name) 
        {
            _name = name;
        }

        public DynamicPipeline AddRule<TIn, TOut>(Func<TIn, TOut> lambda)
            where TIn : IBattleEvent
            where TOut : IBattleEvent
        {
            var rule = new LambdaPipelineRule<TIn, TOut>(lambda);
            AddRule(rule);

            return this;
        }

        public DynamicPipeline AddRule(IPipelineRule rule)
        {
            _rules.Add(rule);
            return this;
        }
        
        public DynamicPipeline AddSubPipeline(IPipeline pipeline)
        {
            _subPipelines.Add(pipeline);
            return this;
        }
    }
}
