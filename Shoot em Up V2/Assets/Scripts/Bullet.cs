using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 15f;


    void Start()
    {



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




    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("hit enemy");
            gameObject.SetActive(false);
            ObjectPooler.Instance.SpawnfromPool("Explosion", transform.position, transform.rotation);
        }
    }




}
