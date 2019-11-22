using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CandyCalculator.Utils
{
    public static class FileOperations
    {
        public static void Serialize(object toSerialize, string fileName)
        {
            var formatter = new BinaryFormatter();

            var fileInfo = new FileInfo(fileName);
            Directory.CreateDirectory(fileInfo.DirectoryName);

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fs, toSerialize);
            }
        }

        public static T Deserialize<T>(string fileName) where T: class
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            var formatter = new BinaryFormatter();

            using (var fs = File.OpenRead(fileName))
            {
                return formatter.Deserialize(fs) as T;
            }
        }
    }
}
