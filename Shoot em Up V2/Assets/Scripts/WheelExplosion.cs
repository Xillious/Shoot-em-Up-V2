using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelExplosion : MonoBehaviour
{

    public float timeBetweenShots;

    private float rotateAmount;

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
            ObjectPooler.Instance.SpawnfromPool("Bullet", transform.position, transform.rotation = Quaternion.Euler(0, 0, rotateAmount));
            yield return new WaitForSecondsRealtime(timeBetweenShots);

            rotateAmount += 360 / numberOfShots;
        }
    }
}
