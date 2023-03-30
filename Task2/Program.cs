using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\mrvov\Desktop\folder";
        long size = GetSize(path);
        string[] folders = Directory.GetDirectories(path);
        string[] files = Directory.GetFiles(path);
        Console.WriteLine("Количество папок: {0}", folders.Length);
        Console.WriteLine("Количество файлов: {0}", files.Length);
        Console.WriteLine($"Размер в байтах, который занимает папка = {size} байтов");
    }

    static long GetSize(string path)
    {
        long size = 0;

        if (Directory.Exists(path))
        {
            foreach (string file in Directory.GetFiles(path))
            {
                FileInfo fileinfo = new FileInfo(file);
                size += fileinfo.Length;
            }

            foreach (string folder in Directory.GetDirectories(path))
            {
                DirectoryInfo dir = new DirectoryInfo(folder);
                size += GetSize(folder);
            }

        }
        else
        {
            Console.WriteLine("Ошибка, проверьте путь до папки!");
        }

        return size;
    }
}