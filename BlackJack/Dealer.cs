using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Dealer
    {
        public Dealer()
        {
        }

        internal void Question(User player)
        {
            var sum = player.HandList.Select(d => d.No_).Sum();
            Console.WriteLine("続けてカードをひきますか？引く場合は 'T'、引かない場合は'F'を入力してください");
            string a = Console.ReadLine();
            if (a == "T")
            {
                player.Hit();
                sum = player.HandList.Select(d => d.No_).Sum();
                if (sum > 21)
                {
                    Console.WriteLine("Burst！！ 合計値が" + sum + "となり、２１を超えてしまった！！！GAME OVERだ！！どんまい！！");
                }
                else
                {
                    Console.WriteLine("今の手札の合計値は" + sum + "だ");
                    Question(player);
                }
            }
            else if (a == "F")
            {
                Console.WriteLine(player.Name + "はカードを引くのをやめた");
                Console.WriteLine("今の手札の合計値は" + sum + "だ。こちらで勝負します");
            }
            else
            {
                Console.WriteLine("入力情報が適切ではないようです");
                Question(player);
            }
        }
    }
}
