using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Player
    {
        public string[] card;
        public string[] playcard = new string[2];
        public int playcardnum = 2;
        public int playerman(string[] motocard, int[] motonum, string[] card1, string opencard, int pullcardnum)
        {
            string[] cardshuffle1 = card1.OrderBy(i => Guid.NewGuid()).ToArray();
            string m1 = cardshuffle1[0];
            string m2 = cardshuffle1[1];
            playcard[0] = m1;
            playcard[1] = m2;
            var list = new List<string>();
            list.AddRange(card1);
            list.Remove(m1);
            list.Remove(m2);
            card1 = list.ToArray();
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

            //もう一枚引くかの判断
            if (pullcardnum <= 5 || playerresult < 17)
            {
                for (int i2 = 0; playerresult < 17; i2++)
                {
                    playcardnum = playcardnum + 1;
                    cardshuffle1 = card1.OrderBy(i => Guid.NewGuid()).ToArray();
                    string m3 = cardshuffle1[0];
                    Array.Resize(ref playcard, playcard.Length + 1);
                    playcard[playcard.Length - 1] = m3;
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
                    list.AddRange(card1);
                    list.Remove(m3);
                    card1 = list.ToArray();
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

                }
            }
            card = card1;
            return playerresult;
        }
    }
}
