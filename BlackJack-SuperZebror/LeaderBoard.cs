using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BlackJack_SuperZebror;

public class Leaderboard
{
    // Stores all player results in a list
    public List<PlayerResult> Results { get; set; } = new();

    // Adds a new player result to the list
    public void AddResult(PlayerResult newResult)
    {
        Results.Add(newResult);
    }

    // Converts the results into JSON and saves them to a file
    public void SaveResults()


    {

        string json = JsonSerializer.Serialize(Results);

        File.WriteAllText("leaderboard.json", json);

        Console.WriteLine(Path.GetFullPath("leaderboard.json"));
    }

    // Loads saved results from the JSON file
    public void LoadResults()
    {
        // Checks if the file exists
        if (!File.Exists("leaderboard.json"))
        {
            Results = new();
            return;
        }

        try
        {
            // Reads the text from the JSON file
            string json = File.ReadAllText("leaderboard.json");

            // Converts JSON text back into a list of player results
            Results = JsonSerializer.Deserialize<List<PlayerResult>>(json) ?? new();
        }
        catch (JsonException)
        {
            // Creates an empty list if the JSON is invalid
            Results = new();
        }
        catch (IOException)
        {
            // Creates an empty list if the file cannot be read
            Results = new();
        }
    }
    // Returns the five players with the highest balance
    public List<PlayerResult> GetTopFive()
    {
        return Results
            .OrderByDescending(result => result.FinalBalance)
            .Take(5)
            .ToList();
    }

    // Displays the five best results in the console
    public void ShowTopFive()
    {
        Console.WriteLine("=== Leaderboard ===");

        int position = 1;

        foreach (PlayerResult result in GetTopFive())
        {
            Console.WriteLine($"{position}. {result.Name} - {result.FinalBalance} kr ({result.RoundsPlayed} rounds)");

            position++;
        }
    }
    public void ShowLeaderBoard()
    {
      LoadResults();
      ShowTopFive();
      Console.WriteLine("\nPress any key to return to menu.");
      Console.ReadKey();
    }
}
