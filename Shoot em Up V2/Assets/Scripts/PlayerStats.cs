using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int playerHealth = 1;
    public int playerLevel = 1;
    public int shotFrequency = 0;
    public int shotCooldown = 0;

    public float moveSpeed = 10f;
    public GameObject bullet;
    public GameObject player;

    private PlayerController playerController;

    public Sprite[] playerSprite;

    //public Sprite player_lvl_1;
    //public Sprite player_lvl_2;

    void Start()
    {
        StartCoroutine(FindPlayer());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerController.UpdatePlayerStats();
            //UpdatePlayerStats();
        }
    }

    private IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(1f);
        playerController = FindObjectOfType<PlayerController>();
        Debug.Log("Found Player");
    }

    public void LevelPlayer()
    {
        playerLevel++;
        playerController.UpdatePlayerStats();
        Debug.Log("level: " + playerLevel);
        playerController.UpdatePlayerSprite();
    }

    public void DamagePlayer(int _damage)
    {
        // take _damage
    }

}
