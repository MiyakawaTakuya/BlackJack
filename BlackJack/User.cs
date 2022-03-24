using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class TodoItem  //DBのput用 WebAPIに登録してある名前・構成と一致させている 名前はtest用の時の名残
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Asset { get; set; }
        public int numOfPlay { get; set; }
    }

    public class User
    {
        internal string Name { get; set; }
        internal List<Card> HandList { get; set; }
        internal int Sum { get; set; }
        internal int Asset { get; set; }
        internal int Bet { get; set; }

        public User(string name, int asset)
        {
            Name = name;  
            Asset = asset;
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
            Sum += tmp.Point;
        }
    }
}
