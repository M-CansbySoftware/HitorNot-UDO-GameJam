using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashGround : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(deactive());
    }
    IEnumerator deactive()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }


}
