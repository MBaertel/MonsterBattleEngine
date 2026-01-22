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
        private int? _subscriptionId;
        private IBattleEventBus _bus;

        public string Name { get; }
        public IReadOnlyList<IPipelineRule> Rules => _rules.AsReadOnly();

        public PipelineBase(string name)
        {
            Name = name;
            _rules = new List<IPipelineRule>();
        }

        public void Register(IBattleEventBus bus)
        {
            Unregister();
            _bus = bus;
            _subscriptionId = _bus.Subscribe<IBattleEvent>(this, Handle, -1);
        }

        public void Unregister() 
        {
            if(!_subscriptionId.HasValue || _bus == null) return;
            _bus.Unsubscribe(_subscriptionId.Value);
            _subscriptionId = null;
        }

        private void Handle(IBattleEvent evt)
        {
            var outputEvents = new List<IBattleEvent>();
            foreach (var rule in _rules)
            {
                if (rule.CanHandle(evt))
                    outputEvents.Add(rule.Apply(evt));
            }
            outputEvents.ForEach(e => _bus.Publish(e));
        }
    }
}
