using MonsterBattleEngine.Core.Moves;
using MonsterBattleEngine.Core.Systems;
using MonsterBattleEngine.Mechanics.Events.MoveResolution.DamageCalculated;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Mechanics.Systems
{
    public class DamageCalculationSystem
        : SystemBase<BeforeDamageCalculated>
    {
        public DamageCalculationSystem() 
            : base("DamageCalculationSystem") { }

        protected override void Process(BeforeDamageCalculated evt)
        {
            var basePower = evt.MoveUsed.BasePower;
            if (basePower == 0) Complete(evt, 0);
            
            int attackPower = 0;
            if (evt.MoveUsed.MoveType == MoveTypes.Physical)
                attackPower = evt.Attacker.BaseStats.Attack;
            else if (evt.MoveUsed.MoveType == MoveTypes.Special)
                attackPower = evt.Attacker.BaseStats.SpecialAttack;

            if (attackPower == 0) Complete(evt, 0);

            var damage = basePower * attackPower;

            Complete(evt, damage);
        }

        private void Complete(BeforeDamageCalculated evt,int damage)
        {
            var outEvent = new AfterDamageCalculated(evt.Battle)
            {
                Damage = damage,
                MoveUsed = evt.MoveUsed,
                Target = evt.Defender
            };
            Raise(outEvent);
        }
    }
}
