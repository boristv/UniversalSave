namespace SG.Global.SaveSystem
{
    public static partial class UniversalSave
    {
        #region bool

        public static void Save(string key, bool value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            storage.Save(key, value, formatter);
        }
        
        public static bool Load(string key, bool defaultValue = default, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryLoad(key, out bool value, formatter) ? value : defaultValue;
        }

        public static bool TryLoad(string key, out bool value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryLoad(key, out value, formatter);
        }

        #endregion
        
        #region int

        public static void Save(string key, int value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            storage.Save(key, value, formatter);
        }
        
        public static int Load(string key, int defaultValue = default, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryLoad(key, out int value, formatter) ? value : defaultValue;
        }

        public static bool TryLoad(string key, out int value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryLoad(key, out value, formatter);
        }

        #endregion
        
        #region float

        public static void Save(string key, float value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            storage.Save(key, value, formatter);
        }
        
        public static float Load(string key, float defaultValue = default, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryLoad(key, out float value, formatter) ? value : defaultValue;
        }

        public static bool TryLoad(string key, out float value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryLoad(key, out value, formatter);
        }

        #endregion
        
        #region string

        public static void Save(string key, string value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            storage.Save(key, value, formatter);
        }
        
        public static string Load(string key, string defaultValue = default, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryLoad(key, out string value, formatter) ? value : defaultValue;
        }

        public static bool TryLoad(string key, out string value, UniversalSaveSettings settings = null)
        {
            var (storage, formatter) = GetStorageAndFormatter(settings);
            return storage.TryLoad(key, out value, formatter);
        }

        #endregion
    }
}