using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // the name of the file, that i will create
            string file = "123.txt";

            // the path of created file
            string path1 = @"C:\x";

            // the path of created and copied file
            string path2 = @"C:\x\labb";

            // with path.combine a file to the path1, it is like to the file give a place in pc
            string file1 = Path.Combine(path1, file);

            // file to the path2
            string file2 = Path.Combine(path2, file);

            // create a sourcefile that file in path1
            FileStream fs = File.Create(file1);

            // close the filestream, because of that the program doesn't work
            fs.Close();

            // then with class File use copy file, file1 copy to file2, then true is mean that confirm the operation
            File.Copy(file1, file2, true);

            // then delete the file1, file1 with operation delete
            File.Delete(file1); 
        }
    }
}