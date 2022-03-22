using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Dealer
    {
        internal string Name { get; set; }
        internal List<Card> HandList { get; set; }
        internal int Sum { get; set; }
        public Dealer()
        {
            Name = "ディーラー";
            HandList = new List<Card>();
            Sum = 0;
        }

        internal void Question(User player)
        {
            Console.WriteLine("続けてカードをひきますか？引く場合は 'y'、引かない場合は'n'を入力してください");
            string a = Console.ReadLine();
            if (a == "y")
            {
                player.Hit();
                if (player.Sum > 21)
                {
                    Console.WriteLine("Burst！！ 合計値が" + player.Sum + "となり、２１を超えてしまった！！！GAME OVERだ！！どんまい！！");
                }
                else
                {
                    Console.WriteLine("今の手札の合計値は" + player.Sum + "だ");
                    Question(player);
                }
            }
            else if (a == "n")
            {
                Console.WriteLine(player.Name + "はカードを引くのをやめた");
                Console.WriteLine("今の手札の合計値は" + player.Sum + "だ。こちらで勝負します");
            }
            else
            {
                Console.WriteLine("入力情報が適切ではないようです");
                Question(player);
            }
        }

        internal void First2Hit()
        {
            Console.WriteLine(Name + "はカードを２枚引く");
            Hit();
            Hit();
            Console.WriteLine(Name + "の手札の一枚は伏せてあり、もう一枚は" + HandList[1].String + "だ");
        }

        internal void Hit()
        {
            var tmp = Deck.Draw();
            HandList.Add(tmp);
            Sum += tmp.No_;
        }

        internal void HitOrNot()
        {
            if (Sum<=17)
            {
                var tmp = Deck.Draw();
                Console.WriteLine(Name + "は" + tmp.String + "(" + tmp.Mark + ")を引いた");
                HandList.Add(tmp);
                Sum += tmp.No_;
                Console.WriteLine(Name + "の目に見える札の合計は" + (Sum - HandList[0].No_) + "だ");
                HitOrNot();
            }
            else //if(Sum > 17 && Sum <=21)
            {
                Console.WriteLine(Name + "はカードを引くのを止めた");
            }
        }

        internal void Judge()
        {
            Console.WriteLine("勝負の結果...");
            //21以下のHandList.SumのスコアListを作成し、Maxだった人の名前を開示
            if (Sum>21)
            {
                Console.WriteLine("ディーラーはバーストしていたので、"+"〇〇の勝利");
            }
            else
            {

            }
        }
    }
}
