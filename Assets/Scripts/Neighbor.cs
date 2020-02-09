using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : MonoBehaviour
{
    private const string ITEM_TAG = "Item";

    public NeighborMovement Movement { get; private set; }
    public event Action OnDeath;

    private bool isVulnerable;
    private Vector2 startPos;

    public void MakeInvulnerable()
    {
        isVulnerable = false;
    }

    public void Init()
    {
        transform.position = startPos;
        Movement.Init();
        isVulnerable = true;
    }

    private void Awake()
    {
        Movement = GetComponent<NeighborMovement>();
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(ITEM_TAG) && isVulnerable)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath();
        Movement.Stop();
        isVulnerable = false;
    }
}
