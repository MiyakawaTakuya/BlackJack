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
            Console.WriteLine("Welcome to Black Jack Game! Please tell me Your name!!");
            Deck Deck = new Deck();
            Deck.list(List);
            
            string a = Console.ReadLine();  //プレイヤーの名前を入力する
            User player = new User(a);
            player.Hit();
            player.Hit();
            var sum = player.HandList.Select(d => d.No_).Sum();
            Console.WriteLine("今の"+ player.Name +"手札の中はこんな感じで、合計値は" + sum +"となっているよ");

            Dealer dealer = new Dealer();  //ディーラーとのやりとりスタート
            dealer.Question(player);

        }
    }
}
