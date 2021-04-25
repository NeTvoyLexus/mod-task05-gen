using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{
    public class Text1
    {
        private int[,] arr;
        private Random random = new Random();
        private int sum;
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";

        public void TextGen(int num)
        {
            using (StreamWriter sw = new StreamWriter("Text1.txt"))
            {
                for (int k = 0; k < num; ++k)
                {
                    int r = random.Next(0, sum);
                    int tempSum = 0;
                    bool flag = true;
                    for (int i = 0; i < 31; ++i)
                    {
                        if (!flag)
                        {
                            break;
                        }
                        for (int j = 0; j < 31; ++j)
                        {
                            if (!flag)
                            {
                                break;
                            }
                            tempSum += arr[i, j];
                            if ((tempSum >= r) && (arr[i, j] != 0))
                            {
                                sw.Write(syms[i]);
                                sw.Write(syms[j]);
                                sw.Write(" ");
                                flag = false;
                            }
                        }
                    }
                }
            }
        }

        public Text1(string fileName)
        {
            sum = 0;
            arr = new int[31, 31];
            using (StreamReader sr = new StreamReader(fileName))
            {
                for (int i = 0; i < 31; ++i)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(new Char[] { ' ' });
                    for (int j = 0; j < 31; ++j)
                    {
                        arr[i, j] = Int32.Parse(temp[j]);
                        sum += arr[i, j];
                    }
                }
            }
        }

    }
    public class Text2
    {
        private int[] arr;
        private string[] grams1;
        private Random random = new Random();
        private int sum;

        public void TextGen(int num)
        {
            using (StreamWriter sw = new StreamWriter("Text2.txt"))
            {
                for (int k = 0; k < num; ++k)
                {
                    int r = random.Next(0, sum);
                    int tempSum = 0;
                    for (int i = 0; i < 100; ++i)
                    {
                        tempSum += arr[i];
                        if (tempSum >= r)
                        {
                            sw.Write(grams1[i]);
                            sw.Write(" ");
                            break;
                        }
                    }
                }
            }
        }

        public Text2(string fileName)
        {
            sum = 0;
            arr = new int[100];
            grams1 = new string[100];
            using (StreamReader sr = new StreamReader(fileName))
            {
                int i = 0;
                while (i != 100)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(new Char[] { ' ' });
                    grams1[i] = temp[0];
                    arr[i] = Int32.Parse(temp[1]);
                    sum += arr[i];
                    i++;
                }
            }
        }

    }
    public class Text3
    {
        private int[] arr;
        private string[] grams2;
        private Random random = new Random();
        private int sum;

        public void TextGen(int num)
        {
            using (StreamWriter sw = new StreamWriter("Text3.txt"))
            {
                for (int k = 0; k < num; ++k)
                {
                    int r = random.Next(0, sum);
                    int tempSum = 0;
                    for (int i = 0; i < 100; ++i)
                    {
                        tempSum += arr[i];
                        if (tempSum >= r)
                        {
                            sw.Write(grams2[i]);
                            sw.Write(" ");
                            break;
                        }
                    }
                }
            }
        }

        public Text3(string fileName)
        {
            sum = 0;
            arr = new int[100];
            grams2 = new string[100];
            using (StreamReader sr = new StreamReader(fileName))
            {
                int i = 0;
                while (i != 100)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(new Char[] { '\t' });
                    grams2[i] = temp[0];
                    arr[i] = Int32.Parse(temp[2]);
                    sum += arr[i];
                    i++;
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Text1 text1 = new Text1("bigramm.txt");
            text1.TextGen(1000);

            Text2 text2 = new Text2("grams1.txt");
            text2.TextGen(1000);

            Text3 text3 = new Text3("grams2.txt");
            text3.TextGen(1000);
        }
    }
}

