using MonsterBattleEngine.Core.Events;

namespace MonsterBattleEngine.Core.BattleFlow.Interface
{
    public interface IBattleEventBus
    {
        int Subscribe<T>(object owner,Action<T> handler, int priority = 0) where T : IBattleEvent;
        void SubscribeOnce<T>(object owner,Action<T> handler,int priority = 0) where T : IBattleEvent;
        
        void Unsubscribe<T>(object owner) where T : IBattleEvent;
        void Unsubscribe(int handlerId);
        void UnsubscribeAll(object owner);

        void Publish<T>(T evt) where T : IBattleEvent;
    }
}
