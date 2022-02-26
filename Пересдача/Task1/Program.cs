using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Matrix size (int N):");
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[n][];
            Console.WriteLine("Randomize matrix? (y/n)");
            string rand = Console.ReadLine();
            int cont = 1;
            if (rand == "y")
            {
                Random rnd = new Random();
                for (int i = 0; i < n; i++)
                {
                    array[i] = new int[n];
                    for (int j = 0; j < n; j++)
                    {
                        array[i][j] = rnd.Next(1, 10);
                        Console.Write(array[i][j] + " ");
                    }

                    Console.WriteLine();
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (array[j][0] > array[j + 1][0])
                        {
                            int[] temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    array[i] = new int[n];
                    string[] str = Console.ReadLine().Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        array[i][j] = Convert.ToInt32(str[j]);
                    }

                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (array[j][0] > array[j + 1][0])
                        {
                            int[] temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            Console.WriteLine("Answer:");
            for (int i = 0; i < n; i++)
            {
                if(cont == 2)
                { 
                    for (int j = n - 1; j > 0; j--)
                    {
                        if(array[i][j] < array[i][j-1])
                        { 
                          Console.WriteLine("Не является послед. а:");
                          cont = -1; 
                          break;
                        }
                    }
                }
                if(cont == 1)
                {
                    for (int j = 0; j < n - 1; j++)
                    {
                        if(array[i][j] > array[i][j+1])
                        { 
                          Console.WriteLine("Не является послед. а:");
                          cont = -1; 
                          break;
                        }
                    }
                }
                if(cont == 1)
                    cont = 2;
                else if(cont == 2)
                    cont = 1;
                else
                    break;
            }
            if(cont != -1)
                Console.WriteLine("Является послед. a:");

            Console.ReadKey();
        }
    }
}