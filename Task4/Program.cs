using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

            //using (StreamReader reader = new StreamReader(File.Open(filePath, FileMode.Open)))
            //{

            //    while (!reader.EndOfStream)
            //    {
            //        string name = reader.ReadLine();
            //        string group = reader.ReadLine();
            //        //double dbl = reader.ReadDouble();
            //        //DateTime dob = DateTime.FromOADate(dbl);
            //        Student student = new Student { Name = name, Group = group };
            //    }

            //}
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                students = (Student[])formatter.Deserialize(fs);
            }

            foreach (Student student in students)
            {
                Console.WriteLine(student.Name);
            }

        }
    }
    
}
