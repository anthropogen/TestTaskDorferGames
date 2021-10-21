using UnityEngine;

public class ObstackeChunk : MonoBehaviour
{
    [SerializeField] private ObstacleRow[] rows;
    private void Start()
    {
        foreach (var row in rows)
        {
            row.Spawn();
        }
    }
}
