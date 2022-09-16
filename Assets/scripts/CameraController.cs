using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;

    public void LookAtTarget()
    {
        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform);
        // make sure offset isn't perfectly straight so LookAt won't be weird
    }
}
