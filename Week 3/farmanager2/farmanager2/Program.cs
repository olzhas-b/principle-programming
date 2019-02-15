using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class layer
    {
        public string filecontent = "";
        private int cursor = 0;
        private List<FileSystemInfo> items;
        public List<FileSystemInfo> Items
        {
            get
            {
                //property for getting items
                return items;
            }
        }
        //constructor
        public layer(DirectoryInfo dirinfo) 
        {
            FileSystemInfo[] ItemS = dirinfo.GetFileSystemInfos();
            List<FileSystemInfo> Items = new List<FileSystemInfo>();
            // converting array into list
            Items.AddRange(ItemS);
            // getting value
            this.items = Items;
        }
        //method for deleting 
        public void delete(FileSystemInfo del)
        {
            if (del.GetType() == typeof(DirectoryInfo))
            {
                //deleting directory
                Directory.Delete(del.FullName, true);
            }
            else
            {
                //deleting file
                File.Delete(del.FullName);
            }
            //removing filesysteminfo from list at current index
            items.RemoveAt(cursor);     
        }
        //method for renaming
        public void rename(FileSystemInfo fInfo)
        {
            if (fInfo.GetType() == typeof(DirectoryInfo))
            {
                DirectoryInfo y = fInfo as DirectoryInfo;
                // creating space for writing name from console
                for (int i = 1; i <= 2; i++) 
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("  ");
                }
                //writing in console for user 
                Console.Write("Enter new name:");

                string s = Console.ReadLine(); // name that user enter
                string path = y.Parent.FullName;
                string newname = Path.Combine(path, s); // because there is no command in c# for juct renaming name od diredctory
                y.MoveTo(newname); // we will move file to the same path with new name
            }
            else
            {
                FileInfo y = fInfo as FileInfo; // sme wirth file
                for (int i = 1; i <= 2; i++) // creating space for writing name from console
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("  ");
                }
                Console.Write("Enter new name:"); //writing in console for user 

                string s = Console.ReadLine();
                string newname = Path.Combine(y.Directory.FullName, s);
                y.MoveTo(newname);
            }
        }

        public string openingFile(FileInfo f) // method for reading file
        {
            FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadToEnd(); //reading file and saving it into string
            fs.Close();
            sr.Close();
            return s; //saving it into filecontent       
        }
        //property for getting and setting the value of selected item
        public int SelectedItem
        {
            get
            {
                return cursor;
            }
            set
            {
                if (value < 0) cursor = items.Count - 1;
                else
                {
                    if (value >= items.Count) cursor = 0;
                    else cursor = value;
                }

            }
        }
        public void Draw() // method for visualization
        {
            if (filecontent.Count() != 0)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(filecontent);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == cursor)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else Console.BackgroundColor = ConsoleColor.Black;
                    if (items[i].GetType() == typeof(DirectoryInfo))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(items[i].Name);
                }
            }
        }
    }
    class Program
    {
        enum Mode //creating enum to know is it dir or file when pressing enter
        {
            DIR,
            FILE
        }
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:");
            Stack<layer> history = new Stack<layer>(); //creating stack for saving layers
            Mode Case = Mode.DIR; // initially its directory mode
            history.Push(new layer(directory));
            bool quit = false;
            while (!quit)
            {
                history.Peek().Draw();
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--; //for controlling
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedItem;
                        FileSystemInfo y = history.Peek().Items[x] as FileSystemInfo;
                        if (y.GetType() == typeof(DirectoryInfo))//if its directory then creating new layer of directory and pushing it into stack
                        {
                            DirectoryInfo d = history.Peek().Items[x] as DirectoryInfo;
                            history.Push(new layer(d));
                        }
                        else//if its file we will draw content of file
                        {
                            FileInfo f = history.Peek().Items[x] as FileInfo;
                            history.Peek().filecontent = history.Peek().openingFile(f);
                            Case = Mode.FILE;
                        }
                        break;
                    case ConsoleKey.Backspace:
                        // if its directory then we will return previous layer of stack
                        if (Case == Mode.DIR) 
                        {
                            if (history.Count() > 1)
                            {
                                history.Pop();
                            }
                        } // if its file then it will return the last alyer of stack
                        else
                        {
                            history.Peek().filecontent = "";
                            // switching directory mode 
                            Case = Mode.DIR;
                        }
                        break;
                    // command for deleting
                    case ConsoleKey.Delete: 
                        int n = history.Peek().SelectedItem;
                        FileSystemInfo fi = history.Peek().Items[n];
                        history.Peek().delete(fi);
                        break;
                    case ConsoleKey.F2: // console key for renaming
                        history.Peek().rename(history.Peek().Items[history.Peek().SelectedItem]);
                        break;
                    case ConsoleKey.Escape: // the end
                        quit = true;
                        break;
                }
            }
        }
    }
}