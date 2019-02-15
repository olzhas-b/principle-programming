using System;

public class Program
{

    public static void Main(string[] args)
    {
        int c = 0;
        int k;
        k = int.Parse(Console.ReadLine());
        // in the first step we read data like string
        string []a = Console.ReadLine().Split();
        for(int i = 0; i < k; i++)
        {
            //to convert string to int 
            int t = int.Parse(string.Format("{0}", a[i]));
            // my algorithm to find prime ( if we have exactly 2 number divider than this is prime)
            for (int j = 1; j <= t; j++)
            {
                // add 1 if mode equal 0
                if(t % j == 0)
                    c +=1;
            }
            if (c == 2)
                Console.Write(t + " " );
         
            c = 0;

         }
        // it will wait untill press first keyboard
        Console.ReadKey();
    }
}