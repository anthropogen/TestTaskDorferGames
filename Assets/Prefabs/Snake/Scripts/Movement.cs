using UnityEngine;
using System.Collections.Generic;
public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected SnakeHead Head;
    [SerializeField] protected float Speed;
    [SerializeField] protected float Springiness;
    [SerializeField] protected Vector2 RangeMoveZoneOnX;
    protected Vector3 NextPosition;
    public abstract void Move(List<Segment> tail); 
}
