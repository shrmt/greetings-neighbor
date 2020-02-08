using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    private const string GROUND_TAG = "Ground";

    public event Action OnGroundCollided;

    private Rigidbody2D rb;

    public void Push(float power)
    {
        var dir = Vector2.left;
        var force = dir.normalized * power;
        rb.gravityScale = 1;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(GROUND_TAG))
        {
            OnGroundCollided();
        }
    }
}
