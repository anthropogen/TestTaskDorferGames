using System.Collections.Generic;
using UnityEngine;

public class Sneak : MonoBehaviour
{
    [SerializeField] private TailGenerator generator;
    [SerializeField] private SneakHead head;
    [SerializeField] private SneakInput input;
    [SerializeField] private float speed;
    [SerializeField] private float springiness;
    private List<Segment> _tail;

    private void Awake()
    {
        _tail = generator.Generate();
    }

    private void FixedUpdate()
    {
        Move(head.transform.position +input.GetDiretion(head.transform.position)*speed*Time.deltaTime);
    }
    private void Move(Vector3 nextPosition)
    {
        Vector3 prevPosition = head.transform.position;
        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.Move(prevPosition, springiness);
            prevPosition = tempPosition;
        }
        head.Move(nextPosition);
    }
}
