using System.IO;
using UnityEngine;

namespace SG.Global.SaveSystem
{
    public class PlayerPrefsDataStorage : IDataStorage
    {
        public void Save<T>(string key, T data, ISerializationFormatter formatter)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                formatter.Serialize(data, memoryStream);
                var stringData = System.Convert.ToBase64String(memoryStream.ToArray());
                PlayerPrefs.SetString(key, stringData);
            }
        }
        
        public void Save(string key, byte[] bytes)
        {
            var stringData = System.Convert.ToBase64String(bytes);
            PlayerPrefs.SetString(key, stringData);
        }

        public bool TryLoad<T>(string key, out T data, ISerializationFormatter formatter)
        {
            if (PlayerPrefs.HasKey(key))
            {
                var stringData = PlayerPrefs.GetString(key);
                using (MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(stringData)))
                {
                    data = formatter.Deserialize<T>(memoryStream);
                    return true;
                }
            }

            data = default;
            return false;
        }
        
        public bool TryLoad(string key, out byte[] bytes)
        {
            if (PlayerPrefs.HasKey(key))
            {
                var stringData = PlayerPrefs.GetString(key);
                bytes = System.Convert.FromBase64String(stringData);
                return true;
            }

            bytes = default;
            return false;
        }

        public bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public void Clear(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public void ClearAll()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
