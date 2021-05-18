using Saugumas_4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saugumas_4.Utilities
{
    class FileManager
    {
        private string directory;

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

        public void WriteToFile(string name, string data)
        {
            string path = directory + name;
            if (!File.Exists(path))
                throw new Exception("Toks naudotojas neegzistuoja");

            File.WriteAllText(path, data);
        }

        public void Register(User user)
        {
            CreateFile(user.GetNickname() + ".txt");
            WriteToFile(user.GetNickname() + ".txt", user.ToString());
        }
    }
}
