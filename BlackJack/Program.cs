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
            //ゲームスタートの設定
            Console.WriteLine("こちらはBlack Jackゲームです! あなたの名前を!!");
            Deck Deck = new Deck();
            Deck.list(List);

            //TODO APIをたたきプレイヤーデータ(id,name,asset,win,playTimes)を取り寄せ、セットする

            //プレイヤーの名前を入力と手札セット、掛け金セット、ディーラー引く
            string a = Console.ReadLine();  
            User player = new User(a);
            Console.WriteLine("Hi! "+ player.Name + "! ");
            player.First2Hit();
            Console.WriteLine(player.Name + "の自己資金は ¥" + player.Asset + "です. いくらベットしますか??");
            int bet = int.Parse(Console.ReadLine());
            player.Bet = bet;
            Console.WriteLine(player.Name + "が¥" + player.Bet + "をベットした");

            //ディーラーとのやりとりスタート
            //バーストするか引くのをやめるかするまで続く
            Dealer dealer = new Dealer();  
            dealer.Question(player);

            //(プレイヤー全員がバーストしていないければ)ディーラーが山札から引く
            if (player.Sum > 21)
            {
                Console.WriteLine("プレイヤーは負けたため掛け金を取られた");
                //掛け金を徴収する関数
            }
            else
            {
                Console.WriteLine("ディーラーのターン");
                dealer.First2Hit();
                dealer.HitOrNot();
                Console.WriteLine("ディーラーの伏せているカードを開示した。"+ dealer.HandList[0].String + "だった");
                Console.WriteLine("ディーラーの合計値は" + dealer.Sum + "となり");
                dealer.Judge();
            }

            //TODO APIをたたきプレイヤーデータ(id,name,asset,win,playTimes)へ反映させる

        }
    }
}
