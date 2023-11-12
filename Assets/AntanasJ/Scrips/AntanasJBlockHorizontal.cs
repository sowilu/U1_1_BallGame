using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHorizontal : MonoBehaviour
{
    public float frequency = 1;
    public float range = 6;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        transform.position = startPos + Vector3.right * Mathf.Sin(Time.time * frequency) * range;
    }
}
