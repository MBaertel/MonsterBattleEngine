using MonsterBattleEngine.Core.BattleFlow;
using MonsterBattleEngine.Core.BattleFlow.Data;
using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using MonsterBattleEngine.Tests.TestTypes;

namespace MonsterBattleEngine.Tests
{
    [TestClass]
    public sealed class EventBusTests
    {
        private IBattleEventBus _bus = new BattleEventBus();

        [TestMethod]
        public void BasicEventTest()
        {
            var evt = new TestEvent();

            _bus.Subscribe<IBattleEvent>(this, (e) => Assert.AreEqual(evt,e));
            _bus.Publish<IBattleEvent>(evt);
        }

        [TestMethod]
        public void NonGenericEventTest() 
        {
            var evt = new TestEvent();

            _bus.Subscribe<IBattleEvent>(this, (e) => Assert.AreEqual(evt, e));
            _bus.Publish(evt);
        }

        [TestMethod]
        public void TypedSubscriptionTest()
        {
            var evt = new TestEvent();
            _bus.Subscribe<TestEvent>(this, (e) => Assert.AreEqual(evt, e));
            _bus.Publish(evt);
        }

        [TestMethod]
        public void DifferentTypeEventTest()
        {
            var evt = new TestEvent2();
            bool fired = false;
            _bus.Subscribe<TestEvent>(this, (e) => fired = true);
            _bus.Publish(evt);
            Assert.IsFalse(fired);
        }

        [TestMethod]
        public void SubscribeOnceTest()
        {
            var evt = new TestEvent();
            int fired = 0;
            _bus.SubscribeOnce<IBattleEvent>(this, (e) => fired++);
            _bus.Publish(evt);
            _bus.Publish(evt);
            Assert.AreEqual(1,fired);
        }
    }
}
