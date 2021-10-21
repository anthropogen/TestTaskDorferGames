using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField,Range(0,1)] private float speedRotate;
    private Transform _transform;
    private void Start()
    {
        _transform = transform;
    }
    private void Update()
    {
        _transform.Rotate(0,180*speedRotate*Time.deltaTime,0);   
    }
}
