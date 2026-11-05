
namespace BlackJack_SuperZebror;

// Represents the player in the Blackjack game
public class Player
{
    // Stores the player's name
    public string Name { get; set; }

    // Player starts with 100 kr
    public int Balance { get; set; } = 100;

    // Counts how many rounds the player has played
    public int RoundsPlayed { get; set; } = 0;

    // Stores the player's current hand of cards
    public Hand Hand { get; } = new Hand();

    // Creates a new player with a name
    public Player(string name)
    {
        Name = name;
    }

    // Increases the number of rounds played by one
    public void RecordRound()
    {
        RoundsPlayed++;
    }
}

