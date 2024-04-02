using System;
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
                var stringData = Convert.ToBase64String(memoryStream.ToArray());
                PlayerPrefs.SetString(key, stringData);
            }
        }
        
        public void Save(string key, byte[] bytes)
        {
            var stringData = Convert.ToBase64String(bytes);
            PlayerPrefs.SetString(key, stringData);
        }

        public bool TryLoad<T>(string key, out T data, ISerializationFormatter formatter)
        {
            if (PlayerPrefs.HasKey(key))
            {
                var stringData = PlayerPrefs.GetString(key);
                
                using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(stringData)))
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
                bytes = Convert.FromBase64String(stringData);
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

        #region direct_saving

        public void Save(string key, bool value, ISerializationFormatter formatter)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }
        
        public bool TryLoad(string key, out bool value, ISerializationFormatter formatter)
        {
            return CommonTryLoad(key, out value, () => PlayerPrefs.GetInt(key) == 1);
        }
        
        public void Save(string key, int value, ISerializationFormatter formatter)
        {
            PlayerPrefs.SetInt(key, value);
        }
        
        public bool TryLoad(string key, out int value, ISerializationFormatter formatter)
        {
            return CommonTryLoad(key, out value, () => PlayerPrefs.GetInt(key));
        }
        
        public void Save(string key, float value, ISerializationFormatter formatter)
        {
            PlayerPrefs.SetFloat(key, value);
        }
        
        public bool TryLoad(string key, out float value, ISerializationFormatter formatter)
        {
            return CommonTryLoad(key, out value, () => PlayerPrefs.GetFloat(key));
        }
        
        public void Save(string key, string value, ISerializationFormatter formatter)
        {
            PlayerPrefs.SetString(key, value);
        }
        
        public bool TryLoad(string key, out string value, ISerializationFormatter formatter)
        {
            return CommonTryLoad(key, out value, () => PlayerPrefs.GetString(key));
        }
        
        private bool CommonTryLoad<T>(string key, out T value, Func<T> func)
        {
            if (PlayerPrefs.HasKey(key))
            {
                value = func.Invoke();
                return true;
            }

            value = default;
            return false;
        }

        #endregion
    }
}
