using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float timeWaves = 0f;
     WaveConfig currentWawe;
    [SerializeField] bool isLoop;
    void Start()
    {
       StartCoroutine( SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public WaveConfig GetCurrentWave()
    {
        return currentWawe; 
    }
    IEnumerator SpawnEnemy()
    {
        do {
            foreach (WaveConfig wave in waveConfigs)
            {
                currentWawe = wave;
                for (int i = 0; i < currentWawe.GetEnemyCount(); i++)
                {
                    Instantiate(currentWawe.GetEnemyPrefab(i),
                                currentWawe.GetStartingWayPoint().position,
                                Quaternion.Euler(0,0,180),
                                transform);
                    yield return new WaitForSeconds(currentWawe.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeWaves);
            }
           
       
        }
        while (isLoop);


    }
}
