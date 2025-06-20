using System.IO;
using UnityEngine;

namespace SG.Global.SaveSystem
{
    public class FileDataStorage : IDataStorage
    {
        private readonly string _saveDirectory = Path.Combine(Application.persistentDataPath, "Saves");
        
        public void Set<T>(string key, T data, ISerializationFormatter formatter)
        {
            var path = BuildPath(key);
            
            using (FileStream fileStream = File.Create(path))
            {
                formatter.Serialize(data, fileStream);
            }
        }
        
        public void Set(string key, byte[] bytes)
        {
            var path = BuildPath(key);
            
            File.WriteAllBytes(path, bytes);
        }

        public bool TryGet<T>(string key, out T data, ISerializationFormatter formatter)
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
        
        public bool TryGet(string key, out byte[] bytes)
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

        public void DeleteKey(string key)
        {
            var path = BuildPath(key);
            
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void DeleteAll()
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
        
        #region direct_saving
        
        public void Set(string key, string value, ISerializationFormatter formatter)
        {
            var path = BuildPath(key);
            File.Create(path);
            File.WriteAllText(path, value);
        }

        public bool TryGet(string key, out string value, ISerializationFormatter formatter)
        {
            var path = BuildPath(key);
            
            if (File.Exists(path))
            {
                value = File.ReadAllText(path);
                return true;
            }

            value = default;
            return false;
        }
        
        #endregion
    }
}
