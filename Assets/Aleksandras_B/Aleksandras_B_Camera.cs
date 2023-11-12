using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aleksandras_B_Camera : MonoBehaviour
{
    public GameObject mainCamera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) mainCamera.transform.position = new Vector3(37.2900009f, 2.11999989f, -10.1446991f);
    }
}
