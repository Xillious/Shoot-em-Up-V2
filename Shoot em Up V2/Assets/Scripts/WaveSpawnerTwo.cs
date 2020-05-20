using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerTwo : MonoBehaviour
{

    public GameObject enemy;
    public Transform[] spawnPoints;

    public int test = 0;
    public bool enemy1, enemy2, enemy3;


    public class Wave
    {
        public string name;
        public int count;

        public Transform enemyObj;
        public int[] spawnOrder;
        public float[] spawnRate;

    }

    void Start()
    {
        StartCoroutine(WaveOne());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator WaveTwo(Wave _wave)
    {


        Instantiate(enemy, spawnPoints[0].position, spawnPoints[0].rotation);
        yield break;
    }

    private IEnumerator WaveOne()
    {
        Instantiate(enemy, spawnPoints[0].position, spawnPoints[0].rotation);
        Instantiate(enemy, spawnPoints[2].position, spawnPoints[2].rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(enemy, spawnPoints[1].position, spawnPoints[1].rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(enemy, spawnPoints[2].position, spawnPoints[2].rotation);
        yield return new WaitForSeconds(1f);
        yield break;
    }


}
