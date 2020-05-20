using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;

    public float speed;

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        //StartCoroutine(ShootRandomly(1, 4));
    }

    private IEnumerator ShootRandomly(float _min, float _max)
    {
        float time = 0;
        time = Random.Range(_min, _max);
        yield return new WaitForSeconds(time);
        Shoot();
        time = 0;
    }

    void Shoot()
    {
        Debug.Log("enemy shooting");
    }

    private void Die()
    {
        //award score
        //play death sound and aimation
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().PlayerDamage();
            Die();
        }
    }
}
