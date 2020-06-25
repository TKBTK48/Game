using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Master
    {
        public string m1;
        public string[] card;
        public string[] playcard=new string[2];
        public int playcardnum = 2;
        public int Materman(string[] motocard, int[] motonum, string[] card1)
        {
            string[] cardshuffle1 = card1.OrderBy(i => Guid.NewGuid()).ToArray();
            m1 = cardshuffle1[0];
            string m2 = cardshuffle1[1];
            var list = new List<string>();
            list.AddRange(card1);
            list.Remove(m1);
            list.Remove(m2);
            playcard[0] = m1;
            playcard[1] = m2;
            card1 = list.ToArray();
            Console.WriteLine($"マスターは2枚カードを引き、1枚は({m1})でした");
            int mastersum = 0;
            //1枚目のカードの数値化
            for (int i1 = 0; i1 < 52; i1++)
            {
                if (motocard[i1] == m1)
                {
                    mastersum = motonum[i1];
                }
            }
            //2枚目のカードの数値化
            for (int i2 = 0; i2 < 52; i2++)
            {
                if (motocard[i2] == m2)
                {
                    mastersum = mastersum + motonum[i2];
                }
            }

            int masterresult = mastersum;


            //エースの扱い方↓
            if (mastersum > 400)
            {
                masterresult = mastersum - 400;
                //or masterresult = mastersum-390;
            }

            else if (mastersum > 300)
            {
                masterresult = mastersum - 300;
                //or masterresult = mastersum-290;
            }

            else if (mastersum > 200)
            {
                masterresult = mastersum - 200;
                //or masterresult = mastersum-190;
            }

            else if (mastersum > 100)
            {
                masterresult = mastersum - 90;
                //or masterresult = mastersum -100;
            }
            //エースの扱い方↑

            //Console.WriteLine(m1);
            //Console.WriteLine(m2);

            //もう一枚引くかの判断
            for (int i2 = 0; masterresult < 17; i2++)
            {
                playcardnum = playcardnum + 1;
                cardshuffle1 = card1.OrderBy(i => Guid.NewGuid()).ToArray();
                string m3 = cardshuffle1[0];
                 Array.Resize(ref playcard, playcard.Length + 1);
                    playcard[playcard.Length - 1] = m3;
                //Console.WriteLine(masterresult);
                //Console.WriteLine(m3);

                for (int i3 = 0; i3 < 52; i3++)
                {
                    if (motocard[i3] == m3)
                    {
                        mastersum = mastersum + motonum[i3];
                        //Console.WriteLine(motonum[i3]);
                        //Console.WriteLine(mastersum);
                    }
                }
                list.AddRange(card1);
                list.Remove(m3);
                card1 = list.ToArray();
                int masterresult1;
                int masterresult2;
                if (mastersum > 100)
                {
                    if (mastersum > 400)
                    {
                        masterresult1 = mastersum - 400;
                        masterresult2 = mastersum - 390;
                        if (masterresult2 > 21)
                        {
                            masterresult = masterresult1;
                        }
                        else
                        {
                            masterresult = masterresult2;
                        }
                    }

                    else if (mastersum > 300)
                    {
                        masterresult1 = mastersum - 300;
                        masterresult2 = mastersum - 290;
                        if (masterresult2 > 21)
                        {
                            masterresult = masterresult1;
                        }
                        else
                        {
                            masterresult = masterresult2;
                        }
                    }

                    else if (mastersum > 200)
                    {
                        masterresult1 = mastersum - 200;
                        masterresult2 = mastersum - 190;
                        if (masterresult2 > 21)
                        {
                            masterresult = masterresult1;
                        }
                        else
                        {
                            masterresult = masterresult2;
                        }
                    }

                    else
                    {
                        masterresult1 = mastersum - 100;
                        masterresult2 = mastersum - 90;
                        if (masterresult2 > 21)
                        {
                            masterresult = masterresult1;
                        }
                        else
                        {
                            masterresult = masterresult2;
                        }
                    }
                }
                else
                {
                    masterresult = mastersum;
                }

            }
            card = card1;
            return masterresult;
        }
    }
}
