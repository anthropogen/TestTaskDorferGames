using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class SneakHead : Colored
{
    [SerializeField] private Sneak sneak;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 nextPosition)
    {
        _rigidbody.MovePosition(nextPosition);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            if (obstacle != null)
            {
                Debug.Log("falled");
                sneak.gameObject.SetActive(false);
            }
        }
    }
}
