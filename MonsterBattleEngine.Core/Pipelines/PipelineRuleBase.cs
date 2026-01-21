using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Pipelines
{
    public abstract class PipelineRuleBase<TEvent> : IPipelineRule
        where TEvent : IBattleEvent
    {
        private readonly IBattleEventBus _bus;
        public PipelineRuleBase(IBattleEventBus bus)
        {
            _bus = bus;
        }

        public bool CanHandle(IBattleEvent battleEvent)
        {
            return battleEvent is TEvent;
        }

        public void Apply(IBattleEvent evt)
        {
            if (evt is TEvent tevt)
                OnEventCompleted(tevt);
        }

        protected abstract void OnEventCompleted(TEvent evt);

        protected void Raise(IBattleEvent evt) => _bus.Publish(evt);
    }
}
