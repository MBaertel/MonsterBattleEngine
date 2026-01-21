using MonsterBattleEngine.Core.BattleFlow.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Pipelines
{
    /// <summary>
    /// A Reactive container for pipeline rules.
    /// </summary>
    public interface IPipeline
    {
        /// <summary>
        /// Registers all rules in this pipeline with the provided event bus.
        /// </summary>
        /// <param name="bus">Event Bus to register with.</param>
        void Register(IBattleEventBus bus);
    }
}
