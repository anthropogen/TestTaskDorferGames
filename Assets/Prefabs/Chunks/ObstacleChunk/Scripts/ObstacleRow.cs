using System.Collections.Generic;
using UnityEngine;

public class ObstacleRow : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private Crystal crystalTemplate;
    [SerializeField] private Obstacle obstacleTemplate;

    public void Spawn()
    {
        int amountCrystal = Random.Range(0, 1f) > 0.5f ? 2 : 1;
        for (int i = 0; i < amountCrystal; i++)
        {
            int index = Random.Range(0, spawnPoints.Count);
            Instantiate(crystalTemplate, spawnPoints[index].position, Quaternion.identity, spawnPoints[index]);
            spawnPoints.RemoveAt(index);
        }
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            Instantiate(obstacleTemplate, spawnPoints[i].position, Quaternion.identity, spawnPoints[i]);
        }
    }
}
