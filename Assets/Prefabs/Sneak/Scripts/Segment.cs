using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField, Range(1,2 )] private float angleSpeedModificator;
    private float _angleSpeed;
    private Transform _transform;
    private void Start()
    {
        _transform = transform;
    }
    public void Move(Vector3 nextPosition,float speed)
    {
        _angleSpeed = nextPosition.x != _transform.position.x ? angleSpeedModificator : 1;
        transform.position = Vector3.Lerp(transform.position, nextPosition,speed* _angleSpeed * Time.deltaTime);
    }
}
