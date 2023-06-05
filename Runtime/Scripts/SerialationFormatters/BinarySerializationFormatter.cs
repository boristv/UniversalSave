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

            AddSurrogate<Quaternion>(selector, new QuaternionSerializationSurrogate());
            AddSurrogate<Vector3>(selector, new Vector3SerializationSurrogate());
            AddSurrogate<Vector3Int>(selector, new Vector3IntSerializationSurrogate());
            AddSurrogate<Vector2>(selector, new Vector2SerializationSurrogate());
            AddSurrogate<Vector2Int>(selector, new Vector2IntSerializationSurrogate());
            AddSurrogate<Vector4>(selector, new Vector4SerializationSurrogate());
            AddSurrogate<Color>(selector, new ColorSerializationSurrogate());
            AddSurrogate<Color32>(selector, new Color32SerializationSurrogate());

            _formatter.SurrogateSelector = selector;
        }

        private void AddSurrogate<T>(SurrogateSelector selector, ISerializationSurrogate surrogate)
        {
            selector.AddSurrogate(typeof(T), new StreamingContext(StreamingContextStates.All), surrogate);
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
