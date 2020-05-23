using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerOne : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public string enemyName;
        public int waveLength;
        public float[] spawnRate;
        public float[] spawnOffset;

    }

    public Wave[] waves;
    float offset = 0; // enemy spawn offset from left of screen
    float rate = 0; // time each enemy waits before spawning
    int offsetAmount; // number in the array of spawnOffset
    int rateAmount; // number in the array of spawnRate



    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(SpawnWave(waves[1]));
        }
    }


    IEnumerator SpawnWave(Wave _wave)
    {
        for (int i = 0; i < _wave.waveLength; i++)
        {
            offset += _wave.spawnOffset[offsetAmount];
            offsetAmount++;
            if (offsetAmount >= _wave.spawnOffset.Length)
            {
                offsetAmount = 0;
            }
            ObjectPooler.Instance.SpawnfromPool(_wave.enemyName, transform.position + new Vector3(offset, 0, 0), transform.rotation);
            rateAmount++;
            if (rateAmount >= _wave.spawnRate.Length)
            {
                rateAmount = 0;
            }
            yield return new WaitForSecondsRealtime(_wave.spawnRate[rateAmount]);
            offset = 0;
        }
    }
}
