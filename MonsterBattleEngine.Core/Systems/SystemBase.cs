using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Systems
{
    public abstract class SystemBase<TEvent> : ISystem where TEvent : IBattleEvent
    {
        private IBattleEventBus _bus;
        private int _handlerId;
        public string Name { get; }

        public SystemBase(string name)
        {
            Name = name;
        }

        public bool CanHandle(IBattleEvent battleEvent) =>
            battleEvent.GetType() == typeof(TEvent);

        protected void Raise(IBattleEvent evt) =>
            _bus.Publish(evt);
        

        private void Execute(TEvent evt)
        {
            if (Condition(evt))
                Process(evt);
        }

        protected virtual bool Condition(TEvent evt) => true;

        protected abstract void Process(TEvent evt);

        public void Register(IBattleEventBus bus)
        {
            _bus = bus;
            _handlerId = bus.Subscribe<TEvent>(this,Execute);
        }
    }
}
