using System;
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
                var jsonData = JsonUtility.ToJson(new DataWrapper<T>(data));
                
                writer.Write(jsonData);
            }
        }

        public T Deserialize<T>(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var jsonData = reader.ReadToEnd();
                //TODO: fix can not read jsonData
                var data = JsonUtility.FromJson<DataWrapper<T>>(jsonData).Data;
                return data;
            }
        }

        public void Serialize<T>(T data, out string value)
        {
            value = JsonUtility.ToJson(new DataWrapper<T>(data));
        }

        public T Deserialize<T>(string value)
        {
            //TODO: fix can not read jsonData
            var data = JsonUtility.FromJson<DataWrapper<T>>(value).Data;
            return data;
        }

        [Serializable]
        private struct DataWrapper<T>
        {
            public T Data;

            public DataWrapper(T data)
            {
                Data = data;
            }
        }
    }
}