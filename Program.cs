using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Task1
{
    public class Program
    {
        public static string folderPath = $@"C:\Users\{Environment.UserName}\Desktop\TestFolder";
        public static FileInfo[] fileList;
        public static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        public static List<string> deleted = new List<string>();
        public static DirectoryInfo[] subDirs;
        public static DirectoryInfo testDir;
        private protected static void Main(string[] args)
        {
            Console.WriteLine("Программа удалит файлы, которые не использовались более 30 минут, из папки TestFolder на рабочем столе. Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
            //если указанная папка существует, прогуляемся
            if (Directory.Exists(folderPath))
            {
                testDir = new DirectoryInfo(folderPath);
                Console.WriteLine("Сейчас программа удалит файлы в указанной папке...");
                WalkDirectoryTree(testDir);
            }
            else
            {
                Console.WriteLine("Нет доступа к указанной папке или она не сущетсвует.");
            }
            Console.WriteLine("Программа завершила работу со следующими ошибками:");
            if (log.Count==0)
                Console.WriteLine("Ошибки отсутствуют...");
            foreach (string s in log)
            {
                Console.WriteLine(s);
            }
            // Keep the console window open in debug mode.
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
        // прогулка по дереву
        public static void WalkDirectoryTree(DirectoryInfo root)
        {
            fileList = null;
            subDirs = null;
            try
            {
                fileList = root.GetFiles("*.*");
            }
            catch (Exception ex)
            {
                log.Add(ex.Message);
            }
            foreach (var fi in fileList)
            {
                try
                {
                    DeleteFiles(fi);
                }
                catch (Exception ex)
                {
                    log.Add(ex.Message);
                }
            }
            // Now find all the subdirectories under this directory.
            subDirs = root.GetDirectories();
            // рекурсия, вызываем этот же метод для каждой субдиректории
            foreach (var subdir in subDirs)
            {
                WalkDirectoryTree(subdir);
                if((subdir.GetFiles("*.*").Count()==0))
                    subdir.Delete();
            }
        }
        // удаление файлов, которые не использовались более 30 мин
        public static void DeleteFiles(FileInfo file)
        {
            if (((DateTime.Now - file.LastAccessTime) > TimeSpan.FromMinutes(1)))
            {
                file.Delete();
            }

        }
    }
}
