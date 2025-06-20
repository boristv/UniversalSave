namespace SG.Global.SaveSystem
{
    public interface IDataStorage
    {
        public void Set<T>(string key, T data, ISerializationFormatter formatter);
        public void Set(string key, byte[] bytes);
        public bool TryGet<T>(string key, out T data, ISerializationFormatter formatter);
        public bool TryGet(string key, out byte[] bytes);
        public bool HasKey(string key);
        public void DeleteKey(string key);
        public void DeleteAll();
        
        public void Save() {}

        public void Set(string key, bool value, ISerializationFormatter formatter) 
            => Set<bool>(key, value, formatter);
        public bool TryGet(string key, out bool value, ISerializationFormatter formatter) 
            => TryGet<bool>(key, out value, formatter);
        
        public void Set(string key, int value, ISerializationFormatter formatter) 
            => Set<int>(key, value, formatter);
        public bool TryGet(string key, out int value, ISerializationFormatter formatter) 
            => TryGet<int>(key, out value, formatter);
        
        public void Set(string key, float value, ISerializationFormatter formatter) 
            => Set<float>(key, value, formatter);
        public bool TryGet(string key, out float value, ISerializationFormatter formatter) 
            => TryGet<float>(key, out value, formatter);
        
        public void Set(string key, string value, ISerializationFormatter formatter) 
            => Set<string>(key, value, formatter);
        public bool TryGet(string key, out string value, ISerializationFormatter formatter) 
            => TryGet<string>(key, out value, formatter);
    }
}
