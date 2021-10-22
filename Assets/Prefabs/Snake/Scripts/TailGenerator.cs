using System.Collections.Generic;
using UnityEngine;

public class TailGenerator : MonoBehaviour
{
    [SerializeField] private int tailSize;
    [SerializeField] private Segment segmentTemplate;
    private void OnValidate()
    {
        if (tailSize < 1)
            tailSize = 1;
    }
    public List<Segment> Generate()
    {
        List<Segment> tail = new List<Segment>();
        for (int i = 0; i < tailSize; i++)
        {
            tail.Add(Instantiate(segmentTemplate, transform));
        }
        return tail;
    }
}
