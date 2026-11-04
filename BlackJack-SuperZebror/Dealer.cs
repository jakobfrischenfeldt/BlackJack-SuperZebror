namespace BlackJack_SuperZebror;

public class Dealer
{
    // Stores the dealer's current hand
    public Hand Hand { get; private set; } = new();

    // Checks if the dealer must draw another card
    public bool ShouldHit()
    {
        return Hand.GetTotalValue() < 17;
    }

    // Creates a new empty hand for the next round
    public void ResetHand()
    {
        Hand = new Hand();
    }
}

