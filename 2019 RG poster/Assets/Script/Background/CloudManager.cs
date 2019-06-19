using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject cloud1, cloud2, cloud3;
    public GameObject camera;


    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(cloud1, camera.transform);
            Instantiate(cloud2, camera.transform);
            Instantiate(cloud3, camera.transform);
        }
    }

    void Update()
    {
    }
}
