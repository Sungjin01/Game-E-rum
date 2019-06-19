using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCloudMove : MonoBehaviour
{
    float randomX, randomY;   //x -15, 11 y 4 ~ -4
    public float randSpeed;

    void Start()
    {
        randomX = Random.Range(-15, 15);
        randomY = Random.Range(0, 10);
        randSpeed = Random.Range(0.2f, 1.5f);

        transform.position = new Vector3(randomX, randomY, 6);
    }

    void Update()
    {
        transform.Translate(new Vector3(randSpeed * Time.deltaTime, 0, 0));
        if (transform.position.x - GetComponentInParent<Transform>().position.x > 19)
        {
            randomY = Random.Range(0, 10);
            transform.position = new Vector3(GetComponentInParent<Transform>().position.x - 19, randomY, 6);
        }
    }
}
