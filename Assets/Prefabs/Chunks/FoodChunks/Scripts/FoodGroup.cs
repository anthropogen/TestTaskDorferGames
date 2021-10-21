using System.Collections.Generic;
using UnityEngine;

public class FoodGroup : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private Food foodTemplate;
    [SerializeField] private float minFoodAmount;

    private void OnValidate()
    {
        if (minFoodAmount < 1)
            minFoodAmount = 1;
        if (minFoodAmount > spawnPoints.Count)
            minFoodAmount = spawnPoints.Count;
    }
    public void Spawn(Color color)
    {
        float amountFood = Random.Range(minFoodAmount, spawnPoints.Count);
        for (int i = 0; i < amountFood; i++)
        {
            int index = Random.Range(0, spawnPoints.Count);
            var food = Instantiate(foodTemplate, spawnPoints[index].position, Quaternion.identity,spawnPoints[index]);
            food.Paint(color);
            spawnPoints.RemoveAt(index);
        }
    }
}
