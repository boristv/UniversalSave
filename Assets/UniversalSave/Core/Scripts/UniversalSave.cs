namespace SG.Global.SaveSystem
{
    public static class UniversalSave
    {
        private static UniversalSaveSettings _defaultSettings;

        public static UniversalSaveSettings DefaultSettings
        {
            get => _defaultSettings ??= new UniversalSaveSettings();
            set => _defaultSettings = value;
        }
        
        public static void Save<T>(string key, T data, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = GetDataStorage(settings);
            var formatter = GetFormatter(settings);

            storage.Save(key, data, formatter);
        }

        public static T Load<T>(string key, T defaultValue = default, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;
            
            var storage = GetDataStorage(settings);
            var formatter = GetFormatter(settings);

            if (storage.TryLoad(key, out T data, formatter))
            {
                return data;
            }
            
            return defaultValue;
        }

        public static bool TryLoad<T>(string key, out T data, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;
            
            var storage = GetDataStorage(settings);
            var formatter = GetFormatter(settings);
            
            return storage.TryLoad(key, out data, formatter);
        }

        public static bool HasKey(string key, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;
            
            var storage = GetDataStorage(settings);
            return storage.HasKey(key);
        }

        public static void Clear(string key, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;
            
            var storage = GetDataStorage(settings);
            storage.Clear(key);
        }

        public static void ClearAll(UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;
            
            var storage = GetDataStorage(settings);
            storage.ClearAll();
        }
        
        private static ISerializationFormatter GetFormatter(UniversalSaveSettings settings)
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

        private static IDataStorage GetDataStorage(UniversalSaveSettings settings)
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

            return storage;
        }
    }
}
