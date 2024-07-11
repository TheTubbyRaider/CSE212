public static class RecursionTester {
    /// <summary>
    /// Entry point for the Prove 8 tests
    /// </summary>
    public static void Run() {
        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        Console.WriteLine(SumSquaresRecursive(10)); // 385
        Console.WriteLine(SumSquaresRecursive(100)); // 338350

        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        PermutationsChoose("ABCD", 3);
        // Expected Result (order may be different):
        // ABC
        // ABD
        // ACB
        // ACD
        // ADB
        // ADC
        // BAC
        // BAD
        // BCA
        // BCD
        // BDA
        // BDC
        // CAB
        // CAD
        // CBA
        // CBD
        // CDA
        // CDB
        // DAB
        // DAC
        // DBA
        // DBC
        // DCA
        // DCB

        Console.WriteLine("---------");
        PermutationsChoose("ABCD", 2);
        // Expected Result (order may be different):
        // AB
        // AC
        // AD
        // BA
        // BC
        // BD
        // CA
        // CB
        // CD
        // DA
        // DB
        // DC

        Console.WriteLine("---------");
        PermutationsChoose("ABCD", 1);
        // Expected Result (order may be different):
        // A
        // B
        // C
        // D

        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        Console.WriteLine(CountWaysToClimb(5)); // 13
        Console.WriteLine(CountWaysToClimb(20)); // 121415
        // Uncomment out the test below after implementing memoization.  It won't work without it.
        // TODO Problem 3
        // Console.WriteLine(CountWaysToClimb(100));  // 180396380815100901214157639

        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 4 TESTS ===========");
        WildcardBinary("110*0*");
        // 110000
        // 110001
        // 110100
        // 110101
        WildcardBinary("***");
        // 000   
        // 001   
        // 010
        // 011
        // 100
        // 101
        // 110
        // 111

        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 5 TESTS ===========");
        Maze smallMaze = new Maze(3, 3, new[] { 1, 1, 1, 1, 0, 1, 1, 1, 2 });
        SolveMaze(smallMaze);
        // Two Solutions (order in each solution should match):
        // <List>{(0, 0), (0, 1), (0, 2), (1, 2), (2, 2)}
        // <List>{(0, 0), (1, 0), (2, 0), (2, 1), (2, 2)}

        Maze bigMaze = new(20, 20,
            new[] {
                1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1,
                0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0,
                0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1,
                0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1,
                0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1,
                1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1,
                0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1,
                0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1,
                0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
                0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1,
                1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0,
                0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0,
                0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1,
                0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0,
                1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 2
            });
        SolveMaze(bigMaze);
        // One Solution (order should match):
        // <List>{(0, 0), (0, 1), (0, 2), (0, 3), (1, 3), (2, 3), (3, 3), (3, 4), (3, 5),
        // (3, 6), (2, 6), (1, 6), (1, 7), (1, 8), (1, 9), (1, 10), (2, 10), (3, 10),
        // (4, 10), (5, 10), (5, 9), (5, 8), (5, 7), (5, 6), (5, 5), (5, 4), (5, 3),
        // (5, 2), (5, 1), (5, 0), (6, 0), (7, 0), (8, 0), (9, 0), (10, 0), (10, 1),
        // (10, 2), (10, 3), (10, 4), (10, 5), (10, 6), (9, 6), (8, 6), (8, 7), (8, 8),
        // (7, 8), (7, 9), (7, 10), (7, 11), (7, 12), (7, 13), (6, 13), (5, 13), (5, 14), 
        // (5, 15), (5, 16), (5, 17), (5, 18), (5, 19), (6, 19), (7, 19), (8, 19), (9, 19),
        // (10, 19), (11, 19), (12, 19), (12, 18), (12, 17), (12, 16), (12, 15), (12, 14),
        // (12, 13), (12, 12), (12, 11), (12, 10), (12, 9), (13, 9), (14, 9), (15, 9),
        // (15, 8), (15, 7), (15, 6), (15, 5), (14, 5), (13, 5), (12, 5), (12, 4), (12, 3),
        // (12, 2), (12, 1), (13, 1), (14, 1), (15, 1), (16, 1), (17, 1), (17, 2), (17, 3),
        // (17, 4), (17, 5), (18, 5), (19, 5), (19, 6), (19, 7), (19, 8), (19, 9), (19, 10),
        // (19, 11), (19, 12), (18, 12), (17, 12), (16, 12), (16, 13), (16, 14), (16, 15), 
        // (17, 15), (18, 15), (18, 16), (18, 17), (18, 18), (18, 19), (19, 19)}
    }

    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n &lt;= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n) {
        // Base case: if n is less than or equal to 0, return 0
        if (n <= 0) {
            return 0;
        }
        
        // Recursive case: sum of squares from 1^2 to n^2
        return n * n + SumSquaresRecursive(n - 1);
    }


    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion Print permutations of length
    /// 'size' from a list of 'letters'.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would display: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(string letters, int size, string word = "") {
        // Base case: if word length reaches size, print the word
        if (word.Length == size) {
            Console.WriteLine(word);
            return;
        }
        
        // Recursive case: iterate through each letter and recursively call with extended word
        for (int i = 0; i < letters.Length; i++) {
            PermutationsChoose(letters, size, word + letters[i]);
        }
    }


    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    ///
    /// The last test case is commented out because it will not work
    /// until the memoization is implemented.
    /// </summary>
