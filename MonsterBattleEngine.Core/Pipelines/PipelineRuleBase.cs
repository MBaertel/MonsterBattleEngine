using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Pipelines
{
    public abstract class PipelineRuleBase<TIn,TOut> : IPipelineRule
        where TIn : IBattleEvent
        where TOut : IBattleEvent
    {
        private IBattleEventBus _bus;
        private bool _registered = false;

        public Type From => typeof(TIn);
        public Type To => typeof(TOut);

        public bool CanHandle(IBattleEvent battleEvent)
        {
            return battleEvent is TIn;
        }

        protected abstract TOut Transform(TIn evt);

        private void Handle(TIn evt)
        {
            var outEvt = Transform(evt);
            _bus.Publish<TOut>(outEvt);
        }

        public void Register(IBattleEventBus bus)
        {
            if (_registered) return;
            _bus = bus;
            _bus.Subscribe<TIn>(this, Handle,-1);
            _registered = true;
        }

        public void Unregister()
        {
            if(!_registered || _bus == null) return;
            _bus.Unsubscribe<TIn>(this);
            _registered = false;
        }
    }
}
