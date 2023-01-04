using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Wave Config",fileName ="New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public Transform GetStartingWayPoint() 
    { 
        return pathPrefab.GetChild(0);
    }

    public List<Transform>GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);  
        }
      return waypoints;
    }
    public float GetMoveSpeed() 
    {
        return moveSpeed; 
    }  
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public float GetRandomSpawnTime() 
    {
        float spawnTime = Random.Range(timeEnemySpawns - spawnTimeVariance,
            timeEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
    
}
