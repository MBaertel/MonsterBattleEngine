using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Systems
{
    public interface ISystem
    {
        /// <summary>
        /// Name Of the System.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Check if this System can handle the passed event.
        /// </summary>
        bool CanHandle(IBattleEvent battleEvent);

        /// <summary>
        /// Method to register the system with the event bus.
        /// </summary>
        void Register(IBattleEventBus bus);
    }
}
