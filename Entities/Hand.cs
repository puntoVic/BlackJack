using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    internal class Hand
    {
        private List<Card> cards;

        internal List<Card> Cards { get => cards; set => cards = value; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        


        public void showCards()
        {
            foreach (Card card in this.Cards)
            {
                Console.WriteLine("Esta mano tiene la carta {0} de {1}", card.Name, card.Suit);
            }
        }

        public int Score()
        {
            int score = 0;
            int numAces = 0;

            foreach (Card card in this.Cards)
            {
                if (card.Name == "Ace")
                {
                    numAces++;
                    score += 11;
                }
                else if (card.Value >= 2 && card.Value <= 10)
                {
                    score += card.Value;
                }
                else
                {
                    score += 10;
                }
            }

            // Si hay Ases en la mano y la puntuación se pasa de 21, se restan 10 puntos por cada As hasta que la puntuación sea menor o igual a 21
            while (score > 21 && numAces > 0)
            {
                score -= 10;
                numAces--;
            }

            return score;
        }
    }
}
