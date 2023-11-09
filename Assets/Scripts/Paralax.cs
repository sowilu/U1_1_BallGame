using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float speed = 0.1f;
    public Player player;

    Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }


    void Update()
    {
        material.mainTextureOffset += Vector2.left * speed * Time.deltaTime * player.x;
    }
}
