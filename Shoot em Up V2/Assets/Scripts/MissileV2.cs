using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileV2 : MonoBehaviour
{


    public int finalPosition;

    public int numberOfPositions;

    public float xMin, xMax;
    public float yMin, yMax;

    private float _moveSpeed = 5;


    private Rigidbody2D rb;

    private Vector2 targetPos;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //targetPos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        targetPos = new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1), Random.Range(transform.position.y + 0.5f, transform.position.y + 2));

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.rotation);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, _moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.5f)
        {
            // Debug.Log("at position");
            targetPos = new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1), Random.Range(transform.position.y + 0.5f, transform.position.y + 1));
            //targetPos = new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1), Random.Range(transform.position.y, transform.position.y + 1));
            numberOfPositions++;
            //_moveSpeed++;

            if (numberOfPositions == finalPosition)
            {
                gameObject.SetActive(false);
                ObjectPooler.Instance.SpawnfromPool("Explosion", transform.position, transform.rotation);
                //targetPos = new Vector2(0, 0);
                numberOfPositions = 0;

            }
        }


        //points the missile at the target (the -90 is to make it go forward, it was horizontal before dont know why?)
        var angle = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle - 90), 20f * Time.deltaTime);


    }


}