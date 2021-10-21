using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChunk : Chunk
{
    [SerializeField] private FoodGroup[] groups;
    [SerializeField] private ColorCheckPoint checkPoint;

    public override Transform Start => checkPoint.transform;

    public override Transform End => groups[groups.Length-1].transform;

    public void Spawn(ColorInstaller colorInstaller)
    {
        Color[] colors = new Color[] {colorInstaller.GetColor(), colorInstaller.GetColor() };
        checkPoint.Paint(colors[0]);
        foreach (var group in groups)
        {
            group.Spawn(colors[Random.Range(0, colors.Length)]);
        }
    }
}
