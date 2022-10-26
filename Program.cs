using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static string folderPath = $@"C:\Users\{Environment.UserName}\Desktop\TestFolder";
        static FileInfo[] fileList;
        static DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
        static void Main(string[] args)
        {

            fileList = dirInfo.GetFiles($@"c*", SearchOption.AllDirectories);
        }
        
    }
}
