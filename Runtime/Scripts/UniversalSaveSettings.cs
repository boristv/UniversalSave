using UnityEngine;

namespace SG.Global.SaveSystem
{
    public class UniversalSaveSettings
    {
        private SerializationFormatterType _formatterType;
        private DataStorageType _storageType;
        
        private bool _useSingleStorage = false;
        public string SingleStorageName = "saved_game_data";

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

        public bool UseSingleStorage
        {
            get => _useSingleStorage;
            set
            {
                _useSingleStorage = value;
                if (_useSingleStorage) UpdateStorage();
            }
        }

        public DataStorageType StorageType
        {
            get => _storageType;
            set
            {
                _storageType = value;
                UpdateStorage();
            }
        }

        private void UpdateStorage()
        {
            Storage = GetDataStorage(this);
        }
        
        private void UpdateFormatter()
        {
            Formatter = GetFormatter(this);
        }
        
        private ISerializationFormatter GetFormatter(UniversalSaveSettings settings)
        {
            ISerializationFormatter formatter;
            switch (settings.FormatterType)
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

        private IDataStorage GetDataStorage(UniversalSaveSettings settings)
        {
            IDataStorage storage;
            switch (settings.StorageType)
            {
                default:
                case DataStorageType.PlayerPrefs:
                    storage = new PlayerPrefsDataStorage();
                    break;
                case DataStorageType.File:
                    storage = new FileDataStorage();
                    break;
            }

            if (settings.UseSingleStorage)
            {
                storage = new SingleMediatorDataStorage(storage, settings.Formatter, settings.SingleStorageName);
            }

            return storage;
        }
    }
}
