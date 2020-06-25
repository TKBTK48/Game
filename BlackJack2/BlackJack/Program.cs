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
            Console.WriteLine($"続いてあなたの手順です");
            Console.WriteLine("準備が良ければEnterを押してください");
            Console.ReadLine();

            //プレイヤー
            Console.WriteLine("あなたはまず2枚のカードを引きました");

            string[] playerplaycard = new string[2];
            string[] cardshuffle1 = card.OrderBy(i => Guid.NewGuid()).ToArray();
            string m1 = cardshuffle1[0];
            string m2 = cardshuffle1[1];
            playerplaycard[0] = m1;
            playerplaycard[1] = m2;
            Console.WriteLine("準備が良ければEnterを押してください");
            Console.ReadLine();
            Console.WriteLine($"1枚目は{m1}です");
            Console.WriteLine($"2枚目は{m2}です");
            Console.WriteLine("準備が良ければEnterを押してください");
            Console.ReadLine();
            var list = new List<string>();
            list.AddRange(card);
            list.Remove(m1);
            list.Remove(m2);
            card = list.ToArray();
            //Console.WriteLine($"マスターは2枚カードを引き、1枚は({m1})でした");
            int playersum = 0;
            //1枚目のカードの数値化
            for (int i1 = 0; i1 < 52; i1++)
            {
                if (motocard[i1] == m1)
                {
                    playersum = motonum[i1];
                }
            }
            //2枚目のカードの数値化
            for (int i2 = 0; i2 < 52; i2++)
            {
                if (motocard[i2] == m2)
                {
                    playersum = playersum + motonum[i2];
                }
            }

            int playerresult = playersum;


            //エースの扱い方↓
            if (playersum > 400)
            {
                playerresult = playersum - 400;
                //or masterresult = mastersum-390;
            }

            else if (playersum > 300)
            {
                playerresult = playersum - 300;
                //or masterresult = mastersum-290;
            }

            else if (playersum > 200)
            {
                playerresult = playersum - 200;
                //or masterresult = mastersum-190;
            }

            else if (playersum > 100)
            {
                playerresult = playersum - 90;
                //or masterresult = mastersum -100;
            }
            //エースの扱い方↑

            //Console.WriteLine(m1);
            //Console.WriteLine(m2);




            //ルーティン開始
            //もう一枚引くかの判断
            while (true)
            {
                Console.WriteLine("あなたはもう一枚カードを引きますか？");
                int ans = 100;
                while (true)
                {
                    Console.WriteLine("【ヒット】引く場合は「0」を入力してください");
                    Console.WriteLine("【スタンド】引かない場合は「1」を入力してください");
                    try
                    {
                        ans = int.Parse(Console.ReadLine());
                        if (ans == 0 || ans == 1)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("不正な値です。再入力してください。");
                            continue;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("不正な値です。再入力してください。");
                        continue;
                    }
                }
                if (ans == 1)
                {
                    Console.WriteLine("あなたの手順はこれで完了です");
                    Console.WriteLine("準備が良ければEnterを押してください");
                    Console.ReadLine();
                    break;
                }
                cardshuffle1 = card.OrderBy(i => Guid.NewGuid()).ToArray();
                string m3 = cardshuffle1[0];
                Array.Resize(ref playerplaycard, playerplaycard.Length + 1);
                playerplaycard[playerplaycard.Length - 1] = m3;
                //Console.WriteLine(playerresult);
                //Console.WriteLine(m3);

                for (int i3 = 0; i3 < 52; i3++)
                {
                    if (motocard[i3] == m3)
                    {
                        playersum = playersum + motonum[i3];
                        // Console.WriteLine(motonum[i3]);
                        //Console.WriteLine(playersum);
                    }
                }
                Console.WriteLine($"新しいカードは{m3}です");
                list.AddRange(card);
                list.Remove(m3);
                card = list.ToArray();
                string syuturyoku3 = playerplaycard[0];
                for (int i5 = 1; i5 < playerplaycard.Length; i5++)
                {
                    syuturyoku3 = syuturyoku3 + " ," + playerplaycard[i5];
                }
                Console.WriteLine($"現時点でのあなたのすべてのカードは{syuturyoku3}です");
                Console.WriteLine("確認次第、Enterを押してください");
                Console.ReadLine();
            }






            //結果確認
            int playerresult1;
            int playerresult2;
            if (playersum > 100)
            {
                if (playersum > 400)
                {
                    playerresult1 = playersum - 400;
                    playerresult2 = playersum - 390;
                    if (playerresult2 > 21)
                    {
                        playerresult = playerresult1;
                    }
                    else
                    {
                        playerresult = playerresult2;
                    }
                }

                else if (playersum > 300)
                {
                    playerresult1 = playersum - 300;
                    playerresult2 = playersum - 290;
                    if (playerresult2 > 21)
                    {
                        playerresult = playerresult1;
                    }
                    else
                    {
                        playerresult = playerresult2;
                    }
                }

                else if (playersum > 200)
                {
                    playerresult1 = playersum - 200;
                    playerresult2 = playersum - 190;
                    if (playerresult2 > 21)
                    {
                        playerresult = playerresult1;
                    }
                    else
                    {
                        playerresult = playerresult2;
                    }
                }

                else
                {
                    playerresult1 = playersum - 100;
                    playerresult2 = playersum - 90;
                    if (playerresult2 > 21)
                    {
                        playerresult = playerresult1;
                    }
                    else
                    {
                        playerresult = playerresult2;
                    }
                }
            }
            else
            {
                playerresult = playersum;
            }



            int playerpoint = playerresult;
            if (playerpoint > 21)
            {
                playerpoint = 0;
            }

            //マスターとプレイヤーのカードオープン
            string syuturyoku1 = masteraction.playcard[0];
            for (int i3 = 1; i3 < masteraction.playcard.Length; i3++)
            {
                syuturyoku1 = syuturyoku1 + " ," + masteraction.playcard[i3];
            }

            string syuturyoku2 = playerplaycard[0];
            for (int i4 = 1; i4 < playerplaycard.Length; i4++)
            {
                syuturyoku2 = syuturyoku2 + " ," + playerplaycard[i4];
            }
            Console.WriteLine("互いのカードのオープンに入ります。Enterを押してください");
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

            Console.WriteLine($"あなたのカードは{syuturyoku2}です");
            if (playerpoint == 0)
            {
                Console.WriteLine($"あなたはバーストしました");
            }
            else
            {
                Console.WriteLine($"あなたの点数は{playerpoint}です");
            }

            //
            if (playerpoint > masterpoint)
            {
                playerwin = playerwin + 1;
                Console.WriteLine("あなたの勝利です");

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


