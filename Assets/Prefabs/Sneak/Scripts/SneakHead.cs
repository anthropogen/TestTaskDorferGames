using UnityEngine;
using UnityEngine.Events; 
[RequireComponent(typeof(Rigidbody))]
public class SneakHead : Colored
{
    [SerializeField] private Sneak sneak;
    private Rigidbody _rigidbody;
    public event UnityAction Died;
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
                if (!sneak.IsFever)
                {
                    sneak.gameObject.SetActive(false);
                    Died?.Invoke();
                    return;
                }
                obstacle.gameObject.SetActive(false);
            }
        }
    }
}