public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null) {
    // Initialize the memoization dictionary if it's null
    if (remember == null) {
        remember = new Dictionary<int, decimal>();
    }
    
    // Base Cases
    if (s == 0)
        return 1; // Base case: 1 way to stay on the ground (doing nothing)
    if (s == 1)
        return 1; // Base case: 1 way to reach the first step
    if (s == 2)
        return 2; // Base case: 2 ways to reach the second step (1+1 or 2)
    if (s == 3)
        return 4; // Base case: 4 ways to reach the third step (1+1+1, 1+2, 2+1, 3)

    // Check if the result for s is already computed and memoized
    if (remember.ContainsKey(s)) {
        return remember[s];
    }

    // Recursive case: Calculate using memoization
    decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
    
    // Memoize the result for future use
    remember[s] = ways;
    
    return ways;
}


    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, display all possible binary strings for a given pattern.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern) {
        GenerateBinaryStrings(pattern, 0, "");
    }

    private static void GenerateBinaryStrings(string pattern, int index, string current) {
        // Base case: if index reaches end of pattern, print current binary string
        if (index == pattern.Length) {
            Console.WriteLine(current);
            return;
        }
        
        // Recursive case: check current character in pattern
        if (pattern[index] == '*') {
            // Replace '*' with '0' and recursively generate binary strings
            GenerateBinaryStrings(pattern, index + 1, current + '0');
            
            // Replace '*' with '1' and recursively generate binary strings
            GenerateBinaryStrings(pattern, index + 1, current + '1');
        } else {
            // Append the current character from pattern to current string and continue
            GenerateBinaryStrings(pattern, index + 1, current + pattern[index]);
        }
    }


    /// <summary>
    /// Use recursion to Print all paths that start at (0,0) and end at the
    /// 'end' square.
    /// </summary>
    public static void SolveMaze(Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null) {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        static void SolveMaze(int[,] maze, int x = 0, int y = 0, List<(int, int)>? currPath = null) {
    // Initialize currPath if it's null
    if (currPath == null) {
        currPath = new List<(int, int)>();
    }
    
    // Add current position to the path
    currPath.Add((x, y));

    // Check if we've reached the end of the maze
    if (IsEnd(maze, x, y)) {
        Console.WriteLine("Path found:");
        PrintPath(currPath);
        return;
    }

    // Try moving in all possible directions: right, left, down, up
    if (IsValidMove(maze, x + 1, y)) {
        SolveMaze(maze, x + 1, y, new List<(int, int)>(currPath)); // Move right
    }
    if (IsValidMove(maze, x - 1, y)) {
        SolveMaze(maze, x - 1, y, new List<(int, int)>(currPath)); // Move left
    }
    if (IsValidMove(maze, x, y + 1)) {
        SolveMaze(maze, x, y + 1, new List<(int, int)>(currPath)); // Move down
    }
    if (IsValidMove(maze, x, y - 1)) {
        SolveMaze(maze, x, y - 1, new List<(int, int)>(currPath)); // Move up
    }
    
    // Backtrack: remove current position from the path
    currPath.RemoveAt(currPath.Count - 1);
}

// Utility function to check if a position is the end of the maze
    static bool IsEnd(int[,] maze, int x, int y) {
        return maze[x, y] == 2;
    }

    // Utility function to check if a move is valid
    static bool IsValidMove(int[,] maze, int x, int y) {
        int n = maze.GetLength(0); // Assuming maze is square
        return x >= 0 && x < n && y >= 0 && y < n && maze[x, y] != 0; // Valid if within bounds and not a wall
    }

    // Utility function to print the current path
    static void PrintPath(List<(int, int)> path) {
        foreach (var point in path) {
            Console.Write($"({point.Item1},{point.Item2}) ");
        }
        Console.WriteLine();
    }


        // Console.WriteLine(currPath.AsString()); // Use this to print out your path when you find the solution
    }
}