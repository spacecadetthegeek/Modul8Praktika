using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\mrvov\Desktop\folder";
        Dispose(path);

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



    static void Dispose(string path)
    {
        int NumberFiles = Directory.GetFiles(path).Length;
        TimeSpan TimeSold = TimeSpan.FromMinutes(30);
        if (Directory.Exists(path))
        {
            long size1 = GetSize(path);
            foreach (string file in Directory.GetFiles(path))
            {
                FileInfo fileinfo = new FileInfo(file);
                TimeSpan Ts = DateTime.Now - fileinfo.LastAccessTime;

                if (Ts > TimeSold)
                {
                    File.Delete(file);
                }
            }

            foreach (string folder in Directory.GetDirectories(path))
            {
                DirectoryInfo dir = new DirectoryInfo(folder);
                TimeSpan Ts = DateTime.Now - dir.LastAccessTime;

                if (Ts > TimeSold)
                {
                    Directory.Delete(dir.FullName, true);
                }
            }

            int RemainingFiles = Directory.GetFiles(path).Length;

            int HowManyDelete = NumberFiles - RemainingFiles;

            long size2 = GetSize(path);
            long raznica = size1 - size2;


            Console.WriteLine($"Файлов было удалено: {HowManyDelete}");
            Console.WriteLine($"Место освобождено: {raznica}");
            Console.WriteLine($"Текущий размер папки: {size2}");


        }
        else
        {
            Console.WriteLine("Папка не найдена!");
        }

    }
}