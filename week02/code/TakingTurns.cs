public static class TakingTurns
{
    public static void Test()
    {
        // Test 1: Test normal queue behavior with finite turns
        Console.WriteLine("Test 1");
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        while (players.Length > 0)
            players.GetNextPerson();
        Console.WriteLine("---------");
        // Test 1 Result: All persons dequeued in correct order.

        // Test 2: Test adding a person during queue iteration
        Console.WriteLine("Test 2");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        for (int i = 0; i < 5; i++)
        {
            players.GetNextPerson();
        }

        players.AddPerson("George", 3);
        while (players.Length > 0)
            players.GetNextPerson();
        Console.WriteLine("---------");
        // Test 2 Result: All persons dequeued in correct order, with George added dynamically.

        // Test 3: Test handling a person with infinite turns
        Console.WriteLine("Test 3");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 0); // Tim has infinite turns
        players.AddPerson("Sue", 3);
        for (int i = 0; i < 10; i++)
        {
            players.GetNextPerson();
        }
        Console.WriteLine("---------");
        // Test 3 Result: All persons dequeued in correct order, Tim with infinite turns re-enqueued.

        // Test 4: Test handling negative turns (infinite turns)
        Console.WriteLine("Test 4");
        players = new TakingTurnsQueue();
        players.AddPerson("Tim", -3); // Tim has infinite turns
        players.AddPerson("Sue", 3);
        for (int i = 0; i < 10; i++)
        {
            players.GetNextPerson();
        }
        Console.WriteLine("---------");
        // Test 4 Result: All persons dequeued in correct order, Tim with negative turns re-enqueued.

        // Test 5: Test getting from an empty queue
        Console.WriteLine("Test 5");
        players = new TakingTurnsQueue();
        players.GetNextPerson(); // Trying to get from empty queue
        Console.WriteLine("---------");
        // Test 5 Result: Error message displayed for empty queue.
    }
}
