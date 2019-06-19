using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    float localScale;

    public void AttackSpear()
    {
        StartCoroutine("Spear1");
    }
    public void AttackSB1()
    {
        StartCoroutine("SB1");
    }
    public void AttackSB2()
    {
        StartCoroutine("SB2");
    }
    public void AttackSB11()
    {
        StartCoroutine("SB11");
    }
    public void AttackSB22()
    {
        StartCoroutine("SB22");
    }
    public void Arrow(float localscale)
    {
        localScale = localscale;
        StartCoroutine("ArrowShot");
    }

    IEnumerator Spear1()
    {
        for(int i = 0; i < 10; i++)
        {
            transform.Translate(new Vector3(0, 0.1f, 0));
            yield return null;
        }
        StartCoroutine("Spear2");
    }
    IEnumerator Spear2()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.Translate(new Vector3(0, -0.1f, 0));
            yield return null;
        } 
    }
    IEnumerator SB1()
    {
        for(int i = 0; i < 10; i++)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 50 - i*15));
            yield return null;
        }
        
    }
    IEnumerator SB2()
    {
        for (int i = 10; i > 0; i--)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 50 - i*15 ));
            yield return null;
        }
    }
    IEnumerator SB11()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * 15 - 50));
            yield return null;
        }

    }
    IEnumerator SB22()
    {
        for (int i = 10; i > 0; i--)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * 15 - 50));
            yield return null;
        }
    }
    IEnumerator ArrowShot()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90 * localScale));
        for (int i = 0; i < 85; i++)
        {
            transform.Translate(new Vector3(0, 0.25f, 0));
            yield return null;
        }
        Destroy(gameObject);
    }
}
