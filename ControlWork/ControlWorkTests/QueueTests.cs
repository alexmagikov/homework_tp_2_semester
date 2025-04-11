using ControlWork;

namespace ControlWorkTests;

public class Tests
{
    [Test]
    public void TestForNormalValue_ShouldEmptyReturnTrueValue()
    {
        var queue = new Queue();
        queue.Enqueue(2, 1);
        queue.Enqueue(3, 2);
        Assert.That(queue.Empty, Is.False);
    }
    
    [Test]
    public void TestForNormalValue_ShouldEnqueueReturnNormalValue()
    {
        var queue = new Queue();
        queue.Enqueue(2, 1);
        queue.Enqueue(3, 2);
        Assert.That(queue.Dequeue(), Is.EqualTo(3));
    }
    
    [Test]
    public void TestForEqualPriority_ShouldEnqueueReturnNormalValue()
    {
        var queue = new Queue();
        queue.Enqueue(2, 1);
        queue.Enqueue(3, 1);
        Assert.That(queue.Dequeue(), Is.EqualTo(2));
    }
    
    [Test]
    public void TestForNullQueue_ShouldDequeueReturnNormalValue()
    {
        var queue = new Queue();
        Assert.Throws<NullValueException>(() => queue.Dequeue());
    }
    
    [Test]
    public void TestForNullQueue_ShouldEmptyReturnNormalValue()
    {
        var queue = new Queue();
        Assert.That(queue.Empty, Is.True);
    }
    
    [Test]
    public void TestForManyValue_ShouldDequeueReturnNormalValue()
    {
        var queue = new Queue();
        queue.Enqueue(2, 1);
        queue.Enqueue(3, 2);
        queue.Enqueue(4, 2);
        queue.Enqueue(6, 3);
        Assert.That( new int[] {queue.Dequeue(), queue.Dequeue(), queue.Dequeue(), queue.Dequeue()}, 
            Is.EqualTo(new int[] {6, 3, 4, 2}));
    }
    
    [Test]
    public void TestForMoreThan10Value_ShouldQueueReturnNormalValue()
    {
        var queue = new Queue();
        for (var i = 0; i < 12; i++)
        {
            queue.Enqueue(i, i);
        }
        Assert.That(queue.Dequeue(), Is.EqualTo(11));
        for (var i = 10; i >= 0; i--)
        {
            Assert.That(queue.Dequeue(), Is.EqualTo(i));
        }
    }
}