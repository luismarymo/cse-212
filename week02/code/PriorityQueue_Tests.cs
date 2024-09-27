using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items (L, priority 1 and M, priority 4, N, priority 2)
    //to the queue to ensure they were properly enqueued
    // Expected Result: [L (Pri:1), M (Pri:4)]
    // Defect(s) Found: None.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("L", 1);
        priorityQueue.Enqueue("M", 4);
        priorityQueue.Enqueue("N", 2);

        Assert.AreEqual("[L (Pri:1), M (Pri:4), N (Pri:2)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Add items (L, priority 1, M, priority 4, N, priority 2) to queue and
    //dequeue in correct order of priority
    // Expected Result: M, N, L
    // Defect(s) Found: Items were not actually being removed from the queue and
    //the for loop to check for highest priority item was starting at index 1
    //an not inclusive of the last index.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("L", 1);
        priorityQueue.Enqueue("M", 4);
        priorityQueue.Enqueue("N", 2);

        Assert.AreEqual("M",priorityQueue.Dequeue());
        Assert.AreEqual("N",priorityQueue.Dequeue());
        Assert.AreEqual("L",priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items (L, priority 1, M, priority 4, N, priority 2, O, priority 4) to
    //queue and dequeue in correct order of priority, even when the priority is the same
    // Expected Result: M, O, N, L
    // Defect(s) Found: If statement inside for loop was using a higher than or equal,
    //which caused it to change the highest priority item to items further than the queue
    //with the same priority
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("L", 1);
        priorityQueue.Enqueue("M", 4);
        priorityQueue.Enqueue("N", 2);
        priorityQueue.Enqueue("O", 4);

        Assert.AreEqual("M",priorityQueue.Dequeue());
        Assert.AreEqual("O",priorityQueue.Dequeue());
        Assert.AreEqual("N",priorityQueue.Dequeue());
        Assert.AreEqual("L",priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue an empty queue, which should throw an error
    // Expected Result: Exception should be thrown with a error message
    // Defect(s) Found: None
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Add items (L, priority 1, M, priority 4) then dequeue once,
    //then add another item (N, priority 2) and dequeue once again.
    // Expected Result: M, N, L
    // Defect(s) Found: None
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("L", 1);
        priorityQueue.Enqueue("M", 4);

        Assert.AreEqual("M",priorityQueue.Dequeue());

        priorityQueue.Enqueue("N", 2);

        Assert.AreEqual("N",priorityQueue.Dequeue());
        Assert.AreEqual("L",priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}