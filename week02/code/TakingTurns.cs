public static class TakingTurns
{
    public static void Test()
    {
        // Test 1
        Console.WriteLine("Test 1");
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        while (players.Length > 0)
            players.GetNextPerson();
        Console.WriteLine("---------");

        // Test 2
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

        // Test 3
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

        // Test 4
        Console.WriteLine("Test 4");
        players = new TakingTurnsQueue();
        players.AddPerson("Tim", -3); // Tim has infinite turns
        players.AddPerson("Sue", 3);
        for (int i = 0; i < 10; i++)
        {
            players.GetNextPerson();
        }
        Console.WriteLine("---------");

        // Test 5
        Console.WriteLine("Test 5");
        players = new TakingTurnsQueue();
        players.GetNextPerson(); // Trying to get from empty queue
        Console.WriteLine("---------");
    }
}
