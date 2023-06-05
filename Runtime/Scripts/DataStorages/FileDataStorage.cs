using System.IO;
using UnityEngine;

namespace SG.Global.SaveSystem
{
    public class FileDataStorage : IDataStorage
    {
        private readonly string _saveDirectory = Path.Combine(Application.persistentDataPath, "Saves");
        
        public void Save<T>(string key, T data, ISerializationFormatter formatter)
        {
            var path = BuildPath(key);
            
            using (FileStream fileStream = File.Create(path))
            {
                formatter.Serialize(data, fileStream);
            }
        }
        
        public void Save(string key, byte[] bytes)
        {
            var path = BuildPath(key);
            
            File.WriteAllBytes(path, bytes);
        }

        public bool TryLoad<T>(string key, out T data, ISerializationFormatter formatter)
        {
            var path = BuildPath(key);
            
            if (File.Exists(path))
            {
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    data = formatter.Deserialize<T>(fileStream);
                    return true;
                }
            }

            data = default;
            return false;
        }
        
        public bool TryLoad(string key, out byte[] bytes)
        {
            var path = BuildPath(key);
            
            if (File.Exists(path))
            {
                bytes = File.ReadAllBytes(path);
                return true;
            }

            bytes = default;
            return false;
        }

        public bool HasKey(string key)
        {
            var path = BuildPath(key);

            return File.Exists(path);
        }

        public void Clear(string key)
        {
            var path = BuildPath(key);
            
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void ClearAll()
        {
            if (Directory.Exists(_saveDirectory))
            {
                Directory.Delete(_saveDirectory, true);
            }
        }

        private string BuildPath(string key)
        {
            if (Directory.Exists(_saveDirectory) == false)
            {
                Directory.CreateDirectory(_saveDirectory);
            }
            return Path.Combine(_saveDirectory, key);
        }
    }
}
