using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerwin = 0;
            int masterwin = 0;
            //for (int x = 0; x < 1000; x++)
            //{
            Console.WriteLine("BlackJackを開始します");
            Console.WriteLine("準備が良ければEnterを押してください");
            Console.ReadLine();

            string[] motocard = new string[52] {"Da", "D2", "D3","D4", "D5", "D6","D7", "D8", "D9", "D10", "DJ", "DQ", "DK"
                                       , "Ha", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "HJ", "HQ", "HK"
                                       , "Ca","C2","C3","C4","C5","C6","C7","C8","C9","C10","CJ","CQ","CK"
                                       ,"Sa","S2","S3","S4","S5","S6","S7","S8","S9","S10","SJ","SQ","SK"};

            int[] motonum = new int[52] {101, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10
                                       , 101, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10
                                       ,101, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10
                                       , 101, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10};

            string[] card = new string[52] {"Da", "D2", "D3","D4", "D5", "D6","D7", "D8", "D9", "D10", "DJ", "DQ", "DK"
                                       , "Ha", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "HJ", "HQ", "HK"
                                       , "Ca","C2","C3","C4","C5","C6","C7","C8","C9","C10","CJ","CQ","CK"
                                       ,"Sa","S2","S3","S4","S5","S6","S7","S8","S9","S10","SJ","SQ","SK"};

            //マスター
            var masteraction = new Master();
            int masterresult = masteraction.Materman(motocard, motonum, card);
            card = masteraction.card;
            //Console.WriteLine(masterresult);
            int masterpoint = masterresult;
            if (masterpoint > 21)
            {
                masterpoint = 1;
            }

            string opencard = masteraction.m1;
            int masterplaycardnum = masteraction.playcardnum;
            Console.WriteLine("マスターは自分のカードを確認中です。。。");
            Console.WriteLine("準備が良ければEnterを押してください");
            Console.ReadLine();
            for (int x1 = 0; x1 < masterplaycardnum - 2; x1++)
            {
                Console.WriteLine($"【ヒット】マスターはさらにカードを引いています");
                Console.WriteLine("マスターは自分のカードを確認中です。。。");
                Console.WriteLine("準備が良ければEnterを押してください");
                Console.ReadLine();
            }

            Console.WriteLine($"【スタンド】マスターはこれ以上カードを引きません");
            Console.WriteLine($"マスターは現在{masterplaycardnum}枚のカードを所持しています");
            Console.WriteLine($"続いてプレイヤーの手順です");
            Console.WriteLine("準備が良ければEnterを押してください");
            Console.ReadLine();

            //プレイヤー
            Console.WriteLine("プレイヤーはまず2枚のカードを引きました");
            Console.WriteLine("プレイヤーは思考中です。。。");
            Console.WriteLine("準備が良ければEnterを押してください");
            Console.ReadLine();
            var playeraction = new Player();
            int playerresult = playeraction.playerman(motocard, motonum, card, opencard, masterplaycardnum);
            card = playeraction.card;
            //Console.WriteLine(playerresult);
            int playerpoint = playerresult;
            if (playerpoint > 21)
            {
                playerpoint = 0;
            }

            int playerplaycardnum = playeraction.playcardnum;
            for (int x2 = 0; x2 < playerplaycardnum - 2; x2++)
            {
                Console.WriteLine($"【ヒット】プレイヤーはさらにカードを引いています");
                Console.WriteLine("プレイヤーは自分のカードを確認中です。。。");
                Console.WriteLine("準備が良ければEnterを押してください");
                Console.ReadLine();
            }

            Console.WriteLine($"【スタンド】プレイヤーはこれ以上カードを引きません");
            Console.WriteLine($"プレイヤーは{playerplaycardnum}枚のカードを所持しています");
            //Console.WriteLine(playcardnum);


            //マスターとプレイヤーのカードオープン
            string syuturyoku1 = masteraction.playcard[0];
            for (int i3 = 1; i3 < masteraction.playcard.Length; i3++)
            {
                syuturyoku1 = syuturyoku1 + " ," + masteraction.playcard[i3];
            }

            string syuturyoku2 = playeraction.playcard[0];
            for (int i4 = 1; i4 < playeraction.playcard.Length; i4++)
            {
                syuturyoku2 = syuturyoku2 + " ," + playeraction.playcard[i4];
            }
            Console.WriteLine("準備が良ければEnterを押してください");
            Console.ReadLine();

            Console.WriteLine($"マスターのカードは{syuturyoku1}です");
            if (masterpoint == 1)
            {
                Console.WriteLine($"マスターはバーストしました");
            }
            else
            {
                Console.WriteLine($"マスターの点数は{masterpoint}です");
            }

            Console.WriteLine("準備が良ければEnterを押してください");
            Console.ReadLine();

            Console.WriteLine($"プレイヤーのカードは{syuturyoku2}です");
            if (playerpoint == 0)
            {
                Console.WriteLine($"プレイヤーはバーストしました");
            }
            else
            {
                Console.WriteLine($"プレイヤーの点数は{playerpoint}です");
            }

            //
            if (playerpoint > masterpoint)
            {
                playerwin = playerwin + 1;
                Console.WriteLine("プレイヤーの勝利です");

            }
            else if (masterpoint > playerpoint)
            {
                masterwin = masterwin + 1;
                Console.WriteLine("マスターの勝利です");
            }
            else
            {
                Console.WriteLine("引き分けです");
            }
            //}
            //Console.WriteLine($"{masterwin}");
            //Console.WriteLine($"{playerwin}");
        }
    }
}


