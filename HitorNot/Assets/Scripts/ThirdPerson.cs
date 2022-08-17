using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offset;
    public bool IsItEnd;
    public GameObject CameraWay;
    void Start()
    {
        target_offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (!IsItEnd)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + target_offset, .125f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, CameraWay.transform.position, .015f);
        }
    }
}
