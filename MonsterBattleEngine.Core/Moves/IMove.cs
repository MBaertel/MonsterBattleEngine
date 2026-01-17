using MonsterBattleEngine.Core.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.Moves
{
    public interface IMove
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }

        public int BasePower { get; }
        public int BaseAccuracy { get; }

        public MoveTypes MoveTypes { get; }
        public List<IBattleEffect> Effects { get; }
    }
}
