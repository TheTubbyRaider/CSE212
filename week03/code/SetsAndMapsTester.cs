using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMapsTester {
    public static void Run() {
        // Problem 1: Find Pairs with Sets
        Console.WriteLine("\n=========== Finding Pairs TESTS ===========");
        DisplayPairs(new[] { "am", "at", "ma", "if", "fi" });
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "bc", "cd", "de", "ba" });
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "ba", "ac", "ad", "da", "ca" });
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "ac" });
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "aa", "ba" });
        Console.WriteLine("---------");
        DisplayPairs(new[] { "23", "84", "49", "13", "32", "46", "91", "99", "94", "31", "57", "14" });

        // Problem 2: Degree Summary
        Console.WriteLine("\n=========== Census TESTS ===========");
        var degreesSummary = SummarizeDegrees("census.txt");
        foreach (var kvp in degreesSummary) {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        // Problem 3: Anagrams
        Console.WriteLine("\n=========== Anagram TESTS ===========");
        Console.WriteLine(IsAnagram("CAT", "ACT")); // true
        Console.WriteLine(IsAnagram("DOG", "GOOD")); // false
        Console.WriteLine(IsAnagram("AABBCCDD", "ABCD")); // false
        Console.WriteLine(IsAnagram("ABCCD", "ABBCD")); // false
        Console.WriteLine(IsAnagram("BC", "AD")); // false
        Console.WriteLine(IsAnagram("Ab", "Ba")); // true
        Console.WriteLine(IsAnagram("A Decimal Point", "Im a Dot in Place")); // true
        Console.WriteLine(IsAnagram("tom marvolo riddle", "i am lord voldemort")); // true
        Console.WriteLine(IsAnagram("Eleven plus Two", "Twelve Plus One")); // true
        Console.WriteLine(IsAnagram("Eleven plus One", "Twelve Plus One")); // false

        // Problem 4: Maze
        Console.WriteLine("\n=========== Maze TESTS ===========");
        Dictionary<(int, int), bool[]> mazeMap = SetupMazeMap();
        var maze = new Maze(mazeMap);
        maze.ShowStatus(); // Should be at (1,1)
        maze.MoveUp(); // Error
        maze.MoveLeft(); // Error
        maze.MoveRight();
        maze.MoveRight(); // Error
        maze.MoveDown();
        maze.MoveDown();
        maze.MoveDown();
        maze.MoveRight();
        maze.MoveRight();
        maze.MoveUp();
        maze.MoveRight();
        maze.MoveDown();
        maze.MoveLeft();
        maze.MoveDown(); // Error
        maze.MoveRight();
        maze.MoveDown();
        maze.MoveDown();
        maze.MoveRight();
        maze.ShowStatus(); // Should be at (6,6)

        // Problem 5: Earthquake
        Console.WriteLine("\n=========== Earthquake TESTS ===========");
        EarthquakeDailySummary();
    }

    // Problem 1: DisplayPairs
    private static void DisplayPairs(string[] words) {
        HashSet<string> seen = new HashSet<string>();

        foreach (var word in words) {
            var reversed = new string(word.Reverse().ToArray());

            if (seen.Contains(reversed)) {
                Console.WriteLine($"{word} & {reversed}");
            }
            else {
                seen.Add(word);
            }
        }
    }

    // Problem 2: SummarizeDegrees
    private static Dictionary<string, int> SummarizeDegrees(string filename) {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename)) {
            var fields = line.Split(",");
            if (fields.Length >= 4) {
                var degree = fields[3].Trim();
                if (degrees.ContainsKey(degree)) {
                    degrees[degree]++;
                }
                else {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    // Problem 3: IsAnagram
    private static bool IsAnagram(string word1, string word2) {
        var dict1 = new Dictionary<char, int>();
        var dict2 = new Dictionary<char, int>();

        foreach (var ch in word1.ToLower()) {
            if (ch != ' ') {
                if (dict1.ContainsKey(ch)) {
                    dict1[ch]++;
                }
                else {
                    dict1[ch] = 1;
                }
            }
        }

        foreach (var ch in word2.ToLower()) {
            if (ch != ' ') {
                if (dict2.ContainsKey(ch)) {
                    dict2[ch]++;
                }
                else {
                    dict2[ch] = 1;
                }
            }
        }

        return dict1.Count == dict2.Count && dict1.All(kv => dict2.ContainsKey(kv.Key) && dict2[kv.Key] == kv.Value);
    }

    // Problem 4: Maze Operations
    private static Dictionary<(int, int), bool[]> SetupMazeMap() {
        Dictionary<(int, int), bool[]> map = new Dictionary<(int, int), bool[]> {
            // Your maze setup here
        };
        return map;
    }

    // Problem 5: EarthquakeDailySummary
    private static void EarthquakeDailySummary() {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(getRequestMessage);
        using var responseStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(responseStream);
        var json = reader.ReadToEnd();

        // Implement JSON deserialization classes here
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json);

        foreach (var feature in featureCollection.features) {
            Console.WriteLine($"{feature.properties.place} - Mag {feature.properties.mag}");
        }
    }
}
