using System.Runtime.Serialization;
using UnityEngine;

namespace SG.Global.SaveSystem
{
    public class Color32SerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var color32 = (Color32) obj;
            info.AddValue("r", color32.r);
            info.AddValue("g", color32.g);
            info.AddValue("b", color32.b);
            info.AddValue("a", color32.a);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var color32 = (Color32) obj;
            color32.r = (byte) info.GetValue("r", typeof(byte));
            color32.g = (byte) info.GetValue("g", typeof(byte));
            color32.b = (byte) info.GetValue("b", typeof(byte));
            color32.a = (byte) info.GetValue("a", typeof(byte));
            obj = color32;
            return obj;
        }
    }
}