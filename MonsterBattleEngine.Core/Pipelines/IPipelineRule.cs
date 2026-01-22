using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Pipelines
{
    /// <summary>
    /// A rule that reacts to an event after all other handlers for that event are completed.
    /// </summary>
    public interface IPipelineRule
    {
        /// <summary>
        /// Test if this Rule can handle the input Event.
        /// </summary>
        /// <param name="evt">Event to test.</param>
        /// <returns></returns>
        bool CanHandle(IBattleEvent evt);

        /// <summary>
        /// Appply the rule.
        /// </summary>
        /// <param name="evt">Input Event.</param>
        IBattleEvent Apply(IBattleEvent evt);
    }
}
