using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishChunk : Chunk
{
    [SerializeField] private Transform start;
    public override Transform Start => start;

    public override Transform End => start;
    public event UnityAction<FinishChunk> LevelEnded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SneakHead head))
        {
            if (head!=null)
            {
                LevelEnded?.Invoke(this);
            }
        }
    }

}
