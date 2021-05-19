using Saugumas_4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Saugumas_4.Utilities
{
    class FileManager
    {
        static FileManager()
        {
            string path = StupidNaming.Directory;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void CreateFile(string path)
        {
            if (File.Exists(path))
                throw new Exception("Toks naudotojas jau egzistuoja");

            File.Create(path);
        }

        public void WriteAFile(string path, string data)
        {
            File.WriteAllText(path, data);
        }

        public string[] ReadFile(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Toks failas/naudotojas neegzistuoja");

            string[] lines = File.ReadAllLines(path);
            return lines;
        }
    }
}
