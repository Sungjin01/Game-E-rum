using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject cloud1, cloud2, cloud3;
    public GameObject plane;
    GameObject p1, p2;
    bool planeB = true;
    

    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            Instantiate(cloud1);
            Instantiate(cloud2);
            Instantiate(cloud3);
        }
        p1 = Instantiate(plane);
        p1.transform.position = new Vector3(0, -4, 6);
        p2 = Instantiate(plane);
        p2.transform.position = new Vector3(38, -4, 6);
    }

    void Update()
    {
        p1.transform.Translate(new Vector3(-0.2f, 0, 0));
        p2.transform.Translate(new Vector3(-0.2f, 0, 0));

        if(p2.transform.position.x <= 0&&planeB)
        {
            p1.transform.position = new Vector3(38, -4, 6);
            planeB = false;
        }else if(p1.transform.position.x <= 0 && !planeB)
        {
            p2.transform.position = new Vector3(38, -4, 6);
            planeB = true;
        }
    }
}
