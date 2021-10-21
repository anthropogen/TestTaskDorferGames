using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChunk : MonoBehaviour
{
    [SerializeField] private FoodGroup[] groups;
    [SerializeField] private ColorCheckPoint checkPoint;
    [SerializeField] private ColorInstaller colorInstaller;
    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        Color[] colors = new Color[] {colorInstaller.GetColor(), colorInstaller.GetColor() };
        checkPoint.Paint(colors[0]);
        foreach (var group in groups)
        {
            group.Spawn(colors[Random.Range(0, colors.Length)]);
        }
    }
}
