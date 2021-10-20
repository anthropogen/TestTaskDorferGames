using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class SneakHead : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 nextPosition)
    {
        _rigidbody.MovePosition(nextPosition);
    }
}
