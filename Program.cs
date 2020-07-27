using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glava7_urok2
{
    class Program
    {
        public static void DumpBuffer(byte[] buffer, int numbytes) 
        {
            for (int i = 0; i < numbytes; i++)
            {
                byte b = buffer[i];
                Console.Write($"{b} ");

            }
            Console.WriteLine();
        }
        public static FileInfo[] GetFileList(string directoryName) 
        {
            FileInfo[] files = new FileInfo[0];
            try
            {
                DirectoryInfo di = new DirectoryInfo(directoryName);
                files = di.GetFiles();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Каталог неверен: {directoryName}");
                Console.WriteLine(e.Message);
            }
            return files;
        }
        public static void DumpHex(FileInfo fileInfo) 
        {
            FileStream fs;
            BinaryReader reader = null;
            try
            {
                fs = File.OpenRead(fileInfo.FullName);
                reader = new BinaryReader(fs);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удаётся прочитать файл: {fileInfo.FullName}");
                Console.WriteLine(e.Message);
                
            }
            for (int line = 1; true; line++)
            {
                byte[] buffer = new byte[10];
                int numbytes = reader.Read(buffer,0,buffer.Length);
                if (numbytes == 0) return;
                Console.Write($"{line:D3} = ");
                DumpBuffer(buffer,numbytes);
                
                
            }
        }
        static void Main(string[] args)
        {

            FileInfo[] files = GetFileList(Directory.GetCurrentDirectory());
            foreach (FileInfo file in files) 
            {
                DumpHex(file);
            }
        }
    }
}
