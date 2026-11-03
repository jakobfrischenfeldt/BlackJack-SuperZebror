Console.WriteLine("-------Black Jack-------");

Console.WriteLine("1. Start game");
Console.WriteLine("2. Leader board");
Console.WriteLine("3, Rules");
Console.WriteLine("4. Quit");









static void rulesOfGame()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Clear();
    Console.WriteLine("------Black-Jack Rules-------");
    Console.WriteLine("");
    Console.WriteLine("A game of Black-Jack consists of one dealer who deals cards and one or more players");
    Console.WriteLine("The goal of the game is for the players to beat the dealer by making choices based on the cards they got");
    Console.WriteLine("The players place bets and depending if they beat the dealer they either get more money back or they lose their bet");
    Console.WriteLine("");
    Console.WriteLine("When the cards are being dealt everybody (players and dealer) gets two cards");
    Console.WriteLine("The players can see their own two cards but won't show the other players or the dealer");
    Console.WriteLine("The dealer also gets two cards, one card facing up for everybody to see and one card facing down");
    Console.WriteLine();
    Console.WriteLine("To win the player either has to get 21 points (Black-Jack) or get closer to 21 than the dealer");
    Console.WriteLine("The numbered cards are worth as much as the number on the card");
    Console.WriteLine("For example two of hearts is 2 points and nine of spades is 9 points");
    Console.WriteLine("The face cards (J,Q,K) are all worth 10 points");
    Console.WriteLine("However the Ace (A) is worth either 11 points or 1 point depending on the situation");
    Console.WriteLine();

    Console.WriteLine("------Player Actions-------");
    Console.WriteLine("");
    Console.WriteLine("When it is the player's turn they have two choices: Hit or Stand");
    Console.WriteLine("If the player chooses to Hit they receive another card");
    Console.WriteLine("The player can keep hitting until they decide to Stand or get more than 21 points");
    Console.WriteLine("If the player chooses to Stand they keep their current points and their turn ends");
    Console.WriteLine("If a player gets more than 21 points they Bust and automatically lose the round");
    Console.WriteLine();

    Console.WriteLine("------Dealer Rules-------");
    Console.WriteLine("");
    Console.WriteLine("After all players have finished their turns it is the dealer's turn");
    Console.WriteLine("The dealer reveals their hidden card");
    Console.WriteLine("The dealer must keep drawing cards until they have at least 17 points");
    Console.WriteLine("If the dealer gets more than 21 points they Bust and all players who have not busted win");
    Console.WriteLine();

    Console.WriteLine("------Winning and Losing-------");
    Console.WriteLine("");
    Console.WriteLine("If the player has more points than the dealer without going over 21 the player wins");
    Console.WriteLine("If the dealer has more points than the player without going over 21 the player loses");
    Console.WriteLine("If both the player and dealer have the same amount of points it is a Tie (Push)");
    Console.WriteLine("When there is a Tie the player gets their original bet back");
    Console.WriteLine("If the player gets exactly 21 points with their first two cards they have a Black-Jack");
    Console.WriteLine("A Black-Jack normally pays 3:2, meaning the player wins 1.5 times their original bet");
    Console.WriteLine("If both the player and dealer get a Black-Jack it is a Tie");
    Console.WriteLine();

    Console.WriteLine("------Important Rules-------");
    Console.WriteLine("");
    Console.WriteLine("A player cannot Bust and then win even if the dealer also gets more than 21 points");
    Console.WriteLine("Once a player gets more than 21 points their round is over and they lose their bet");
    Console.WriteLine("The Ace automatically counts as 1 point if counting it as 11 would make the player Bust");
    Console.WriteLine("The goal is not always to get 21 points but to beat the dealer without going over 21");
    Console.WriteLine();

    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey();


}