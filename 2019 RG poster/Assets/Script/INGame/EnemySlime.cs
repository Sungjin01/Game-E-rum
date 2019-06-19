using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    public float movePower = 2;
    Animator animator;
    Vector3 movement;
    int moveDirection = 0;
    bool isTracing;
    GameObject target;
    int isJump;
    public int hp = 10;


    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        isJump = animator.GetInteger("isJump");

        StartCoroutine("AutoMove");
        StartCoroutine("Jump");
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator AutoMove()
    {
        moveDirection = Random.Range(0, 3);
        yield return new WaitForSeconds(3f);

        StartCoroutine("AutoMove");
    }

    IEnumerator Jump()
    {
        animator.SetInteger("isJump", animator.GetInteger("isJump")+1);

        yield return new WaitForSeconds(Random.Range(2, 5));
        StartCoroutine("Jump");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if(isJump != animator.GetInteger("isJump"))
        {
            isJump = animator.GetInteger("isJump");
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        if (isTracing)
        {
            movePower = 3;
            Vector3 playerPos = target.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Left";
            else if (playerPos.x > transform.position.x)
                dist = "Right";
        }
        else
        {
            movePower = 2;
            if (moveDirection == 1)
                dist = "Left";
            else if (moveDirection == 2)
                dist = "Right";
        }

        if (dist == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
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
