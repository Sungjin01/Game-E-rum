using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : MonoBehaviour
{
    public float speed = 2.0f;
    public int hp = 5;
    int moveDirection;
    Vector3 movement;
    bool isTracing;
    GameObject target;

    void Start()
    {
        StartCoroutine("AutoMove");
        moveDirection = 0;
    }

    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (isTracing)  // 범위 내에 타겟 들어오면
        {
            moveVelocity = target.transform.position - transform.position;
            if(moveVelocity.x > 0)
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }
            else
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            speed = 1;
        }
        else
        {
            speed = 2;
            if(moveDirection == 1)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else if(moveDirection == 2)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }
        }

        transform.position += moveVelocity * speed * Time.deltaTime;
    }

    IEnumerator AutoMove()
    {
        moveDirection = Random.Range(0, 3);


        yield return new WaitForSeconds(1f);

        StartCoroutine("AutoMove");
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
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "arrow")
        {
            hp -= 3;
            Destroy(other.gameObject);
        }
    }

}
