
using UnityEngine;

public abstract class Chunk : MonoBehaviour
{
    public abstract Transform Start { get;  }
    public abstract Transform End { get; }
}
