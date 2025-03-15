using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add an item to the back of the queue (with data and priority): 20 (2)
    // Then add a second item to ensure it is added to the back: 40 (1)
    // Expected Result: Items should be added to the back of the list with the final result = [20 (Pri:2), 40 (Pri:1)]
    // Defect(s) Found: none
    public void TestPriorityQueue_AddItemToBackofQueue()
    {
        var priorityQueue = new PriorityQueue();

        string expectedResult1 = "[20 (Pri:2)]";
        string expectedResult2 = "[20 (Pri:2), 40 (Pri:1)]";

        priorityQueue.Enqueue("20", 2);
        Assert.AreEqual(expectedResult1, priorityQueue.ToString());
        priorityQueue.Enqueue("40", 1);
        Assert.AreEqual(expectedResult2, priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Create a queue with the following items: 20 (2), 30 (3), 40 (4) 
    // Then Dequeue the item with the highest priority and return the value of that item
    // Expected Result: Dequeue result should be "30" and queue state should be "[20 (Pri:2), 40 (Pri:1)]"
    // Defect(s) Found: Dequeue was not removing the item from the list 
    // and Dequeue was not checking the priority of the last item in the list
    public void TestPriorityQueue_RemoveItemWithHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        
        string expectedResult = "40";
        string expectedQueueState = "[20 (Pri:2), 30 (Pri:3)]";

        priorityQueue.Enqueue("20", 2);
        priorityQueue.Enqueue("30", 3);
        priorityQueue.Enqueue("40", 4);
        var result = priorityQueue.Dequeue();
        
        Assert.AreEqual(expectedResult, result);
        Assert.AreEqual(expectedQueueState, priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Create a queue where there are multiple items with the highest priority: 20 (2), 30 (3), 40 (1), 50 (3)
    // Expected Result: Item closest to the front should be removed
    // with the return value being "30" and the queue state should be "[20 (Pri:2), 40 (Pri:1)], 50 (Pri:3)"
    // Defect(s) Found: The item closest to the front was not removed, 
    // the last item with highest priority was removed instead.
    public void TestPriorityQueue_MultipleItemsWithHighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        string expectedResult = "30";
        string expectedQueueState = "[20 (Pri:2), 40 (Pri:1), 50 (Pri:3)]";

        priorityQueue.Enqueue("20", 2);
        priorityQueue.Enqueue("30", 3);
        priorityQueue.Enqueue("40", 1);
        priorityQueue.Enqueue("50", 3);
        var result = priorityQueue.Dequeue();
        
        Assert.AreEqual(expectedResult, result);
        Assert.AreEqual(expectedQueueState, priorityQueue.ToString());

    }

    [TestMethod]
    // Scenario: Create an empty queue and then try to dequeue it. 
    // Expected Result: An exception should be thrown with an appropriate message.
    // Defect(s) Found: none
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            var result = priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }

    }
}