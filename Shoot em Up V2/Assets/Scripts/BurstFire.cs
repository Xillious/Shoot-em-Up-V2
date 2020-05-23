using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFire : MonoBehaviour
{
    public float timeBetweenShots;

    public int numberOfShots;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(FireAndRotate());
        }
    }

    IEnumerator FireAndRotate()
    {
        for (int i = 0; i < numberOfShots; i++)
        {
            ObjectPooler.Instance.SpawnfromPool("Bullet", transform.position, transform.rotation = Quaternion.Euler(0, 0, 0));
            yield return new WaitForSecondsRealtime(timeBetweenShots);

        }

    }
}
