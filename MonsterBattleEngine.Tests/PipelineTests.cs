using MonsterBattleEngine.Core.BattleFlow;
using MonsterBattleEngine.Core.BattleFlow.Interface;
using MonsterBattleEngine.Core.Events;
using MonsterBattleEngine.Core.Pipelines;
using MonsterBattleEngine.Tests.TestTypes;

namespace MonsterBattleEngine.Tests;

[TestClass]
public class PipelineTests
{
    private IBattleEventBus _bus = new BattleEventBus();
    private IPipeline _testPipeline;
    
    public PipelineTests()
    {
        var pl = new DynamicPipeline("testPipeline");
        pl.AddRule<TestEvent, TestEvent2>(e => new TestEvent2());
        pl.Register(_bus);
    }

    [TestMethod]
    public void BasicPipelineTest()
    {
        var evt = new TestEvent();
        _bus.Subscribe<TestEvent2>(this, (e) => Assert.IsInstanceOfType(e,typeof(TestEvent2)));
        _bus.Publish(evt);
    }

    [TestMethod]
    public void DontRaiseWrongEventTest()
    {
        var evt = new TestEvent();
        int fired = 0;
        _bus.Subscribe<TestEvent2>(this, (e) => fired++);
        _bus.Publish(evt);

        Assert.AreEqual(1, fired);
    }

    [TestMethod]
    public void OnlyRaiseInputOnce()
    {
        var evt = new TestEvent();
        int fired = 0;
        _bus.Subscribe<TestEvent>(this, (e) => fired++);
        _bus.Publish(evt);

        Assert.AreEqual(1, fired);
    }

    [TestMethod]
    public void BeforeAndAfterTest()
    {
        var evt = new TestEvent();
        var types = new List<Type>();
        
        _bus.Subscribe<IBattleEvent>(this, (e) => types.Add(e.GetType()));
        _bus.Publish(evt);

        Assert.Contains(typeof(TestEvent),types);
        Assert.Contains(typeof(TestEvent2), types);
    }
}
