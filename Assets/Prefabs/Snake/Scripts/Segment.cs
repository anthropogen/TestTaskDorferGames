using UnityEngine;

public class Segment : Colored
{
    public void Move(Vector3 nextPosition,float springiness)
    {
        float magnitude = Vector3.Distance(nextPosition, transform.position);
        transform.LookAt(nextPosition);
        float modificator = springiness * magnitude * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition,modificator);
    }
}
