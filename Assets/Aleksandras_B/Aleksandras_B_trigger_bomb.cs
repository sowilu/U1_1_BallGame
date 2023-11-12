using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aleksandras_B_triggerBomb : MonoBehaviour
{
    public GameObject limiter;
    public GameObject background;
    public Sprite SandSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            limiter.SetActive(false);
            background.GetComponent<SpriteRenderer>().sprite = SandSprite;
        }

    }
}
