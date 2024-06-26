using System.IO;
using Newtonsoft.Json;

namespace SG.Global.SaveSystem
{
    public class JsonSerializationFormatter : ISerializationFormatter
    {
        public void Serialize<T>(T data, Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                var jsonData = JsonConvert.SerializeObject(data);
                
                writer.Write(jsonData);
            }
        }

        public T Deserialize<T>(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var jsonData = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(jsonData);
                return data;
            }
        }

        public void Serialize<T>(T data, out string value)
        {
            value = JsonConvert.SerializeObject(data);
        }

        public T Deserialize<T>(string value)
        {
            var data = JsonConvert.DeserializeObject<T>(value);
            return data;
        }
    }
}
