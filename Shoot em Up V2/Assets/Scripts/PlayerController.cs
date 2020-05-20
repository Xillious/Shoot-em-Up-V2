using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private int _playerLevel = 0;
    private int _shotFrequency = 0;
    private int _shotCooldown = 0;

    private float _moveSpeed = 5f;

    private bool _canShoot = false;

    private Vector2 _moveVelocity;
    [SerializeField]
    private GameObject _bullet;

    public Transform firePoint_1;
    public Transform firePoint_2;
    public Transform firePoint_3;
    public Transform firePoint_4;
    public Transform firePoint_5;


    private Rigidbody2D rb;

    private PlayerStats playerStats;

    private Sprite playerSprite;


    void Start()
    {

        playerStats = FindObjectOfType<PlayerStats>();
        //playerSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(InitialiseStats());
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }
    void Update()
    {
        CheckInput();
        //StartCoroutine(InitialiseStats());
    }

    void ApplyMovement()
    {
        rb.MovePosition(rb.position + _moveVelocity * Time.fixedDeltaTime);
    }

    void CheckInput()
    {
        Vector2 _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = _moveInput.normalized * _moveSpeed;

        if (Input.GetKey(KeyCode.Space) && _shotCooldown >= _shotFrequency)
        {
            Shoot();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _shotCooldown = _shotFrequency;
        }

        _shotCooldown++;

        if (Input.GetKeyDown(KeyCode.R))
        {
            // UpdatePlayerStats();
        }
        // 1700 orb staff 8
    }

    void Shoot()
    {
        if (_playerLevel == 1)
        {
            Instantiate(_bullet, firePoint_1.position, firePoint_1.rotation);
        }
        else if (_playerLevel == 2)
        {
            Instantiate(_bullet, firePoint_2.position, firePoint_2.rotation);
            Instantiate(_bullet, firePoint_3.position, firePoint_3.rotation);
        }
        else if (_playerLevel == 3)
        {
            Instantiate(_bullet, firePoint_1.position, firePoint_1.rotation = Quaternion.Euler(0, 0, 0));
            Instantiate(_bullet, firePoint_2.position, firePoint_2.rotation = Quaternion.Euler(0, 30, 30));
            Instantiate(_bullet, firePoint_3.position, firePoint_3.rotation = Quaternion.Euler(0, -30, -30));
        }
        _shotCooldown = 0;
    }

    public void UpdatePlayerStats()
    {
        _moveSpeed = playerStats.moveSpeed;
        _bullet = playerStats.bullet;
        _playerLevel = playerStats.playerLevel;
        _shotCooldown = playerStats.shotCooldown;
        _shotFrequency = playerStats.shotFrequency;

    }

    public void UpdatePlayerSprite()
    {
        if (_playerLevel == 1)
        {
            //playerSprite = playerStats.playerSprite[0];
            gameObject.GetComponent<SpriteRenderer>().sprite = playerStats.playerSprite[0];
        }
        else if (_playerLevel == 2)
        {
            //playerSprite = playerStats.playerSprite[1];
            gameObject.GetComponent<SpriteRenderer>().sprite = playerStats.playerSprite[1];
        }
        else if (_playerLevel == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerStats.playerSprite[2];
        }
    }

    private IEnumerator InitialiseStats()
    {
        yield return new WaitForSeconds(1f);
        UpdatePlayerStats();
        Debug.Log("Player Stats");

    }

    public void PlayerDamage()
    {
        Debug.Log("take damage");
    }
}
