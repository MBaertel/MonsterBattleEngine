using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.BattleFlow
{
    public class BattleEventBus : IBattleEventBus
    {
        public void Publish<T>(T evt) where T : IBattleEvent
        {
            throw new NotImplementedException();
        }

        public int Subscribe<T>(object owner, Action<T> handler, int priority = 0) where T : IBattleEvent
        {
            throw new NotImplementedException();
        }

        public void SubscribeOnce<T>(object owner, Action<T> handler, int priority = 0) where T : IBattleEvent
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T>(object owner) where T : IBattleEvent
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(int handlerId)
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeAll(object owner)
        {
            throw new NotImplementedException();
        }
    }
}
