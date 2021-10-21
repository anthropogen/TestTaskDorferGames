using UnityEngine;

public class ObstacleChunk: Chunk
{
    [SerializeField] private ObstacleRow[] rows;

    public override Transform Start { get => rows[0].transform; }
    public override Transform End { get => rows[rows.Length - 1].transform; }

    public void Spawn()
    {
        foreach (var row in rows)
        {
            row.Spawn();
        }
    }
}
