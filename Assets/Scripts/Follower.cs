using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField, Range(0, 1)] private float speed;
    private Transform _transform;
    private Vector3 _offset;
    private void Awake()
    {
        _transform = transform;
        _offset = target.position - _transform.position;
    }
    private void FixedUpdate()
    {
        
        _transform.position=Vector3.Lerp(_transform.position, new Vector3(0, target.position.y, target.position.z)-_offset,speed);
    }
}
