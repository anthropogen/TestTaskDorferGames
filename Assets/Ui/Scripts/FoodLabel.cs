using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLabel : Label
{
    [SerializeField] private Jaws jaws;
    private void OnEnable()
    {
        jaws.EatenFoodChanged += OnValuerChanged;
    }
    private void OnDisable()
    {
        jaws.EatenFoodChanged -= OnValuerChanged;
    }
}
