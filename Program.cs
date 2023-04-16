// See https://aka.ms/new-console-template for more information
using BlackJack.Entities;

var deck = new Deck();

var player1 = new List<Card>();

var player2 = new List<Card>();

Random random = new Random();
int index = random.Next(0, deck.Cards.Count);
var randomCard = deck.Cards[index];
player1.Add(randomCard);
deck.Cards.RemoveAt(index);
Console.WriteLine("Has obtenido la carta {0} de {1}", randomCard.Name, randomCard.Suit);

