using System;

namespace Task4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] name = {"ЛДПР", "ЕР", "СР", "КПРФ", "Яблоко"};
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                Meeting m = new Meeting(name[r.Next(5)], 1 + r.Next(25), 25 + r.Next(100));
                Console.WriteLine(m.getInfo());
            }

            for (int i = 0; i < 5; i++)
            {
                Meeting m = new Solidary(name[r.Next(5)], 1 + r.Next(25), 25 + r.Next(100), 2 + r.Next(23));
                Console.WriteLine(m.getInfo());
            }

            Console.ReadKey();
        }
    }
}