using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayerCards = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {
                int firstCard = firstPlayerCards[0];
                int secondCard = secondPlayerCards[0];

                if (firstCard > secondCard)
                {
                    firstPlayerCards.Add(firstCard);
                    firstPlayerCards.Add(secondCard);
                }
                else if (firstCard < secondCard)
                {
                    secondPlayerCards.Add(secondCard);
                    secondPlayerCards.Add(firstCard);
                }
                firstPlayerCards.RemoveAt(0);
                secondPlayerCards.RemoveAt(0);
            }
            if (firstPlayerCards.Count > 0)
            {
                Console.WriteLine( $"First player wins! Sum: {GetCardSum(firstPlayerCards)}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {GetCardSum(secondPlayerCards)}");
            }
        }

        static int GetCardSum(List<int> playerCards)
        {
            int sum = 0;
            foreach (int card in playerCards)
            {
                sum += card;
            }
            return sum;
        }
    }
}
