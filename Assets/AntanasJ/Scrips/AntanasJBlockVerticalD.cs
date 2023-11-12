using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVerticalD : MonoBehaviour
{
    public float frequency = 1;
    public float range = 3;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        transform.position = startPos + Vector3.down * Mathf.Sin(Time.time * frequency) * range;
    }
}
