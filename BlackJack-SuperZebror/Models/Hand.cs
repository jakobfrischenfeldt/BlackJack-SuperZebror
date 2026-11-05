using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack_SuperZebror
{
    public class Hand
    {
        //En lista som håller korten på just den här handen
        public List<Deck.Card> Cards { get; set; } = new List<Deck.Card>();

        //Metod för att lägga till ett kort i handen
        public void AddCard(Deck.Card card)
        {
           Cards.Add(card);
        }

        //Metod för att beräkna värdet av handen
        public int GetTotalValue()
        {
            int value = 0;
            int aceCount = 0;

            // Beräknar först värdet av handen och sedan antalet ess
            foreach (var card in Cards)
            {
                value += card.GetValue();
                if (card.Value == "Ace")
                {
                    aceCount++;
                }
            }
            // Hantera ess som kan vara 1 eller 11
            while (value > 21 && aceCount > 0)
            {
                value -= 10; // Ändra ett ess från 11 till 1
                aceCount--;
            }
            return value;
        }
        //metod för att se om det är en blackjack
        public bool IsBlackjack()
        {
            return GetTotalValue() == 21 && Cards.Count == 2;
        }

        //För att enkelt kunna skirva ut hela handen
        public override string ToString()
        {
            return string.Join(", ", Cards);
        }
    }
}
