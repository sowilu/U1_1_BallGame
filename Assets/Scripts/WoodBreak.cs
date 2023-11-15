using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBreak : MonoBehaviour
{
    public List<Sprite> states;
    public float lifetime = 2;
    public AudioClip woodBreakClip;

    AudioSource audio;
    SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    
    IEnumerator Break()
    {
        foreach (var state in states)
        {
            yield return new WaitForSeconds(lifetime / states.Count);
            audio.PlayOneShot(woodBreakClip);
            renderer.sprite = state;
        }
        //renderer.color = Color.black;

        yield return new WaitForSeconds(lifetime / states.Count);
        audio.PlayOneShot(woodBreakClip);
        gameObject.AddComponent<Rigidbody2D>();
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Break());
        }
    }
}
