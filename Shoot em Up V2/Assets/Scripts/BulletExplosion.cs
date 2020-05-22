using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{

    private float rotateAmount;

    private int numberOfRotations = 5;
    public int numberOfShots;

    void Start()
    {

    }


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.K))
        {

            for (int i = 0; i < numberOfShots; i++)
            {
                rotateAmount += 360 / numberOfShots;
                ObjectPooler.Instance.SpawnfromPool("Bullet", transform.position, transform.rotation = Quaternion.Euler(0, 0, rotateAmount));
                StartCoroutine(ResetRotation());

            }

        }


        if (rotateAmount >= 360)
        {
            rotateAmount = 0;
        }

    }

    IEnumerator ResetRotation()
    {

        yield return new WaitForSecondsRealtime(0.2f);
        rotateAmount = 0;
    }

}
