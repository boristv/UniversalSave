using System.IO;
using UnityEngine;

namespace SG.Global.SaveSystem
{
    public class JsonUtilitySerializationFormatter : ISerializationFormatter
    {
        public void Serialize<T>(T data, Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                var jsonData = JsonUtility.ToJson(data);
                
                writer.Write(jsonData);
            }
        }

        public T Deserialize<T>(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var jsonData = reader.ReadToEnd();
                var data = JsonUtility.FromJson<T>(jsonData);
                return data;
            }
        }
    }
}