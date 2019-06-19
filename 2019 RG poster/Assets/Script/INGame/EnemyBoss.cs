using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    Animator animator;
    bool isTracing;
    GameObject target;
    public int hp = 40;
    public GameObject dead;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Instantiate(dead, new Vector3(transform.position.x, transform.position.y-2.3f, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator PatternA()
    {
        animator.SetBool("isRun", true);
        for (int i = 0; i < Random.Range(50, 75);i++)
        {
            transform.Translate(new Vector3(0.15f*transform.localScale.x, 0, 0));
            yield return null;
        }
        animator.SetBool("isRun", false);
        yield return new WaitForSeconds(4f);
        StartCoroutine("PatternA");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (isTracing)
        {
            Vector3 playerPos = target.transform.position;

            if (playerPos.x < transform.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (playerPos.x > transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject;
            StartCoroutine("PatternA");
        }
        else if (other.gameObject.tag == "spear")
        {
            hp -= 3;
        }
        else if (other.gameObject.tag == "sword")
        {
            hp -= 2;
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
            StopCoroutine("PatternA");
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
