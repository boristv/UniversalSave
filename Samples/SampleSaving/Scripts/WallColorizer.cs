using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class WallColorizer : MonoBehaviour
{
    [SerializeField] private Color _color= Color.red;

    private MeshRenderer _meshRenderer;
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = _color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ColorObject colorObject))
        {
            colorObject.SetColor(_color);
        }
    }
}
