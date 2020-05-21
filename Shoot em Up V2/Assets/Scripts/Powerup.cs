using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    private PlayerStats playerStats;
    public float movespeed = 0f;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }


    void Update()
    {
        //transform.Translate(0, -movespeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerStats.LevelPlayer();
            Destroy(gameObject);
        }
    }
}
