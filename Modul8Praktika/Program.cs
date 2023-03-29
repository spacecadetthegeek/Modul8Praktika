using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Dispose();
    }

    static void Dispose()
    {
        TimeSpan TimeSold = TimeSpan.FromMinutes(30);
        string path = (@"C:\Users\mrvov\Desktop\folder");
        if(Directory.Exists(path))
        {
            foreach(string file in Directory.GetFiles(path))
            {
                FileInfo fileinfo = new FileInfo(file);
                TimeSpan Ts = DateTime.Now - fileinfo.LastAccessTime;

                if(Ts > TimeSold)
                {
                    File.Delete(file);
                    Console.WriteLine("Был удалён файл: " + fileinfo.Name);
                }
            }

            foreach(string folder in Directory.GetDirectories(path))
            {
                DirectoryInfo dir = new DirectoryInfo(folder);
                TimeSpan Ts = DateTime.Now - dir.LastAccessTime;

                if(Ts > TimeSold)
                {
                    Directory.Delete(dir.FullName,true);
                    Console.WriteLine("Была удалена папка: " + dir.Name);
                }
            }

 
        }
        else
        {
            Console.WriteLine("Папка не найдена!");
        }

    }
}