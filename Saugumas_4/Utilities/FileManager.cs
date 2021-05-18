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
        private string directory;

        public FileManager()
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) +"\\data";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            this.directory = path + "\\";
            Console.WriteLine(directory);
        }

        public FileManager(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            this.directory = directory + "\\";
        }

        public void CreateFile(string name)
        {
            string path = directory + name;
            
            if (File.Exists(path))
                throw new Exception("Toks naudotojas jau egzistuoja");

            File.Create(path);
        }

        public void WriteAFile(string name, string data)
        {
            string path = directory + name;
            File.WriteAllText(path, data);
        }

        public void Register(User user)
        {
            string path = directory + user.GetNickname() + ".txt";
            if (File.Exists(path))
                throw new Exception("Toks naudotojas jau egzistuoja");
            WriteAFile(user.GetNickname() + ".txt", user.ToString());
        }

        public string[] ReadFile(string name)
        {
            string path = directory + name;
            if (!File.Exists(path))
                throw new Exception("Toks failas/naudotojas neegzistuoja");

            string[] lines = File.ReadAllLines(path);
            return lines;
        }
    }
}
