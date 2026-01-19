using MonsterBattleEngine.Core.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Moves
{
    public class MoveBase : IMove
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }

        public int BasePower { get; }
        public int BaseAccuracy { get; } = 100;

        public MoveTypes MoveType { get; }
        public List<IBattleEffect> Effects { get; } = new();

        public MoveBase(string id, string name, int basePower, int baseAccuracy, MoveTypes moveType)
        {
            Id = id;
            Name = name;
            BasePower = basePower;
            BaseAccuracy = baseAccuracy;
            MoveType = moveType;
        }

        public virtual MoveBase AddEffect(IBattleEffect effect)
        {
            Effects.Add(effect);

            return this;
        }
    }
}
