using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Systems
{
    public class LambdaSystem<TEvent> : SystemBase<TEvent> where TEvent : IBattleEvent
    {
        private Action<TEvent> _lambda;
        public LambdaSystem(IBattleEventBus bus,string name,Action<TEvent> lambda)
            :base(name)
        {
            _lambda = lambda;
            Register(bus);
        }

        protected override void Process(TEvent evt)
        {
            _lambda(evt);
        }
    }
}
