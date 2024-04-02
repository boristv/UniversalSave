using UnityEngine;

namespace SG.Global.SaveSystem
{
    public static class UniversalSaveExtensions
    {
        public static Texture2D Decompress(this Texture2D source)
        {
            RenderTexture renderTex = RenderTexture.GetTemporary(
                source.width,
                source.height,
                0,
                RenderTextureFormat.Default,
                RenderTextureReadWrite.Default);

            Graphics.Blit(source, renderTex);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = renderTex;
            Texture2D readableTex = new Texture2D(source.width, source.height);
            readableTex.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
            readableTex.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(renderTex);
            return readableTex;
        }

        public static ISerializationFormatter GetFormatter(this UniversalSaveSettings settings)
        {
            ISerializationFormatter formatter;
            switch (settings.FormatterType)
            {
                default:
                case SerializationFormatterType.JsonUtility:
                    formatter = new JsonUtilitySerializationFormatter();
                    break;
                case SerializationFormatterType.JsonConvert:
                    formatter = new JsonSerializationFormatter();
                    break;
                case SerializationFormatterType.Binary:
                    formatter = new BinarySerializationFormatter();
                    break;
            }

            return formatter;
        }

        public static IDataStorage GetDataStorage(this UniversalSaveSettings settings)
        {
            IDataStorage storage;
            switch (settings.StorageType)
            {
                default:
                case DataStorageType.PlayerPrefs:
                    storage = new PlayerPrefsDataStorage();
                    break;
                case DataStorageType.File:
                    storage = new FileDataStorage();
                    break;
            }

            if (settings.UseSingleStorage)
            {
                storage = new SingleMediatorDataStorage(storage, settings.GetFormatter(), settings.SingleStorageName);
            }

            return storage;
        }
    }
}