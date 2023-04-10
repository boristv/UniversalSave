using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorObject : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }

    public Color GetColor() => _meshRenderer.material.color;
}
