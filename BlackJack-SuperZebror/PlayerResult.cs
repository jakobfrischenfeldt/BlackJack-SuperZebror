using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack_SuperZebror;

//describes a player result

public class PlayerResult
{
    public string Name { get; set; } = "";
    public int FinalBalance { get; set; }
    public int RoundsPlayed { get; set; }

    // Stores all player results
    public List<PlayerResult> Results { get; set; } = new();

    // Adds a new player result to the list
    public void AddResult(PlayerResult newResult)
    {
        Results.Add(newResult);
    }
}