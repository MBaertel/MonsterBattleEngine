using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Pipelines
{
    public abstract class PipelineBase : IPipeline
    {
        protected readonly List<IPipelineRule> _rules;
        protected readonly List<IPipeline> _subPipelines;

        private int? _subscriptionId;
        private IBattleEventBus _bus;

        public abstract string Name { get; }
        public IReadOnlyList<IPipelineRule> Rules => _rules.AsReadOnly();
        public IReadOnlyList<IPipeline> SubPipelines => _subPipelines.AsReadOnly();

        public PipelineBase()
        {
            _rules = new List<IPipelineRule>();
            _subPipelines = new List<IPipeline>();
            Configure();
        }

        public abstract void Configure();

        public void Register(IBattleEventBus bus)
        {
            Unregister();
            _bus = bus;
            
            _rules.ForEach(r => r.Register(bus));
            _subPipelines.ForEach(p => p.Register(bus));
        }

        public void Unregister() 
        {
            _rules.ForEach(r => r.Unregister());
            _subPipelines.ForEach(p => p.Unregister());
        }
    }
}
