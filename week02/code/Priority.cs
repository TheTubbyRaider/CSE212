using System;

public static class Priority
{
    public static void Test()
    {
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test 1
        Console.WriteLine("Test 1");
        priorityQueue.Enqueue("Item 1", 2);
        priorityQueue.Enqueue("Item 2", 1);
        Console.WriteLine(priorityQueue);
        try
        {
            Console.WriteLine(priorityQueue.Dequeue()); // Expected: Item 1
            Console.WriteLine(priorityQueue);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine("---------");

        // Test 2
        Console.WriteLine("Test 2");
        priorityQueue.Enqueue("Item 3", 3);
        priorityQueue.Enqueue("Item 4", 2);
        Console.WriteLine(priorityQueue);
        try
        {
            Console.WriteLine(priorityQueue.Dequeue()); // Expected: Item 3
            Console.WriteLine(priorityQueue);
            Console.WriteLine(priorityQueue.Dequeue()); // Expected: Item 4
            Console.WriteLine(priorityQueue);
            Console.WriteLine(priorityQueue.Dequeue()); // Expected: Item 2
            Console.WriteLine(priorityQueue);
            Console.WriteLine(priorityQueue.Dequeue()); // Expected error: Queue is empty
            Console.WriteLine(priorityQueue);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine("---------");

        // Additional Test Cases
        Console.WriteLine("Additional Test Cases");
        priorityQueue.Enqueue("Item 5", 1);
        priorityQueue.Enqueue("Item 6", 1);
        priorityQueue.Enqueue("Item 7", 3);
        Console.WriteLine(priorityQueue);
        try
        {
            Console.WriteLine(priorityQueue.Dequeue()); // Expected: Item 7
            Console.WriteLine(priorityQueue);
            Console.WriteLine(priorityQueue.Dequeue()); // Expected: Item 5
            Console.WriteLine(priorityQueue);
            Console.WriteLine(priorityQueue.Dequeue()); // Expected: Item 6
            Console.WriteLine(priorityQueue);
            Console.WriteLine(priorityQueue.Dequeue()); // Expected error: Queue is empty
            Console.WriteLine(priorityQueue);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine("---------");
    }
}
