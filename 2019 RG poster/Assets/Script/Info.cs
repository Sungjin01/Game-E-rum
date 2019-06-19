using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public GameObject info;

    public void QuestionMark()
    {
        info.transform.position = new Vector3(960, 540, 0);
    }

    public void Back()
    {
        info.transform.position = new Vector3(-2100, 0, 0);
    }
}
