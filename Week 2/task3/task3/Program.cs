using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {// to shift the file in the folder
        static void space(int j) 
        {
            for (int i = 0; i < j; i++)
            {
                Console.Write("     ");
            }
        }
        // to show the all files in one folder
        static void All(DirectoryInfo dir1, int j)
        {
            // from folder to the array
            FileSystemInfo[] a = dir1.GetFileSystemInfos(); 
            for (int i = 0; i < a.Length; i++)
            {
                // if we found directory, we must check the folder, because in the folder may be have the files
                if (a[i].GetType() == typeof(DirectoryInfo)) 
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    // call the method // to the shift files in the folder
                    space(j); 
                    Console.WriteLine(a[i]); // show the name of the directory
                    // if in one directory have directory, so we must go to the another directory, because of that we must change the directory
                    DirectoryInfo dir2 = a[i] as DirectoryInfo;
                    //if in folder have another folder, so change the folder and shift the files
                    All(dir2, j + 1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    space(j); // to the shift files
                    Console.WriteLine(a[i]); // show the files in directory
                }
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\x"); // path to the directory
            All(directory, 0); // call the function
        }
    }
}