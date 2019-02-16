using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\x");
            PrintInfo(dir, 0);
        }

        static void PrintInfo(FileSystemInfo f, int k)
        {
            string s = new string(' ', k);
            Console.WriteLine(s + f.Name);

            if (f.GetType() == typeof(DirectoryInfo))
            {
                FileSystemInfo[] arr = ((DirectoryInfo)f).GetFileSystemInfos();
                for (int i = 0; i < arr.Length; ++i)
                {
                    PrintInfo(arr[i], k + 3);
                }
            }

        }
    }
}
