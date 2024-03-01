using System;
using UnityEditor;
using UnityEngine;

namespace SG.Global.SaveSystem.EditorTool
{
    public static class UniversalSaveEditorExtensions
    {
        [InitializeOnLoadMethod]
        private static void Initialization()
        {
            EditorApplication.contextualPropertyMenu += OnPropertyContextMenu;
        }

        private static void OnPropertyContextMenu(GenericMenu menu, SerializedProperty property)
        {
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                switch (property.objectReferenceValue)
                {
                    case Texture texture:
                        menu.AddItem(new GUIContent("Save Image"), false, () =>
                        {
                            var texture2D = (Texture2D) texture;
                            SaveTexture(texture2D);
                        });
                        break;
                    case Sprite sprite:
                        menu.AddItem(new GUIContent("Save Image"), false, () =>
                        {
                            SaveTexture(sprite.texture);
                        });
                        break;
                }
            }
        }

        [MenuItem("CONTEXT/Texture/Save Image")]
        private static void SaveImage(MenuCommand command)
        {
            var texture2D = (Texture2D) command.context;
            SaveTexture(texture2D);
        }

        private static void SaveTexture(Texture2D texture2D)
        {
            if (texture2D != null)
            {
                var timeFormat = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";
                texture2D.Decompress().SaveImageToFileInProject($"Texture_{timeFormat}");
            }
        }
    }
}