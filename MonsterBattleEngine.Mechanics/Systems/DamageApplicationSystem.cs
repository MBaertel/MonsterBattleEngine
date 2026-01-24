using MonsterBattleEngine.Core.Systems;
using MonsterBattleEngine.Mechanics.Events.MoveResolution.DamageApplied;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Mechanics.Systems
{
    public class DamageApplicationSystem
        : SystemBase<BeforeDamageApplied>
    {
        public DamageApplicationSystem() 
            : base("DamageApplicationSystem") { } 

        protected override void Process(BeforeDamageApplied evt)
        {
            var damage = evt.Damage;
            var target = evt.Target;
            target.TakeDamage(damage);

            var outEvent = new AfterDamageApplied(evt.Battle)
            {
                DamageApplied = damage,
                Target = target,
            };

            Raise(outEvent);
        }
    }
}
