using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    internal class Program
    {
        static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Students.dat");
        static Student[] students;
        static void Main(string[] args)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    students = (Student[])formatter.Deserialize(fs);
                }
            }
            else
            {
                Console.WriteLine("Файла нет");
            }
            CreateFiles();


        }
        static void CreateFiles()
        {
            string dirPath = $@"C:\Users\{Environment.UserName}\Desktop\Students";
            Directory.CreateDirectory(dirPath);
            //var groups = students.GroupBy(p => p.Group);
            var groups = students.GroupBy(p => p.Group);
            foreach (var group in groups)
            {
                var stdsInGroup = group.Select(g => new { Name = g.Name, DateOfBirth = g.DateOfBirth });
                string txtPath = $"{dirPath}\\Группа {group.Key}.txt";
                FileInfo fileInfo = new FileInfo(txtPath);
                using (StreamWriter sw = fileInfo.CreateText())
                {
                    foreach (var std in stdsInGroup)
                    {
                        sw.WriteLine($"{std.Name}, {std.DateOfBirth}");
                    }
                    
                }
            }
            
           
        }
    }
}
