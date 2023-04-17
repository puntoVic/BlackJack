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
        var player1 = new List<Card>();
        var crupier = new List<Card>();
        bool response = true;
        
        initCards(player1, deck);
        initCards(crupier, deck);
        
        do
        {

            Console.WriteLine("Tus cartas ahora son:");
            showCards(player1);
            if (Score(player1)>21)
                break;
            if (deck.Count > 0)
            {
                Console.WriteLine("Deseas recibir otra carta?(valid responses: hit,h,stand,s)");
                response = responseInterpretation(Console.ReadLine());
            }
            if (response)
            {
                index = random.Next(0, deck.Count);
                var randomCard = deck[index];
                Console.WriteLine("Has obtenido la carta {0} de {1}", randomCard.Name, randomCard.Suit);
                player1.Add(randomCard);
                deck.RemoveAt(index);
                showCards(player1);
            }

        }while(response);

        while (Score(crupier) < 17 && deck.Count > 0)
        {
            index = random.Next(0, deck.Count);
            var randomCard = deck[index];
            crupier.Add(randomCard);
            deck.RemoveAt(index);
            Console.WriteLine("El crupier pide otra carta.");
            
        }
        showCards(crupier);
        int crupierScore = Score(crupier);
        int player1Score = Score(player1);

        if (crupierScore > player1Score && crupierScore <= 21)
        {
            Console.WriteLine("El crupier gana");
        }
        else if (player1Score <= 21)
        {
            Console.WriteLine("Ganaste!!!!");
        }
        else if (crupierScore == player1Score)
        {
            Console.WriteLine("Empate");
        }
        else
        {
            Console.WriteLine("Nadie gana");
        }


        Console.WriteLine("Deseas jugar de nuevo?(y/n)");
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

void initCards(List<Card> player, List<Card> deck)
{
    for (int j = 0; j < 2; j++)
    {
        int index = random.Next(0, deck.Count);
        var randomCard = deck[index];
        player.Add(randomCard); 
        deck.RemoveAt(index);
    }
}

void showCards(List<Card> player)
{
    foreach(Card card in player)
    {
        Console.WriteLine("Tienes la carta {0} de {1}", card.Name, card.Suit);
    }
}

int Score(List<Card> hand)
{
    int score = 0;
    int numAces = 0;

    foreach (Card card in hand)
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

