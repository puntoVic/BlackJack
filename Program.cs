// See https://aka.ms/new-console-template for more information
using BlackJack.Entities;
using System.Collections.Generic;
using System.Numerics;

Random random = new Random();
gaming();
void gaming()
{
    var deck = new Deck().Cards;
    bool gameOver = false;

    while (!gameOver)
    {
        int index;
        var player1 = new Hand();
        var crupier = new Hand();
        bool response = true;
        
        initCards(player1.Cards, deck, nameof(player1));
        initCards(crupier.Cards, deck, nameof(crupier));
        
        do
        {

            if (player1.Score()>21)
                break;
            if (deck.Count > 0)
            {
                Console.WriteLine("\nDeseas recibir otra carta?(valid responses: hit,h,stand,s)");
                response = responseInterpretation(Console.ReadLine());
            }
            if (response)
            {
                hit(player1.Cards, deck, nameof(player1));
                player1.showCards();
            }

        }while(response);

        while (crupier.Score() < 17 && deck.Count > 0)
        {
            hit(crupier.Cards, deck, nameof(crupier));
            Console.WriteLine("\nEl crupier pide otra carta.");
            
        }
        crupier.showCards();
        int crupierScore = crupier.Score();
        int player1Score = player1.Score();

        if (crupierScore > player1Score && crupierScore <= 21)
        {
            Console.WriteLine("\nEl crupier gana");
        }
        else if (player1Score <= 21)
        {
            Console.WriteLine("\nGanaste!!!!");
        }
        else if (crupierScore == player1Score)
        {
            Console.WriteLine("\nEmpate");
        }
        else
        {
            Console.WriteLine("\nNadie gana");
        }


        Console.WriteLine("\nDeseas jugar de nuevo?(y/n)");
        gameOver = !(Console.ReadLine()?.ToLower() == "y");

    }
}

bool responseInterpretation(string? response)
{
    if (response != null)
    {
        response = response.ToLower();
        return response == "hit" || response == "h" || response == "stand" || response == "s";
    }
    return false;
}

void initCards(List<Card> player, List<Card> deck, string name)
{
    for (int j = 0; j < 2; j++)
    {
        hit(player, deck, name);
    }
}

void hit(List<Card> player, List<Card> deck, string name) 
{
    int index = random.Next(0, deck.Count);
    var randomCard = deck[index];
    player.Add(randomCard);
    deck.RemoveAt(index);
    Console.WriteLine("\nSe agrega la carta {0} de {1} a la mano del {2}", randomCard.Name, randomCard.Suit, name);
}


