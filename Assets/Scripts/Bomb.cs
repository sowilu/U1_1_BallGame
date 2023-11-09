using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;

    SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            renderer.sprite = null;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Invoke(nameof(Restart), 1);
        }
    }

    void Restart()
    {
        LevelReloader.Reload();
    }
}
