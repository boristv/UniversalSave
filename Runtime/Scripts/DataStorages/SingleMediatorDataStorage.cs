using System;
using System.Collections.Generic;
using System.IO;

namespace SG.Global.SaveSystem
{
    public class SingleMediatorDataStorage : IDataStorage
    {
        [Serializable]
        public struct SavedGameData
        {
            public List<string> Keys;
            public List<string> Values;
        }

        private class SavedGameDataMediator
        {
            public SavedGameData Data = new SavedGameData()
            {
                Keys = new List<string>(),
                Values = new List<string>()
            };

            public bool HasKey(string key)
            {
                return Data.Keys.Contains(key);
            }
            
            public bool TryGet(string key, out string value)
            {
                if (Data.Keys.Contains(key))
                {
                    var index = Data.Keys.IndexOf(key);
                    value = Data.Values[index];
                    return true;
                }
                value = string.Empty;
                return false;
            }

            public void Add(string key, string value)
            {
                if (Data.Keys.Contains(key))
                {
                    var index = Data.Keys.IndexOf(key);
                    Data.Values[index] = value;
                }
                else
                {
                    Data.Keys.Add(key);
                    Data.Values.Add(value);
                }
            }
            
            public void Remove(string key)
            {
                if (Data.Keys.Contains(key))
                {
                    var index = Data.Keys.IndexOf(key);
                    Data.Keys.Remove(key);
                    Data.Values.RemoveAt(index);
                }
            }
            
            public void Clear()
            {
                Data.Keys.Clear();
                Data.Values.Clear();
            }
        }

        private readonly IDataStorage _dataStorage;
        private readonly ISerializationFormatter _formatter;
        private readonly string _saveKey;
        private readonly bool _autoSave;

        private readonly SavedGameDataMediator _savedGameDataMediator;

        public SingleMediatorDataStorage(IDataStorage dataStorage, ISerializationFormatter formatter, bool autoSave,
            string saveKey)
        {
            _dataStorage = dataStorage;
            _formatter = formatter;
            _autoSave = autoSave;
            _saveKey = saveKey;
            _savedGameDataMediator = new SavedGameDataMediator();
            var loaded = _dataStorage.TryLoad(_saveKey, out _savedGameDataMediator.Data, _formatter);
            if (!loaded)
            {
                _savedGameDataMediator = new SavedGameDataMediator();
            }
        }

        private void SaveSingleData()
        {
            _dataStorage.Save(_saveKey, _savedGameDataMediator.Data, _formatter);
        }
        
        public void Save<T>(string key, T data, ISerializationFormatter formatter)
        {
            formatter.Serialize(data, out var stringData);
            _savedGameDataMediator.Add(key, stringData);
            if (_autoSave)
            {
                SaveSingleData();
            }
        }
        
        public void Save(string key, byte[] bytes)
        {
            var stringData = Convert.ToBase64String(bytes);
            _savedGameDataMediator.Add(key, stringData);
            if (_autoSave)
            {
                SaveSingleData();
            }
        }

        public bool TryLoad<T>(string key, out T data, ISerializationFormatter formatter)
        {
            if (_savedGameDataMediator.TryGet(key, out var stringData))
            {
                data = formatter.Deserialize<T>(stringData);
                return true;
            }

            data = default;
            return false;
        }
        
        public bool TryLoad(string key, out byte[] bytes)
        {
            if (_savedGameDataMediator.TryGet(key, out var stringData))
            {
                bytes = Convert.FromBase64String(stringData);
                return true;
            }

            bytes = default;
            return false;
        }

        public bool HasKey(string key)
        {
            return _savedGameDataMediator.HasKey(key);
        }

        public void Clear(string key)
        {
            _savedGameDataMediator.Remove(key);
            if (_autoSave)
            {
                SaveSingleData();
            }
        }

        public void ClearAll()
        {
            _savedGameDataMediator.Clear();
            _dataStorage.Clear(_saveKey);
        }
        
        public void SaveAll()
        {
            SaveSingleData();
        }
    }
}