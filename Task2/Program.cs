using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task2
{
    public class Program: Task1.Program
    {
        
        public static long FolderTotSize =0;
        //взял папку из предыдущего задания
        private protected static void Main(string[] args)
        {
            Console.WriteLine("Программа определит размер папки TestFolder на рабочем столе. Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
            if (Directory.Exists(folderPath))
            {
                testDir = new DirectoryInfo(folderPath);
                GetDirectorySize(testDir);

            }
            else
                Console.WriteLine("Нельзя получить доступ к папке или она не существует.");
            Console.WriteLine("Общий размер папки: " + (FolderTotSize) + " байт.");
            Console.WriteLine("Работа завершена со следующими ошибками: ");
            foreach (var item in log)
            {
                Console.WriteLine(item);
            }
            if(Task1.Program.log.Count == 0)
                Console.WriteLine("Ошибки отсутствуют... ");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static void GetDirectorySize(DirectoryInfo root)
        {
            fileList = null;
            subDirs = null;
            // получаем список файлов в папке
            try
            {
                fileList = root.GetFiles();
            }
            catch (Exception ex)
            {
                log.Add(ex.Message);
            }
            // суммируем размеры всех файлов в папке
            foreach (var file in fileList)
            {
                try
                {
                    FolderTotSize += file.Length;
                }
                catch (Exception ex)
                {
                    log.Add(ex.Message);
                }
            }
            // получаем список подпапок
            subDirs = root.GetDirectories();
            // Рекурсия для каждой подпапки
            foreach (var dir in subDirs)
            {
                GetDirectorySize(dir);
            }
        }
    }
}
