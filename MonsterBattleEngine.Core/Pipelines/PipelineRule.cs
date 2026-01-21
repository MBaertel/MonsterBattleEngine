using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Pipelines
{
    public class PipelineRule<TEvent> : IPipelineRule
        where TEvent : IBattleEvent
    {
        private readonly IBattleEventBus _bus;
        public PipelineRule(IBattleEventBus bus)
        {
            _bus = bus;
        }

        public bool CanHandle(IBattleEvent battleEvent)
        {
            return battleEvent is TEvent;
        }

        public void Apply(IBattleEvent evt)
        {
            if (CanHandle(evt))
                OnEventCompleted(evt);
        }

        protected abstract void OnEventCompleted(TEvent evt);
    }
}
