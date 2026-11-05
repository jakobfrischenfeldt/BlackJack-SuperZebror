using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using static BlackJack_SuperZebror.Deck;

namespace BlackJack_SuperZebror
{
    public class Game
    {
        private Deck _deck;
        private Player _player;
        private Leaderboard _leaderboard;

        public Game()
        {
            _deck = new Deck();
            _leaderboard = new Leaderboard();
            // Load the leaderboard results from the JSON file
            _leaderboard.LoadResults();
        }
        //Main game loop
        public void Play()
        {
            Console.Clear();
            Console.WriteLine("-------Black Jack-------");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine() ?? "Player";

            // Create a new player with the entered name
            _player = new Player(name);

            //Mix the cards
            _deck.Shuffle();

            bool playing = true;
            while (playing && _player.Balance > 0)
            {
                PlayRound();

                if (_player.Balance <= 0)
                {
                    Console.WriteLine("You have run out of money! Game over.");
                    break;
                }

                Console.WriteLine("Do you want to play another round? (y/n)");
                string choice = Console.ReadLine()?.ToLower() ?? "";
                if (choice != "y")
                {
                    playing = false;
                }
            }

            Console.WriteLine("\nResults saved to leaderboard");

            //Create a new score result
            PlayerResult result = new PlayerResult
            {
                Name = _player.Name,
                FinalBalance = _player.Balance,
                RoundsPlayed = _player.RoundsPlayed
            };

            //Add final score
            _leaderboard.AddResult(result);
            _leaderboard.SaveResults();

            Console.WriteLine("\nThank you for playing!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        

        //Logic for running a single round of BJ
        private void PlayRound()
        {
            int CardsLeft = _deck.CardsLeft;
            //Register that a round has been played
            _player.RecordRound();

            Console.Clear();
            Console.WriteLine($"--- Round {_player.RoundsPlayed} ---");
            Console.WriteLine($"Current Balance: {_player.Balance} kr");

            //Ask the user for a valid bet amount
            int bet = GetValidBet();

            //Reshuffle the deck if there are fewer than 15 card left
            if (_deck.CardsLeft < 15)
            {
                Console.WriteLine("Not enough cards left in the deck. Game over.");
                _deck = new Deck();
                _deck.Shuffle();
            }

            //new hands for player and dealer
            Hand playerHand = new Hand();
            Hand dealerHand = new Hand();

            playerHand.AddCard(_deck.DrawCard());
            dealerHand.AddCard(_deck.DrawCard());
            playerHand.AddCard(_deck.DrawCard());
            dealerHand.AddCard(_deck.DrawCard());

            // Show current hands
            PrintTable(playerHand, dealerHand, hideDealerCard: true);

            bool playerhasBJ = playerHand.IsBlackjack();
            bool dealerhasBJ = dealerHand.IsBlackjack();

            if(playerhasBJ || dealerhasBJ)
            {
                PrintTable(playerHand, dealerHand, hideDealerCard: false);
                ResolveBlackjackPayout(playerhasBJ, dealerhasBJ, bet);
                //ends the round if somebody got blackjack
                return;
            }

            bool playerBusted = PlayerTurn(playerHand, dealerHand);
            if (playerBusted)
            {
                Console.WriteLine("You busted! You lose this round.");
                _player.Balance -= bet;
                Console.WriteLine($"Balance: {_player.Balance} kr.");
                return;
            }

            
            DealerTurn(dealerHand, playerHand);

            EvaluateWinner(playerHand, dealerHand, bet);
        }

        //Validate the input
        private int GetValidBet()
        {
            while (true)
            {
                Console.WriteLine($"Enter your bet(1- {_player.Balance}):");
                string input = Console.ReadLine() ?? "";

                //make sure the input is a whole number and whithin the available bet
                if (int.TryParse(input, out int bet) && bet >= 1 && bet <= _player.Balance)
                {
                    return bet;
                }

                Console.WriteLine("Invalid bet. Please enter a valid amount.");
            }
        }

        //Loop to handle if player chose to hit or stand
        private bool PlayerTurn(Hand playerHand, Hand dealerHand)
        {
            while (playerHand.GetTotalValue() < 21)
            {
                Console.WriteLine("Do you want to (h)it or (s)tand?");
                string choice = Console.ReadLine()?.ToLower() ?? "";

                if (choice == "h")
                {
                    var newCard = _deck.DrawCard();
                    playerHand.AddCard(newCard);
                    Console.WriteLine($"You drew a {newCard}");

                    PrintTable(playerHand, dealerHand, hideDealerCard: true);

                }
                else if (choice == "s")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 'h' or 's'.");
                }
            }

            //returns true if player got a total values over 21
            return playerHand.GetTotalValue() > 21;
        }

        private void DealerTurn(Hand dealerHand, Hand playerHand)
        {
            Console.Clear();
            Console.WriteLine("\nDealer shows their cards:");
            PrintTable(playerHand, dealerHand, hideDealerCard: false);

            //Dealer must draw intil a total of value is at least 17
            while (dealerHand.GetTotalValue() < 17)
            {
                var newCard = _deck.DrawCard();
                dealerHand.AddCard(newCard);
                Console.WriteLine($"Dealer drew a {newCard}");
                PrintTable(playerHand, dealerHand, hideDealerCard: false);
            }
            if (dealerHand.GetTotalValue() > 21)
            {
                Console.WriteLine("Dealer busted!");
            }
        }

        //Handles if anyone get an blackjack from start
        private void ResolveBlackjackPayout(bool playerBJ, bool dealerBJ, int bet)
        {
            if (playerBJ && dealerBJ)
            {
                Console.WriteLine("\nBoth of you got Blackjack!");
            }
            else if (playerBJ)
            {
                int bonusWin = (int)Math.Floor(bet * 1.5);
                Console.WriteLine($"\nBlackjack! You win {bonusWin} kr (3:2).");
                _player.Balance += bonusWin;
            }
            else if (dealerBJ)
            {
                Console.WriteLine($"\nDealer got Blackjack! You loose {bet} kr.");
                _player.Balance -= bet;
            }
            Console.WriteLine($"Saldo: {_player.Balance} kr.");
        }

        //Compares hands values and update the player balance based on final scores
        private void EvaluateWinner(Hand playerHand, Hand dealerHand, int bet)
        {
            int playerValue = playerHand.GetTotalValue();
            int dealerValue = dealerHand.GetTotalValue();

            if (dealerValue > 21)
            {
                Console.WriteLine($"\nDealer got more than 21! You win {bet} kr!");
                _player.Balance += bet;
            }
            else if (playerValue > dealerValue)
            {
                Console.WriteLine($"\nYou win {bet} kr.");
                _player.Balance += bet;
            }
            else if (playerValue < dealerValue)
            {
                Console.WriteLine($"\nDealer wins, you lose {bet} kr.");
                _player.Balance -= bet;
            }
            else
            {
                Console.WriteLine("\nIt's a tie! Your bet is returned");
            }

            Console.WriteLine($"Balance: {_player.Balance} kr.");
        }

        private void PrintTable(Hand playerHand, Hand dealerHand, bool hideDealerCard)
        {
            if (hideDealerCard && dealerHand.Cards.Count > 0)
            {
                Console.WriteLine($"Dealer: {dealerHand.Cards[0]} [?]");
            }
            else
            {
                Console.WriteLine($"Dealer:{dealerHand} = {dealerHand.GetTotalValue()}");
            }

            Console.WriteLine($"You: {playerHand} = {playerHand.GetTotalValue()}");
            Console.WriteLine();
        }
    }
}

