using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";// it necessary in the end 
            // our string text like storage for number into input.txt
            string text = File.ReadAllText(@"C:\Users\user\source\repos\PP2\Week 2\task 2\task 2\input.txt");
            int c = 0;

            string[] text1 = text.Split();// creat a new massive and write string number
            int[] t = new int[text1.Length]; // create massive for storage (integer numbers)

            for (int i = 0; i < text1.Length; i++)
            { 
                //to convert string to int 
                Int32.TryParse(text1[i], out t[i]);
            }
           
            for (int i = 0; i < text1.Length; i++)//algorithm to find prime, if we have exactly 2 divider than it is prime number
            {
                for (int j = 1; j <= t[i]; j++)
                {
                    if (t[i] % j == 0)
                        ++c;

                }
                if (c == 2)
                {
                    string k = t[i].ToString();
                    s = s + k + " ";
                }
                // after each cyle c must be 0
                c = 0;
            }

            // write our result into output.txt
            File.WriteAllText(@"C:\Users\user\source\repos\PP2\Week 2\task 2\task 2\output.txt", s);
        }
    }
}