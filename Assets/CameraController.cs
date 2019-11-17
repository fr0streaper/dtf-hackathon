using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target) { 
        Vector3 pos = target.position + new Vector3(0, 0, -10);
        pos.y = 4;
        transform.position = pos;
        }
    }
}
