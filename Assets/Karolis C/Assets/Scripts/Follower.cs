using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }


    void Update()
    {
        var targetPos = target.position + offset;
        targetPos.y = transform.position.y;
        targetPos.z = transform.position.z;

        transform.position = targetPos;
    }
}
