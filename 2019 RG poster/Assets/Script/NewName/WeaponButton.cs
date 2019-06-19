using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public MakeFile Make;

    public int WeaponNum;

    public Image MyColor;

    Color color;

    public void ClickButton()
    {
        Make.WeaponNum = WeaponNum;
    }

    void Update()
    {
        color = MyColor.color;

        if (Make.WeaponNum != WeaponNum)
        {
            color.a = 0.5f;
        }
        else {
            color.a = 1;
        }

        MyColor.color = color;
    }
}
