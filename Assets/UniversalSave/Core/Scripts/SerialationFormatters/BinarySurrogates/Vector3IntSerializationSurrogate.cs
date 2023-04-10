using System.Runtime.Serialization;
using UnityEngine;

namespace SG.Global.SaveSystem
{
    public class Vector3IntSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var v3Int = (Vector3Int) obj;
            info.AddValue("x", v3Int.x);
            info.AddValue("y", v3Int.y);
            info.AddValue("z", v3Int.z);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var v3Int = (Vector3Int) obj;
            v3Int.x = (int) info.GetValue("x", typeof(int));
            v3Int.y = (int) info.GetValue("y", typeof(int));
            v3Int.z = (int) info.GetValue("z", typeof(int));
            obj = v3Int;
            return obj;
        }
    }
}