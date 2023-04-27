using System;
using UnityEditor;
using UnityEngine;

namespace SG.Global.SaveSystem.EditorTool
{
    public static class UniversalSaveEditorExtensions
    {
        [MenuItem("CONTEXT/Texture/Save Image")]
        private static void SaveImage(MenuCommand command)
        {
            var texture = (Texture2D) command.context;
            if (texture != null)
            {
                texture.Decompress().SaveImageToFileInProject($"Texture_{DateTime.Now.ToOADate()}");
            }
        }
    }
}