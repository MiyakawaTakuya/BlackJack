using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class User
    {
        internal string Name { get; set; }
        internal List<Card> HandList { get; set; }
        internal int Sum { get; set; }
        internal int Asset { get; set; }
        internal int Bet { get; set; }
        public User(string name)
        {
            Name = name;  //おいおいDB連携させる項目
            Asset = 10000;  //おいおいDB連携させる項目
            HandList = new List<Card>();
            Sum = 0;
            Bet = 0;  //掛け金
        }

        internal void First2Hit()
        {
            Console.WriteLine(Name + "へカードが２枚配られる");
            Hit();
            Hit();
            Console.WriteLine(Name + "の手札の合計値は"+ Sum + "だ");
        }

        internal void Hit()  
        {
            var tmp = Deck.Draw();
            Console.WriteLine(Name + "へ" + tmp.String +"("+ tmp.Mark + ")が配られた");
            HandList.Add(tmp);
            Sum += tmp.No_;
            //Sum = HandList.Select(d => d.No_).Sum();
        }
    }
}
