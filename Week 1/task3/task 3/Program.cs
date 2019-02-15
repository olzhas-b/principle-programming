using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {   
            // n is number of elements in massive 
            int n = int.Parse(Console.ReadLine());
            // i solved with help string 
            // input string(i used string like massive and read it with split)
            string[] a = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                // just output 2 times 
                Console.Write(a[i] + " ");
                Console.Write(a[i] + " ");
            }
            
            Console.ReadKey();


        }
    }
}
