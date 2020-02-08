using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : MonoBehaviour
{
    private const string ITEM_TAG = "Item";

    public NeighborMovement Movement { get; private set; }

    private bool isVulnerable;
    private Vector2 startPos;

    public void MakeInvulnerable()
    {
        isVulnerable = false;
    }

    public void ResetAll()
    {
        transform.position = startPos;
        Movement.ResetAll();
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
        Debug.Log("DIE");
        Movement.Stop();
        isVulnerable = false;
    }
}
