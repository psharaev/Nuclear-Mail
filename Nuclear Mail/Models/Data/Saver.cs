using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nuclear_Mail.Models.Data
{
    public static class Saver
    {
        private static BinaryFormatter formatter = new BinaryFormatter();
        public static void SavePath<T>(in T t, in string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, t);
            }
        }

        public static void LoadPath<T>(out T t, in string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                t = (T)formatter.Deserialize(fs);
            }
        }

        public static void RemovePath(in string path) => File.Delete(path);
    }
}
