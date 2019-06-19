using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGround : MonoBehaviour
{
    public float movePower = 2;
    Animator animator;
    Vector3 movement;
    int moveDirection = 0;
    bool isTracing;
    GameObject target;
    public int hp = 15;


    // Use this for initialization
    void Start()
    {
        StartCoroutine("AutoMove");
    }

    IEnumerator AutoMove()
    {
        moveDirection = Random.Range(0, 3);
        yield return new WaitForSeconds(3f);

        StartCoroutine("AutoMove");
    }

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (isTracing)
        {
            Vector3 playerPos = target.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Left";
            else if (playerPos.x > transform.position.x)
                dist = "Right";
        }
        else
        {
            if (moveDirection == 1)
                dist = "Left";
            else if (moveDirection == 2)
                dist = "Right";
        }

        if (dist == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        };

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject;
            StopCoroutine("AutoMove");
        }
        else if (other.gameObject.tag == "spear")
        {
            hp -= 2;
        }
        else if (other.gameObject.tag == "sword")
        {
            hp--;
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = false;
            StartCoroutine("AutoMove");
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "arrow")
        {
            hp -= 2;
            Destroy(other.gameObject);
        }
    }
}
