using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectDrag : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _mouseZOffset = 0.1f;
    
    private Rigidbody _rb;
    private Vector3 _mouseOffset;
    private float _mouseZCoord;
    private Camera _mainCamera;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        _mouseZCoord = _mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
        _mouseOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = _mouseZCoord + _mouseZOffset;

        return _mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        var direction = ((GetMouseAsWorldPoint() + _mouseOffset) - _rb.position);
        _rb.velocity = direction * _speed;
    }
}