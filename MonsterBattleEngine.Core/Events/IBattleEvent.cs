using MonsterBattleEngine.Core.BattleFlow.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Events
{
    /// <summary>
    /// Interface for all Battle Events
    /// </summary>
    public interface IBattleEvent
    {
        /// <summary>
        /// Unique Event Identifier.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Id of the Event that caused this event, if any.
        /// </summary>
        Guid? CauseEventId { get; }

        /// <summary>
        /// Name of the event Phase (Used for non-generic handling)
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Determines wether the event can be Cancelled or not.
        /// </summary>
        bool Cancellable { get; }

        /// <summary>
        /// Sets Cancellation state. Ignored if not Cancellable.
        /// </summary>
        bool IsCancelled { get; set; }

        /// <summary>
        /// Current Battle State.
        /// </summary>
        BattleState Battle { get; }
    }
}
