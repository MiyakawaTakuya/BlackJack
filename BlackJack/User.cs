using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class User
    {
        internal string Name { get; set; }
        internal List<Card> HandList { get; set; }
        public User(string name)
        {
            Name = name;
            HandList = new List<Card>();
        }

        internal void Hit()  
        {
            var tmp = Deck.Hit();
            Console.WriteLine(Name + "はHitして、 " + tmp.Mark + "の" + tmp.String + "を引いた");
            HandList.Add(tmp);  
        }
    }
}
