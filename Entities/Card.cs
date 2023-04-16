using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    internal class Card
    {
        private string suit;
        private string name;
        private int value;

        public Card(string suit, string name, int value)
        {
            this.Suit = suit;
            this.Name = name;
            this.Value = value;
        }

        public string Suit { get => suit; set => suit = value; }
        public string Name { get => name; set => name = value; }
        public int Value { get => value; set => this.value = value; }
    }
}
