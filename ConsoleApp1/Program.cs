using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2;

namespace Task3
{
    public class Program: Task2.Program
    {
        public static long dirFirstSize = 0;
        public static long dirLastSize = 0;
        static void Main(string[] args)
        {
            //проверка существования(папка всё того же первого задания)
            if (Directory.Exists(folderPath))
            {
                testDir = new DirectoryInfo(folderPath);
                GetDirectorySize(testDir);
            }
            else
                Console.WriteLine("Нельзя получить доступ к папке или она не существует.");
            Console.WriteLine("Исходный размер папки: " + (FolderTotSize) + " байт.");
            // размер до удаления
            dirFirstSize = FolderTotSize;
            // прогуливаемся и удаляем файлы в каталоге и подкаталогах
            WalkDirectoryTree(testDir);
            FolderTotSize = 0;
            GetDirectorySize(testDir);
            // размер после удаления
            dirLastSize = FolderTotSize;
            Console.WriteLine($"Освобождено: {dirFirstSize - dirLastSize} байт.");
            Console.WriteLine($"Текущий размер папки: {dirLastSize} байт.");
            // вывод ошибок
            Console.WriteLine("Программа завершила работу со следующими ошибками:");
            if (log.Count == 0)
                Console.WriteLine("Ошибки отсутствуют...");
            foreach (string s in log)
            {
                Console.WriteLine(s);
            }
            // Keep the console window open in debug mode.
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
