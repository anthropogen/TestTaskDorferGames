using UnityEngine;
using UnityEngine.Events; 
[RequireComponent(typeof(Rigidbody))]
public class SnakeHead : Colored
{
    [SerializeField] private Snake snake;
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
                if (!snake.IsFever)
                {
                    snake.gameObject.SetActive(false);
                    Died?.Invoke();
                    return;
                }
                obstacle.gameObject.SetActive(false);
            }
        }
    }
}
