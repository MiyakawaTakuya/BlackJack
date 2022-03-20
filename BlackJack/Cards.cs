using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Card
    {
	    internal string Mark { get; set; }
		internal int No_ { get; set; }

        internal Card(string mark, int no)  //コンストラクタ
        {
            Mark = mark;
            No_ = no;
        }

        //トランプの数字表記を一部変換しつつ、文字列に変換して返す
        internal string String
        {
            get
            {
                switch (No_)
                {
                    case 1:
                        return "A";
                    case 11:
                        return "J";
                    case 12:
                        return "Q";
                    case 13:
                        return "K";
                }
                return No_.ToString();
            }
        }

        //トランプの数字表記のうち,11~13を10ポイントに変換する
        internal int Point
        {
            get
            {
                switch (No_)
                {
                    case 11:
                        return 10;
                    case 12:
                        return 10;
                    case 13:
                        return 10;
                }
                return No_;
            }
        }

    }
}
