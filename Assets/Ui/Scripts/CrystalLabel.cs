using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalLabel : Label
{
    [SerializeField] private Jaws jaws;

    private void OnEnable()
    {
        jaws.EatenCrystalChanged += OnValuerChanged;
    }
    private void OnDisable()
    {
        jaws.EatenCrystalChanged -= OnValuerChanged;
    }
    
}
