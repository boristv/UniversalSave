using System.Diagnostics;
using SG.Global.SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class SaveImageExample : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private readonly string ExampleSaveImageKey = "TestImageKey";

    public void SaveImage()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
            
        UniversalSave.SaveImage(ExampleSaveImageKey, (Texture2D)_meshRenderer.material.mainTexture);

        stopWatch.Stop();
        Debug.Log($"Save image duration = {stopWatch.ElapsedMilliseconds} ms");
    }
    
    public void LoadImage()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
            
        if (UniversalSave.TryLoadImage(ExampleSaveImageKey, out var texture))
        {
            _meshRenderer.material.mainTexture = texture;
        }

        stopWatch.Stop();
        Debug.Log($"Load image duration = {stopWatch.ElapsedMilliseconds} ms");
    }

    public void ClearAll()
    {
        UniversalSave.ClearAll();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
