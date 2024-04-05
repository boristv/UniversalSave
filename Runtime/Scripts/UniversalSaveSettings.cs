using UnityEngine;

namespace SG.Global.SaveSystem
{
    public class UniversalSaveSettings
    {
        private SerializationFormatterType _formatterType;
        private DataStorageType _storageType;

        private bool _useSingleStorage;
        private string _singleStorageName;
        private IDataStorage _customDataStorage;
        
        public IDataStorage Storage { get; private set; }
        public ISerializationFormatter Formatter { get; private set; }

        public UniversalSaveSettings()
        {
            FormatterType = SerializationFormatterType.JsonUtility;
            StorageType = DataStorageType.PlayerPrefs;
        }

        public SerializationFormatterType FormatterType
        {
            get => _formatterType;
            set
            {
                _formatterType = value;
                UpdateFormatter();
                if (_useSingleStorage) UpdateStorage();
            }
        }

        public DataStorageType StorageType
        {
            get => _storageType;
            set
            {
                if (_storageType == DataStorageType.Custom)
                {
                    Debug.LogWarning("Cannot directly change storage type to custom \n Use SetCustomStorage");
                    return;
                }
                _storageType = value;
                UpdateStorage();
            }
        }

        public void SetCustomStorage(IDataStorage dataStorage)
        {
            _storageType = DataStorageType.Custom;
            _customDataStorage = dataStorage;
            UpdateStorage();
        }

        public void SetSingleStorage(bool isSingle, string singleStorageName = "saved_game_data")
        {
            _singleStorageName = singleStorageName;
            _useSingleStorage = isSingle;
            UpdateStorage();
        }

        private void UpdateStorage()
        {
            Storage = GetDataStorage();
        }
        
        private void UpdateFormatter()
        {
            Formatter = GetFormatter();
        }
        
        private ISerializationFormatter GetFormatter()
        {
            ISerializationFormatter formatter;
            switch (_formatterType)
            {
                default:
                case SerializationFormatterType.JsonUtility:
                    formatter = new JsonUtilitySerializationFormatter();
                    break;
                case SerializationFormatterType.JsonConvert:
                    formatter = new JsonSerializationFormatter();
                    break;
                case SerializationFormatterType.Binary:
                    formatter = new BinarySerializationFormatter();
                    break;
            }

            return formatter;
        }

        private IDataStorage GetDataStorage()
        {
            IDataStorage storage;
            switch (_storageType)
            {
                default:
                case DataStorageType.PlayerPrefs:
                    storage = new PlayerPrefsDataStorage();
                    break;
                case DataStorageType.File:
                    storage = new FileDataStorage();
                    break;
                case DataStorageType.Custom:
                    storage = _customDataStorage;
                    break;
            }

            if (_useSingleStorage)
            {
                storage = new SingleMediatorDataStorage(storage, Formatter, _singleStorageName);
            }

            return storage;
        }
    }
}
