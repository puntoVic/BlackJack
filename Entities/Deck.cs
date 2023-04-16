using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class Deck
    {
        private List<Card> cards;
        public Deck()
        {
            Cards = new List<Card>();

            string[] suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
            string[] names = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

            foreach (string suit in suits)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    Card card = new Card(suit, names[i], values[i]);
                    Cards.Add(card);
                }
            }
        }

        internal List<Card> Cards { get => cards; set => cards = value; }
    }
}
