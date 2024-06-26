using System.IO;

namespace SG.Global.SaveSystem
{
    public interface ISerializationFormatter
    {
        void Serialize<T>(T data, Stream stream);
        T Deserialize<T>(Stream stream);
        
        void Serialize<T>(T data, out string value);
        T Deserialize<T>(string value);
    }
}
