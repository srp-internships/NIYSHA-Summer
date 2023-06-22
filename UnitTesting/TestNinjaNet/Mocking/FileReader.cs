using System;
namespace TestNinjaNet.Mocking
{

    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);

        }
    }
}

