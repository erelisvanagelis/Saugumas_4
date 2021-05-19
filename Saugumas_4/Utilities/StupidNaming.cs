using System.IO;
using System.Reflection;

namespace Saugumas_4.Utilities
{
    class StupidNaming
    {
        private static string directory;

        public static string Directory { get => directory; set => directory = value; }

        static StupidNaming()
        {
            Directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\data\\";
        }

        public static string GetPathTxt(string name)
        {
            return Directory + name + ".txt";
        }

        public static string GetPathAes(string name)
        {
            return Directory + name + ".txt.aes";
        }
    }
}
