using System.Text.Json;

public static class SetsAndMapsTester {
    public static void Run() {
        // Problem 1: Find Pairs with Sets
            static void DisplayPairs(string[] words)
            {
                HashSet<string> wordSet = new HashSet<string>(words);
                HashSet<string> pairs = new HashSet<string>();

                foreach (string word in words)
                {
                    string reversed = new string(word.Reverse().ToArray());
                    if (wordSet.Contains(reversed) && !pairs.Contains(word) && !pairs.Contains(reversed))
                    {
                        Console.WriteLine($"{word} & {reversed}");
                        pairs.Add(word);
                        pairs.Add(reversed);
                    }
                }
            }
        // Problem 2: Degree Summary
            private static Dictionary<string, int> SummarizeDegrees(string filePath)            {
                Dictionary<string, int> degreeSummary = new Dictionary<string, int>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Skip the header row
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string[] fields = reader.ReadLine().Split(',');
                        string degree = fields[3];

                        if (degreeSummary.ContainsKey(degree))
                        {
                            degreeSummary[degree]++;
                        }
                        else
                        {
                            degreeSummary[degree] = 1;
                        }
                    }
                }

                return degreeSummary;
            }

        // Problem 3: Anagrams
            public static bool IsAnagram(string word1, string word2)
            {
                // Remove spaces and convert to lowercase
                word1 = new string(word1.Replace(" ", "").ToLower().ToArray());
                word2 = new string(word2.Replace(" ", "").ToLower().ToArray());

                // Check if the lengths are different
                if (word1.Length != word2.Length)
                    return false;

                // Create dictionaries to store character counts
                Dictionary<char, int> charCount1 = new Dictionary<char, int>();
                Dictionary<char, int> charCount2 = new Dictionary<char, int>();

                // Count characters in each word
                foreach (char c in word1)
                {
                    if (charCount1.ContainsKey(c))
                        charCount1[c]++;
                    else
                        charCount1[c] = 1;
                }

                foreach (char c in word2)
                {
                    if (charCount2.ContainsKey(c))
                        charCount2[c]++;
                    else
                        charCount2[c] = 1;
                }

                // Compare character counts
                return charCount1.OrderBy(kvp => kvp.Key).SequenceEqual(charCount2.OrderBy(kvp => kvp.Key));
            }
        // Problem 4: Maze
            public class Maze
            {
                private Dictionary<ValueTuple<int, int>, bool[]> map;
                private ValueTuple<int, int> currentPosition;

                public Maze(Dictionary<ValueTuple<int, int>, bool[]> map)
                {
                    this.map = map;
                    currentPosition = new ValueTuple<int, int>(1, 1);
                }

                public void ShowStatus()
                {
                    Console.WriteLine($"Current position: ({currentPosition.Item1}, {currentPosition.Item2})");
                }

                public void MoveLeft()
                {
                    var newPosition = new ValueTuple<int, int>(currentPosition.Item1 - 1, currentPosition.Item2);
                    if (map.ContainsKey(newPosition) && map[newPosition][0])
                    {
                        currentPosition = newPosition;
                    }
                    else
                    {
                        Console.WriteLine("Cannot move left. Blocked by a wall.");
                    }
                }

                public void MoveRight()
                {
                    var newPosition = new ValueTuple<int, int>(currentPosition.Item1 + 1, currentPosition.Item2);
                    if (map.ContainsKey(newPosition) && map[newPosition][1])
                    {
                        currentPosition = newPosition;
                    }
                    else
                    {
                        Console.WriteLine("Cannot move right. Blocked by a wall.");
                    }
                }

                public void MoveUp()
                {
                    var newPosition = new ValueTuple<int, int>(currentPosition.Item1, currentPosition.Item2 - 1);
                    if (map.ContainsKey(newPosition) && map[newPosition][2])
                    {
                        currentPosition = newPosition;
                    }
                    else
                    {
                        Console.WriteLine("Cannot move up. Blocked by a wall.");
                    }
                }

                public void MoveDown()
                {
                    var newPosition = new ValueTuple<int, int>(currentPosition.Item1, currentPosition.Item2 + 1);
                    if (map.ContainsKey(newPosition) && map[newPosition][3])
                    {
                        currentPosition = newPosition;
                    }
                    else
                    {
                        Console.WriteLine("Cannot move down. Blocked by a wall.");
                    }
                }
            }
        // Problem 5: Earthquake
            using System;
            using System.Net.Http;
            using System.Text.Json;

            public class FeatureCollection
            {
                public Feature[] Features { get; set; }
            }

            public class Feature
            {
                public Properties Properties { get; set; }
            }

            public class Properties
            {
                public string Place { get; set; }
                public double Mag { get; set; }
            }

            private static async void EarthquakeDailySummary()
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson");
                    response.EnsureSuccessStatusCode();

                    var jsonData = await response.Content.ReadAsStringAsync();
                    var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(jsonData);

                    Console.WriteLine("\n=========== Earthquake TESTS ===========");
                    foreach (var feature in featureCollection.Features)
                    {
                        var properties = feature.Properties;
                        Console.WriteLine($"{properties.Place} - Mag {properties.Mag}");
                    }
                }
            }    }

    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for displaying all symmetric pairs of words.  
    ///
    /// For example, if <c>words</c> was: <c>[am, at, ma, if, fi]</c>, we would display:
    /// <code>
    /// am &amp; ma
    /// if &amp; fi
    /// </code>
    /// The order of the display above does not matter. <c>at</c> would not 
    /// be displayed because <c>ta</c> is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be displayed.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    private static void DisplayPairs(string[] words) {
        // To display the pair correctly use something like:
        // Console.WriteLine($"{word} & {pair}");
        // Each pair of words should displayed on its own line.
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    /// #############
    /// # Problem 2 #
    /// #############
    private static Dictionary<string, int> SummarizeDegrees(string filename) {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename)) {
            var fields = line.Split(",");
            // Todo Problem 2 - ADD YOUR CODE HERE
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    /// #############
    /// # Problem 3 #
    /// #############
    private static bool IsAnagram(string word1, string word2) {
        // Todo Problem 3 - ADD YOUR CODE HERE
        return false;
    }

    /// <summary>
    /// Sets up the maze dictionary for problem 4
    /// </summary>
    private static Dictionary<ValueTuple<int, int>, bool[]> SetupMazeMap() {
        Dictionary<ValueTuple<int, int>, bool[]> map = new() {
            { (1, 1), new[] { false, true, false, true } },
            { (1, 2), new[] { false, true, true, false } },
            { (1, 3), new[] { false, false, false, false } },
            { (1, 4), new[] { false, true, false, true } },
            { (1, 5), new[] { false, false, true, true } },
            { (1, 6), new[] { false, false, true, false } },
            { (2, 1), new[] { true, false, false, true } },
            { (2, 2), new[] { true, false, true, true } },
            { (2, 3), new[] { false, false, true, true } },
            { (2, 4), new[] { true, true, true, false } },
            { (2, 5), new[] { false, false, false, false } },
            { (2, 6), new[] { false, false, false, false } },
            { (3, 1), new[] { false, false, false, false } },
            { (3, 2), new[] { false, false, false, false } },
            { (3, 3), new[] { false, false, false, false } },
            { (3, 4), new[] { true, true, false, true } },
            { (3, 5), new[] { false, false, true, true } },
            { (3, 6), new[] { false, false, true, false } },
            { (4, 1), new[] { false, true, false, false } },
            { (4, 2), new[] { false, false, false, false } },
            { (4, 3), new[] { false, true, false, true } },
            { (4, 4), new[] { true, true, true, false } },
            { (4, 5), new[] { false, false, false, false } },
            { (4, 6), new[] { false, false, false, false } },
            { (5, 1), new[] { true, true, false, true } },
            { (5, 2), new[] { false, false, true, true } },
            { (5, 3), new[] { true, true, true, true } },
            { (5, 4), new[] { true, false, true, true } },
            { (5, 5), new[] { false, false, true, true } },
            { (5, 6), new[] { false, true, true, false } },
            { (6, 1), new[] { true, false, false, false } },
            { (6, 2), new[] { false, false, false, false } },
            { (6, 3), new[] { true, false, false, false } },
            { (6, 4), new[] { false, false, false, false } },
            { (6, 5), new[] { false, false, false, false } },
            { (6, 6), new[] { true, false, false, false } }
        };
        return map;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will print out a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    private static void EarthquakeDailySummary() {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to print out each place a earthquake has happened today and its magitude.
    }
}