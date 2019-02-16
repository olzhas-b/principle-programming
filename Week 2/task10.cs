using System;
using System.Collections.Generic;
using System.IO; // library to work with files and directories
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task1
{
    class Program
    {

        static void Main(string[] args)
        {
            string s, s_rev;
            // s_rev is empty string
            // string s from txt file
            s = File.ReadAllText(@"C:\x\input.txt");
            s_rev = "";

            // find string length
            int len;
            // -1 because we need last char in string s
            len = s.Length - 1;

            // algorithm to find string number
            while (len >= 0)
            {
                s_rev += s[len];
                len--;
            }
            //to check that is it polindrome
            if (s == s_rev)
                Console.WriteLine("Yes");
            else
                Console.Write("No");

        }
    }
}