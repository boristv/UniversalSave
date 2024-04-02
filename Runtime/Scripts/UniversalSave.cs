using UnityEngine;

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

            var storage = settings.GetDataStorage();
            var formatter = settings.GetFormatter();

            storage.Save(key, data, formatter);
        }
        
        public static void Save(string key, int data, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.GetDataStorage();
            var formatter = settings.GetFormatter();

            storage.Save(key, data, formatter);
        }

        public static T Load<T>(string key, T defaultValue = default, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.GetDataStorage();
            var formatter = settings.GetFormatter();

            if (storage.TryLoad(key, out T data, formatter))
            {
                return data;
            }

            return defaultValue;
        }

        public static bool TryLoad<T>(string key, out T data, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.GetDataStorage();
            var formatter = settings.GetFormatter();

            return storage.TryLoad(key, out data, formatter);
        }

        public static void SaveImage(string key, Texture2D texture, UniversalSaveSettings settings = null)
        {
            if (texture == null) return;

            settings ??= DefaultSettings;

            var byteArray = texture.EncodeToPNG();

            var storage = settings.GetDataStorage();

            storage.Save(key, byteArray);
        }

        public static bool TryLoadImage(string key, out Texture2D texture, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.GetDataStorage();

            if (storage.TryLoad(key, out byte[] bytes))
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

            var storage = settings.GetDataStorage();
            return storage.HasKey(key);
        }

        public static void Clear(string key, UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.GetDataStorage();
            storage.Clear(key);
        }

        public static void ClearAll(UniversalSaveSettings settings = null)
        {
            settings ??= DefaultSettings;

            var storage = settings.GetDataStorage();
            storage.ClearAll();
        }
    }
}