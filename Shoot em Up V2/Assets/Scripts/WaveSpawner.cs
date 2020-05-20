using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState
    {
        Spawning,
        Waituing,
        Counting,
        Finished
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public int count;
        public int[] spawnOrder;
        public float spawnRate;
        public Transform[] enemy;


    }

    public Wave[] enemyWaves;
    public int nextWave = 0;
    public Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine(CRT_SpawnWave(enemyWaves[nextWave]));
    }


    void Update()
    {

    }

    IEnumerator CRT_SpawnWave(Wave _wave)
    {
        yield return new WaitForSeconds(_wave.spawnRate);
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy[0]);
        }

        //SpawnEnemy(_wave.enemy[0]);
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, spawnPoints[0].position, spawnPoints[0].rotation);
        Debug.Log("Spawn Enemy");
    }
}
