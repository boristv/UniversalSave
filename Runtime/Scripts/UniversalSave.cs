using UnityEngine;

namespace SG.Global.SaveSystem
{
    public static partial class UniversalSave
    {
        private static UniversalSaveSettings _defaultSettings;

        public static UniversalSaveSettings DefaultSettings
        {
            get => _defaultSettings ??= new UniversalSaveSettings();
            set => _defaultSettings = value;
        }
        
        private static (IDataStorage, ISerializationFormatter) GetStorageAndFormatter(UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.Storage;
            var formatter = settings.Formatter;

            return (storage, formatter);
        }

        public static void Set<T>(string key, T data, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            storage.Set(key, data, formatter);
        }

        public static T Get<T>(string key, T defaultValue = default, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryGet(key, out T data, formatter) ? data : defaultValue;
        }

        public static bool TryGet<T>(string key, out T data, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryGet(key, out data, formatter);
        }

        public static void SetImage(string key, Texture2D texture, UniversalSaveSettings settings = null)
        {
            if (texture == null) return;

            settings ??= DefaultSettings;

            var byteArray = texture.EncodeToPNG();

            var storage = settings.Storage;

            storage.Set(key, byteArray);
        }

        public static bool TryGetImage(string key, out Texture2D texture, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.Storage;

            if (storage.TryGet(key, out byte[] bytes))
            {
                texture = new Texture2D(2, 2);
                texture.LoadImage(bytes);
                return true;
            }

            texture = null;
            return false;
        }

        public static bool HasKey(string key, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.Storage;
            return storage.HasKey(key);
        }

        public static void DeleteKey(string key, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.Storage;
            storage.DeleteKey(key);
        }

        public static void DeleteAll(UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.Storage;
            storage.DeleteAll();
        }

        public static void Save(UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.Storage;
            storage.Save();
        }
    }
}