using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPlatform : MonoBehaviour
{
    public List<Sprite> states;
    public float lifetime = 3;
    public AudioClip breakClip;

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
            audio.PlayOneShot(breakClip);
            renderer.sprite = state;
        }
        renderer.color = Color.red;

        yield return new WaitForSeconds(lifetime / states.Count);
        audio.PlayOneShot(breakClip);
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
