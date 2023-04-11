using UnityEngine;

public class GradientGenerator : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Gradient _gradient;
    [SerializeField, Range(1, 1024)] private int _resolution = 64;

    private float _step;

    public void Generate()
    {
        var texture = new Texture2D(_resolution, _resolution);
        
        _step = 1f / _resolution;
        
        for (var y = 0; y < _resolution; y++)
        {
            for (var x = 0; x < _resolution; x++)
            {
                texture.SetPixel(x, y, _gradient.Evaluate(y * _step));
            }
        }
        
        texture.Apply();

        _meshRenderer.material.mainTexture = texture;
    }
}