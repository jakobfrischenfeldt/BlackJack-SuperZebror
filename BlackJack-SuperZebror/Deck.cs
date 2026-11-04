using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack_SuperZebror
{
    public class Deck
    {
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








        public class Deck
        {
            private List<Card> cards = new List<Card>();

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

            public void ShuffleDeck()
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



        }
    }
}

