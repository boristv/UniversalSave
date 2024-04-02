namespace SG.Global.SaveSystem
{
    public interface IDataStorage
    {
        public void Save<T>(string key, T data, ISerializationFormatter formatter);
        public void Save(string key, byte[] bytes);
        public bool TryLoad<T>(string key, out T data, ISerializationFormatter formatter);
        public bool TryLoad(string key, out byte[] bytes);
        public bool HasKey(string key);
        public void Clear(string key);
        public void ClearAll();

        public void Save(string key, bool value, ISerializationFormatter formatter) 
            => Save<bool>(key, value, formatter);
        public bool TryLoad(string key, out bool value, ISerializationFormatter formatter) 
            => TryLoad<bool>(key, out value, formatter);
        
        public void Save(string key, int value, ISerializationFormatter formatter) 
            => Save<int>(key, value, formatter);
        public bool TryLoad(string key, out int value, ISerializationFormatter formatter) 
            => TryLoad<int>(key, out value, formatter);
        
        public void Save(string key, float value, ISerializationFormatter formatter) 
            => Save<float>(key, value, formatter);
        public bool TryLoad(string key, out float value, ISerializationFormatter formatter) 
            => TryLoad<float>(key, out value, formatter);
        
        public void Save(string key, string value, ISerializationFormatter formatter) 
            => Save<string>(key, value, formatter);
        public bool TryLoad(string key, out string value, ISerializationFormatter formatter) 
            => TryLoad<string>(key, out value, formatter);
    }
}
