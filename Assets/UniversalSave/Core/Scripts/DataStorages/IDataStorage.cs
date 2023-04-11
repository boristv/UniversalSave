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
    }
}
