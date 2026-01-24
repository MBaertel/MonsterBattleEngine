using MonsterBattleEngine.Core.BattleFlow.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Events
{
    public abstract class EventBase : IBattleEvent
    {
        public Guid Id { get; }
        public Guid? CauseEventId { get; }
        public abstract string Name { get; }

        public virtual bool Cancellable { get; } = false;

        public bool IsCancelled { get; set; }

        public BattleState Battle { get; }

        protected EventBase(BattleState battle, Guid? causeEventId = null,bool isCancelled = false)
        {
            Id = Guid.NewGuid();
            Battle = battle;
            CauseEventId = causeEventId;
            IsCancelled = isCancelled;
        }

        protected EventBase(IBattleEvent cause)
        {
            if(cause == null)
                throw new ArgumentNullException(nameof(cause));

            Id = Guid.NewGuid();
            Battle = cause.Battle;
            CauseEventId = cause.CauseEventId;
            IsCancelled = cause.IsCancelled;
        }
    }
}
