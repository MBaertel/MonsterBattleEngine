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
        /// Unique Name of this pipeline.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Registers Pipeline with the provided event bus.
        /// </summary>
        /// <param name="bus">Event Bus to register with.</param>
        void Register(IBattleEventBus bus);

        /// <summary>
        /// Unregister from the current bus.
        /// </summary>
        void Unregister();

        /// <summary>
        /// Get all rules in this Pipeline.
        /// </summary>
        IReadOnlyList<IPipelineRule> Rules { get; }
    }
}
