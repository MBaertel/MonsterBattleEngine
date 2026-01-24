using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.BattleFlow
{
    public class BattleEventBus : IBattleEventBus
    {
        private struct HandlerInfo
        {
            public int Id;
            public object Owner;
            public Delegate Handler;
            public int Priority;
            public bool Once;
        }

        private readonly Dictionary<Type, List<HandlerInfo>> _handlers = new();
        private int _nextHandlerId = 1;

        public void Publish<T>(T evt) where T : IBattleEvent
        {
            var eventType = evt.GetType();

            // Collect matching handlers first to avoid modifying collections while iterating
            var toInvoke = new List<(Type type, HandlerInfo handler)>();

            foreach (var (handlerType, handlers) in _handlers)
            {
                if (!handlerType.IsAssignableFrom(eventType))
                    continue;

                foreach (var handler in handlers)
                {
                    toInvoke.Add((handlerType, handler));
                }
            }

            // Order by priority (higher runs first — flip if you want the opposite)
            foreach (var (type, handlerInfo) in toInvoke
                         .OrderByDescending(h => h.handler.Priority))
            {
                handlerInfo.Handler.DynamicInvoke(evt);

                if (handlerInfo.Once)
                {
                    _handlers[type].RemoveAll(h => h.Id == handlerInfo.Id);
                }
            }
        }

        public int Subscribe<T>(object owner, Action<T> handler, int priority = 0) where T : IBattleEvent
        {
            return AddHandler(owner, handler, priority, once: false);
        }

        public void SubscribeOnce<T>(object owner, Action<T> handler, int priority = 0) where T : IBattleEvent
        {
            AddHandler(owner, handler, priority, once: true);
        }

        public void Unsubscribe<T>(object owner) where T : IBattleEvent
        {
            var type = typeof(T);
            if (!_handlers.TryGetValue(type, out var handlers)) return;

            handlers.RemoveAll(h => h.Owner == owner);
        }

        public void Unsubscribe(int handlerId)
        {
            foreach (var kvp in _handlers)
            {
                kvp.Value.RemoveAll(h => h.Id == handlerId);
            }
        }

        public void UnsubscribeAll(object owner)
        {
            foreach (var kvp in _handlers)
            {
                kvp.Value.RemoveAll(h => h.Owner == owner);
            }
        }

        private int AddHandler<T>(object owner,Action<T> handler,int priority,bool once = false)
        {
            var type = typeof(T);
            if (!_handlers.ContainsKey(type))
                _handlers[type] = new List<HandlerInfo>();

            var info = new HandlerInfo
            {
                Id = _nextHandlerId++,
                Owner = owner,
                Handler = handler,
                Priority = priority,
                Once = once
            };

            _handlers[type].Add(info);
            return info.Id;
        }
    }
}
