using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    class Program
    {
        internal static List<Card> List = new List<Card>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Black Jack!");
            Deck Deck = new Deck();
            Deck.list(List);
            Console.WriteLine(List);
        }
    }
}
