using System.Collections.Generic;
using UnityEngine;

public class FeverMovement : Movement
{
    public override void Move(List<Segment> tail)
    {

        NextPosition = (Head.transform.position + new Vector3(0-Head.transform.position.x,0,1) * Speed * Time.fixedDeltaTime);
        NextPosition.x = Mathf.Clamp(NextPosition.x, RangeMoveZoneOnX.x, RangeMoveZoneOnX.y);
        Vector3 prevPosition = Head.transform.position;
        foreach (var segment in tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.Move(prevPosition, Springiness);
            prevPosition = tempPosition;
        }
        Head.Move(NextPosition);
    }
}
