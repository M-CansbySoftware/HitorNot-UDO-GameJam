using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AltKarakterler"))
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(-2,0,0), ForceMode.Impulse);        }
    }
}
