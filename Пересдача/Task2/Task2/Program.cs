using System;
using System.IO;

namespace Task2 { 
    class Program
    {
        static void Main(string[] args)
        {
            double A = 0;
            double B = 1;
            int N = 5;
            //SplitText("D:\\0.txt", N, "D:\\1.txt", "D:\\2.txt");
            CreateTable(A, B, N, "D:\\2.txt");
        }

        public static void TextToFile(string text, string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(text);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static void CreateTable(double A, double B, int N, string file)
        {
            string fmt = "000.##";
            string text1 = "x              sin(x)            cos(x)            exp(x)\r\n";
            double step = (B - A) / N;
            for (double i = A; i <= B; i += step)
            {
                if (i == A)
                {
                    text1 += i.ToString(fmt) + "                 " + Math.Round(Math.Sin(i), 6)
                        + "                 " + Math.Round(Math.Cos(i), 6) + "                 " + Math.Round(Math.Exp(i), 6) + "\r\n";
                }
                else if(i == B)
                {
                    
                        text1 += i.ToString(fmt) + "          " + Math.Round(Math.Sin(i), 6)
                            + "          " + Math.Round(Math.Cos(i), 6) + "          " + Math.Round(Math.Exp(i), 6) + "\r\n";
                    
                }else
                {
                    text1 += Math.Round(i, 6) + "          " + Math.Round(Math.Sin(i), 6)
                        + "          " + Math.Round(Math.Cos(i), 6) + "          " + Math.Round(Math.Exp(i), 6) + "\r\n";
                }
            }
            TextToFile(text1, file);
        }
    }
}