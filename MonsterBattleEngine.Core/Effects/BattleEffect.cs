using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Combatants;
using MonsterBattleEngine.Core.Events;
using MonsterBattleEngine.Core.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Effects
{
    public abstract class BattleEffect<TEvent> : SystemBase<TEvent>, IBattleEffect
        where TEvent : IBattleEvent
    {
        public CombatantBase Owner { get; }
        protected BattleEffect(IBattleEventBus bus, string name,CombatantBase owner)
            : base(bus, name) 
        {
            Owner = owner;
        }
    }
}
