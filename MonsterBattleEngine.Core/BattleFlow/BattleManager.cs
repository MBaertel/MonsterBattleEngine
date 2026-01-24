using MonsterBattleEngine.Core.BattleFlow.Data;
using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using MonsterBattleEngine.Core.Pipelines;
using MonsterBattleEngine.Core.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterBattleEngine.Core.BattleFlow
{
    public abstract class BattleManagerBase : IBattleManager
    {
        public BattleState Battle { get; }
        public IBattleEventBus Bus { get; }

        private List<ISystem> Systems { get; } = new();
        private List<IPipeline> Pipelines { get; } = new();

        public BattleManagerBase()
        {
            Battle = new BattleState();
            Bus = new BattleEventBus();
            Configure();
            RegisterSystems();
            RegisterPipelines();
        }

        private void RegisterSystems()
        {
            Systems.ForEach(x => x.Register(Bus));
        }

        private void RegisterPipelines()
        {
            Pipelines.ForEach(x => x.Register(Bus));
        }

        protected virtual void Configure() { }

        protected void AddSystem(ISystem system)
        {
            Systems.Add(system); 
        }

        protected void AddPipeline(IPipeline pipeline)
        {
            Pipelines.Add(pipeline); 
        }

        protected DynamicPipeline CreatePipeline(string name)
        {
            var pl = new DynamicPipeline(name);
            Pipelines.Add(pl);
            return pl;
        }
    }
}
