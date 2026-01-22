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
        private IBattleEventBus _bus;
        private bool _registered = false;

        public bool CanHandle(IBattleEvent battleEvent)
        {
            return battleEvent is TEvent;
        }

        public IBattleEvent Apply(IBattleEvent evt)
        {
            if (evt is TEvent tevt)
                return Transform(tevt);
            throw new ArgumentException("Rule can't handle event");
        }

        protected abstract IBattleEvent Transform(TEvent evt);
    }
}
