using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack_SuperZebror
{
    public class Deck
    {
        private readonly List<Card> cards = new List<Card>();

        public int CardsLeft => cards.Count;

        public Deck()
        {
            CreateDeck();
            Shuffle();
        }
        public class Card
        {
            public string Suit;
            public string Value;

            

            public Card(string suit, string value)
            {
                Suit = suit;
                Value = value;
            }

            public int GetValue()
            {
                if (Value == "Jack" || Value == "Queen" || Value == "King")
                {
                    return 10;
                }
                else if (Value == "Ace")
                {
                    return 11;
                }
                else
                {
                    return int.Parse(Value);
                }
            }
        }


        public void CreateDeck()
            {
                string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

                string[] values =
                {
                "Ace", "2", "3", "4", "5", "6", "7",
                "8", "9", "10", "Jack", "Queen", "King"
                };


                foreach (string suit in suits)
                {
                    foreach (string value in values)
                    {
                        cards.Add(new Card(suit, value));
                    }
                }
            }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = cards.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);

                Card temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }

        public Card DrawCard()
        {
            Card card = cards[^1];
            cards.RemoveAt(cards.Count - 1);
            return card;
        }  
    }
}

