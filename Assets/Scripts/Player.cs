using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;

    [Header("Normal")]
    public Sprite normalSprite;
    public float normalMass = 2;

    [Header("Heavy")]
    public Sprite heavySprite;
    public float heavyMass = 15;

    [Header("Light")]
    public Sprite lightSprite;
    public float lightMass = 0.5f;

    [HideInInspector]
    public float x;

    Rigidbody2D rb;
    SpriteRenderer renderer;
    bool isGrounded;

    public GameObject end;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        ChangeState();
        CheckOutOfBounds();
    }

    private void CheckOutOfBounds()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0)
        {
            LevelReloader.Reload();
        }
    }

    void ChangeState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            renderer.sprite = lightSprite;
            rb.mass = lightMass;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            renderer.sprite = normalSprite;
            rb.mass = normalMass;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            renderer.sprite = heavySprite;
            rb.mass = heavyMass;
        }
    }

    void Move()
    {
        x = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        if (collision.gameObject.CompareTag("Diamond"))
        {
            StarCounter.Instance.Stars++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Flag"))
        {
            end.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
