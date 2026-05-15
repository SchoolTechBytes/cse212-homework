using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 3 items with different priotities: low=1, mid=5, high=10.
    //           Dequeue should return then in priorty order: high, mid, low.
    // Expected Result: "High", "Mid", "Low"
    // Defect(s) Found: 1. In the Dequeue for loop "< _queue.Count - 1" was skipping the last element and was not considered in the priorty.
    // 2. The winning item was never removed from the list (RemoveAt was missing).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Mid", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Mid", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue 3 items where 2 are the same highest priority (IE: priority=7).
    //           The first Enqueued should be dequeued first (FIFO tie-breaker).
    // Expected Result: "First" "Second", then "Third".
    // Defect(s) Found: 1. the loop used ">=" insted of ">" when comparing the priorities,
    // which replaced the current best index with any equal-priority item encountered later, this broke the FIFO order
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 7);
        priorityQueue.Enqueue("Second", 7);
        priorityQueue.Enqueue("Third", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException thrown with message "The queue is empty."
    // Defect(s) Found: None - this path was already implemented correctly.
    public void TestPriorityQueue_3_EmptyThrows()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue a single item and dequeue it. Queue should be empty afterward.
    // Expected Result: The single item's value is returned; a second Dequeue throws.
    // Defect(s) Found: Without the RemoveAt fix, the item stayed in the queue forever
    //                  and this test would loop/pass incorrectly on the second Dequeue.
    public void TestPriorityQueue_4_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Only", 3);

        Assert.AreEqual("Only", priorityQueue.Dequeue());

        // Queue should now be empty
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException after queue is emptied.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}