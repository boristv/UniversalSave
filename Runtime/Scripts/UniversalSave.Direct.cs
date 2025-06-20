namespace SG.Global.SaveSystem
{
    public static partial class UniversalSave
    {
        #region bool

        public static void Set(string key, bool value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            storage.Set(key, value, formatter);
        }
        
        public static bool Get(string key, bool defaultValue = default, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryGet(key, out bool value, formatter) ? value : defaultValue;
        }

        public static bool TryGet(string key, out bool value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryGet(key, out value, formatter);
        }

        #endregion
        
        #region int

        public static void Set(string key, int value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            storage.Set(key, value, formatter);
        }
        
        public static int Get(string key, int defaultValue = default, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryGet(key, out int value, formatter) ? value : defaultValue;
        }

        public static bool TryGet(string key, out int value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryGet(key, out value, formatter);
        }

        #endregion
        
        #region float

        public static void Set(string key, float value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            storage.Set(key, value, formatter);
        }
        
        public static float Get(string key, float defaultValue = default, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryGet(key, out float value, formatter) ? value : defaultValue;
        }

        public static bool TryGet(string key, out float value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryGet(key, out value, formatter);
        }

        #endregion
        
        #region string

        public static void Set(string key, string value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            storage.Set(key, value, formatter);
        }
        
        public static string Get(string key, string defaultValue = default, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryGet(key, out string value, formatter) ? value : defaultValue;
        }

        public static bool TryGet(string key, out string value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryGet(key, out value, formatter);
        }

        #endregion
    }
}