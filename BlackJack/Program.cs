using System;
using System.Collections.Generic;
using System.Linq;
//API
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace BlackJack
{
    class Program
    {
        internal static List<Card> List = new List<Card>();
        internal static string Name;

        static void Main(string[] args)
        {
            //ゲームスタートの設定
            Console.WriteLine("こちらはBlack Jackゲームです! あなたの名前を!!");
            Deck Deck = new Deck();
            Deck.list(List);

            //TODO APIをたたきプレイヤーデータ(id,name,asset,win,playTimes)を取り寄せ、セットする
            getUser();

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

        //ユーザー情報を取り寄せるためのAPI
        internal static void getUser()
        {
            String url = "https://apiblackjack.azurewebsites.net/api/todoitems/"+"2";
            WebRequest request = WebRequest.Create(url);
            Stream response_stream = request.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(response_stream);
            var obj_from_json = JObject.Parse(reader.ReadToEnd());
            Console.WriteLine(obj_from_json);
            //var Name_ = obj_from_json["name"];
            Name = obj_from_json["name"].ToString();
            var Asset_ = obj_from_json["asset"];
            var numOfPlay_ = obj_from_json["numOfPlay"]; 

            Console.WriteLine("プレイヤー:"+ Name + ", 所持金:" + Asset_ + ", 今までの参加回数:" + numOfPlay_);
        }
    }
}
