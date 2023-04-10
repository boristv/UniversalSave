using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SG.Global.SaveSystem
{
    public class BinarySerializationFormatter : ISerializationFormatter
    {
        private BinaryFormatter _formatter;
        private string _directory;

        public BinarySerializationFormatter()
        {
            InitBinaryFormatter();
        }
        
        private void InitBinaryFormatter()
        {
            _formatter = new BinaryFormatter();
            var selector = new SurrogateSelector();

            var qSurrogate = new QuaternionSerializationSurrogate();
            var v3Surrogate = new Vector3SerializationSurrogate();
            var v3IntSurrogate = new Vector3IntSerializationSurrogate();
            var v2Surrogate = new Vector2SerializationSurrogate();
            var v2IntSurrogate = new Vector2IntSerializationSurrogate();
            var v4Surrogate = new Vector4SerializationSurrogate();
            var colorSurrogate = new ColorSerializationSurrogate();
            
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), qSurrogate);
            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3Surrogate);
            selector.AddSurrogate(typeof(Vector3Int), new StreamingContext(StreamingContextStates.All), v3IntSurrogate);
            selector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), v2Surrogate);
            selector.AddSurrogate(typeof(Vector2Int), new StreamingContext(StreamingContextStates.All), v2IntSurrogate);
            selector.AddSurrogate(typeof(Vector4), new StreamingContext(StreamingContextStates.All), v4Surrogate);
            selector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), colorSurrogate);

            _formatter.SurrogateSelector = selector;
        }
        
        public void Serialize<T>(T data, Stream stream)
        {
            _formatter.Serialize(stream, data);
        }

        public T Deserialize<T>(Stream stream)
        {
            var data = (T) _formatter.Deserialize(stream);
            return data;
        }
    }
}
