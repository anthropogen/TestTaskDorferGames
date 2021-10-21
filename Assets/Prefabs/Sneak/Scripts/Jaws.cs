using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaws : MonoBehaviour
{
    [SerializeField] private Sneak sneak;
    [SerializeField] private SneakHead head;
    [SerializeField] private int needCrystalToFever;
    private int _eatenCrystalInRow;
    private int _eatenFood;
    private int _eatenCrystal;
    private void Start()
    {
        _eatenFood = 0;
        _eatenCrystal = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food))
        {
            if (food!=null)
            {
                CheckFood(food);
            }
        }
        else if(other.TryGetComponent(out Crystal crystal))
        {
            if (crystal!=null)
            {
                CheckCrystal(crystal);
            }
        }
    }
   
    private void CheckFood(Food food)
    {
        if (food.Color != head.Color)
        {
            Debug.Log("Falled");
            sneak.gameObject.SetActive(false);
        }
        else { 
         _eatenFood++;
            _eatenCrystalInRow = 0;
        food.gameObject.SetActive(false);
    }
    }
    private void CheckCrystal(Crystal crystal)
    {
        _eatenCrystalInRow++;
        _eatenCrystal++;
        Debug.Log("Crystal");
        if (_eatenCrystalInRow>needCrystalToFever)
        {
            Debug.Log("Fever");
        }
        crystal.gameObject.SetActive(false);
    }
}
