using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private ColorInstaller colorInstaller;
    [SerializeField] private ObstacleChunk[] obstacleTemplates;
    [SerializeField] private FoodChunk[] foodsTemplates;
    [SerializeField] private Chunk firstChunk;
    [SerializeField] private FinishChunk finishChunk;
    [SerializeField] private Transform road;
    [SerializeField] private int levelSize;
    [SerializeField] private float offsetSpawnZ;
    private List<Chunk> _chunks;
    private void OnEnable()
    {
        game.StartedGame += Spawn;
    }
    private void OnDisable()
    {
        game.StartedGame -= Spawn;
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
      var finish= (FinishChunk) InstantiateChunk(finishChunk);
        finish.LevelEnded += game.Win;
        SetRoadLenght(finish);      
    }
    private void SpawnObstacleChunk()
    {
        var chunk =(ObstacleChunk) InstantiateChunk(obstacleTemplates[Random.Range(0, obstacleTemplates.Length)]);
        chunk.Spawn();
    }
    private void SpawnFoodChunk()
    {
        var chunk =(FoodChunk) InstantiateChunk(foodsTemplates[Random.Range(0, foodsTemplates.Length)]);
        chunk.Spawn(colorInstaller);
    }
    private Chunk InstantiateChunk(Chunk chunkTemplate)
    {
        var chunk = Instantiate(chunkTemplate,transform);
        chunk.transform.position = new Vector3(0, 0, _chunks[_chunks.Count - 1].End.position.z - chunk.Start.localPosition.z + offsetSpawnZ);
        _chunks.Add(chunk);
        return chunk;
    }
    private void SetRoadLenght(FinishChunk finish)
    {
        float lenght = Vector3.Distance(firstChunk.transform.position, finish.transform.position);
        road.transform.localScale = new Vector3(road.localScale.x, road.localScale.y, lenght);
        road.transform.position = new Vector3(road.transform.position.x, road.transform.position.y, (lenght / 2)-10);       
    }
}
