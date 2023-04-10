using System;
using System.Collections.Generic;
using SG.Global.SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveExample : MonoBehaviour
{
    [SerializeField] private ExampleSaveData _exampleSaveData;
    [SerializeField] private List<ColorObject> _colorObjects;

    private readonly string ExampleSaveDataKey = "TestKey";

    private void Awake()
    {
        UniversalSave.DefaultSettings = new UniversalSaveSettings()
        {
            StorageType = DataStorageType.File,
            FormatterType = SerializationFormatterType.Binary
        };
    }

    public void Save()
    {
        UniversalSave.Save(ExampleSaveDataKey, _exampleSaveData);
        
        for (var i = 0; i < _colorObjects.Count; i++)
        {
            UniversalSave.Save($"ColorObject_Color_{i}", _colorObjects[i].GetColor());

            var positionData = new ObjectPositionData()
            {
                Position = _colorObjects[i].transform.position,
                Rotation = _colorObjects[i].transform.rotation
            };
            UniversalSave.Save($"ColorObject_Position_{i}", positionData);
        }
    }
    
    public void Load()
    {
        _exampleSaveData = UniversalSave.Load<ExampleSaveData>(ExampleSaveDataKey);
        
        for (var i = 0; i < _colorObjects.Count; i++)
        {
            if (UniversalSave.TryLoad($"ColorObject_Color_{i}", out Color color))
            {
                _colorObjects[i].SetColor(color);
            }
            
            if (UniversalSave.TryLoad($"ColorObject_Position_{i}", out ObjectPositionData positionData))
            {
                _colorObjects[i].transform.position = positionData.Position;
                _colorObjects[i].transform.rotation = positionData.Rotation;
            }
        }
    }

    public void ClearAll()
    {
        UniversalSave.ClearAll();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    [Serializable]
    private class ObjectPositionData
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
    
    [Serializable]
    public struct ExampleSaveData
    {
        public int TestParameter1;
        public int TestParameter2;
        public string TestString;
        public List<float> TestList;
        public Vector3 TestVector3;
        public Vector2Int TestVector2Int;
        public Color TestColor;
    }
}
