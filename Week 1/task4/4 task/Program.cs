using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_task
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            int n = int.Parse(Console.ReadLine());
            int [,]a = new int[n,n];
            // create massive
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // k is equal 0 and evey time +2 is that mean algorithm to paint picture low than diagonal
                    if (i + j > k)
                        continue;
                    else
                        Console.Write("[*]");
                }
                k += 2;
                Console.WriteLine(" ");
            }
            Console.ReadKey();
        }
    }
}
