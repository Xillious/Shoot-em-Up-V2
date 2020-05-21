using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float speed = 15f;
    public Rigidbody2D rb;

    void Start()
    {
        //rb.velocity = transform.up * speed;

        // StartCoroutine(Destroy());
    }


    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
