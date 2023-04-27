using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SG.Global.SaveSystem.EditorTool
{
    public static class UniversalEditorSave
    {
        public static void SaveImageToFile(this Texture2D texture, string fileName, string path)
        {
#if UNITY_EDITOR
            if (texture == null) return;

            var byteArray = texture.EncodeToPNG();

            if (Directory.Exists(path))
            {
                var fullPath = Path.Combine(path, $"{fileName}.png");
                File.WriteAllBytes(fullPath, byteArray);
            }
#endif
        }

        public static void SaveImageToFileInProject(this Texture2D texture, string fileName, string subPath = "")
        {
#if UNITY_EDITOR
            if (texture == null) return;

            var byteArray = texture.EncodeToPNG();

            var path = Path.Combine(Application.dataPath, subPath);
            if (Directory.Exists(path))
            {
                var fullPath = Path.Combine(path, $"{fileName}.png");
                File.WriteAllBytes(fullPath, byteArray);
                AssetDatabase.Refresh();
            }
#endif
        }
    }
}