using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private ColorInstaller colorInstaller;
    [SerializeField] private ObstacleChunk[] obstacleTemplates;
    [SerializeField] private FoodChunk[] foodsTemplates;
    [SerializeField] private Chunk firstChunk;
    [SerializeField] private int levelSize;
    [SerializeField] private float offsetSpawnZ;
    private List<Chunk> _chunks;
    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        _chunks = new List<Chunk>();
        _chunks.Add(firstChunk);
        for (int i = 0; i < levelSize; i++)
        {
        SpawnFoodChunk();
        SpawnObstacleChunk();
        }
    }
    private void SpawnObstacleChunk()
    {
        var chunk = Instantiate(obstacleTemplates[Random.Range(0, obstacleTemplates.Length)]);
        chunk.transform.position = new Vector3(0, 0, _chunks[_chunks.Count - 1].End.position.z - chunk.Start.localPosition.z+offsetSpawnZ);
        chunk.Spawn();
        _chunks.Add(chunk);
    }
    private void SpawnFoodChunk()
    {
        var chunk = Instantiate(foodsTemplates[Random.Range(0, foodsTemplates.Length)]);
        chunk.transform.position = new Vector3(0,0, _chunks[_chunks.Count - 1].End.position.z - chunk.Start.localPosition.z+offsetSpawnZ);
        chunk.Spawn(colorInstaller);
        _chunks.Add(chunk);
    }
}
