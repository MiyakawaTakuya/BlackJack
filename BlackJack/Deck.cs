using System;
using System.Collections.Generic;
using System.Linq;

//【ゲーム開始時】
//・52枚のカードを山札として、先ほど作成したCardクラスのListを作成する
//・山札をシャッフルする

//【カードを引く時】
//・プレイヤーやディーラーがカードを引く時、山札のうち1枚を取得する
//・その取得したCardを、山札からRemoveする
//・取得したCardをreturnする
//→これで、カードを引いたことになる

namespace BlackJack
{
    internal class Deck
    {
        internal void list(List<Card> list_)  //デッキリストの生成とシャッフル
        {
            for (int i=0;i<4;i++)
            {
                if(i == 0) Generate("D", list_); //ダイヤ
                else if (i == 1) Generate("S", list_); //スペード
                else if (i == 2) Generate("H", list_); //ハート
                else if (i == 3) Generate("C", list_); //クローバー
            }
            //シャッフルする
            Random ran = new Random();
            for (int i = list_.Count - 1; i > 0; i--)
            {
                int j = ran.Next(0, i + 1); // ランダムで要素番号を１つ選ぶ（ランダム要素）
                var temp = list_[i]; // 一番最後の要素を仮確保（temp）にいれる
                list_[i] = list_[j]; // ランダム要素を一番最後にいれる
                list_[j] = temp; // 仮確保を元ランダム要素に上書き
            }
        }

        internal void Generate(string mark, List<Card> list_)
        {
            for (int j = 1; j <= 13; j++)
            {
                list_.Add(new Card(mark,j));
            }
        }

        internal static Card Hit()
        {
            Card tmp = Program.List[0];
            Program.List.RemoveAt(0);
            return tmp;
        }

    }
}
