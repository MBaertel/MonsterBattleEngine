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
        /// Registers all rules in this pipeline with the provided event bus.
        /// </summary>
        /// <param name="bus">Event Bus to register with.</param>
        void Register(IBattleEventBus bus);

        /// <summary>
        /// Get all rules in this Pipeline.
        /// </summary>
        IEnumerable<IPipelineRule> Rules { get; }
    }
}
