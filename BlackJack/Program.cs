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
using System.Net.Http.Headers;
using System.Text;
//using System.Net.Http.Json;

namespace BlackJack
{
    class Program
    {
        //TODO データ構造は整え中ーー
        internal static List<Card> List = new List<Card>();
        internal static List<User> players = new List<User>();
        internal static string Name;
        internal static int ID, Asset, numOfPlay;
        internal static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            //ゲームスタートの設定
            Console.WriteLine("「こちらはBlack Jackゲームです! あなたの名前を教えてくださいー」");
            Deck Deck = new Deck();
            Deck.list(List);

            //プレイヤーの名前入力 APIをたたきプレイヤーデータ(id,name,asset,win,playTimes)を取り寄せ、セットする
            string a = Console.ReadLine();
            GetUser(a);
            
            //手札セット、掛け金セット、ディーラー引く
            User player = new User(Name,Asset);
            //players.Add(player);
            Console.WriteLine("「やぁ！ "+ player.Name + "!」");
            Console.WriteLine(player.Name + "の自己資金は ¥" + player.Asset + "です. いくらベットしますか??");
            int bet = int.Parse(Console.ReadLine());
            player.Bet = bet;
            Console.WriteLine(player.Name + "が¥" + player.Bet + "ベットした");
            player.First2Hit();

            //TODO テスト 後で消す
            //TodoItem nowPlayer = new TodoItem() { Id = (long)ID, Name = Name, Asset = Asset - player.Bet, numOfPlay = numOfPlay };
            //Console.WriteLine(nowPlayer);
            //await putUser(ID,nowPlayer);

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
                players.Add(player);
                dealer.Judge(players);
            }
        }

        //ユーザー情報を取り寄せ API叩く関数
        internal static void GetUser(string name)
        {
            String url = "https://apiblackjack.azurewebsites.net/api/todoitems/" + name;
            WebRequest request = WebRequest.Create(url);
            Stream response_stream = request.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(response_stream);
            var obj_from_json = JObject.Parse(reader.ReadToEnd());
            //Console.WriteLine(obj_from_json);

            var id = (long)((JValue)obj_from_json["id"]).Value;
            ID = (int)id;
            Name = obj_from_json["name"].ToString();
            var ass = (long)((JValue)obj_from_json["asset"]).Value;
            Asset = (int)ass;
            var num = (long)((JValue)obj_from_json["numOfPlay"]).Value;
            numOfPlay = (int)num;

            Console.WriteLine("【Player Data】プレイヤー:"+ Name + ", 所持金:¥" + Asset + ", 今までの参加回数:" + numOfPlay);
        }

        //ユーザー情報を更新する API叩く関数
        internal static async Task PutUser(int id, TodoItem nowPlayer)
        {
            String url = "https://apiblackjack.azurewebsites.net/api/todoitems/" + id.ToString();
            //HTTP　PUT要求を送信する
            try
            {
                var jsonString = JsonConvert.SerializeObject(nowPlayer);
                var data = new StringContent(jsonString, Encoding.UTF8, mediaType: "application/json");
                var response = await client.PutAsync(url, data);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("更新処理 完了です");
        }
    }
}
