﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborMovement : MonoBehaviour
{
    [SerializeField] private float StartSpeed = 3;
    [SerializeField] private Transform MinPosPoint;
    [SerializeField] private Transform MaxPosPoint;
    private Rigidbody2D rb;
    private float speed;
    private bool isStopped;

    public void Stop()
    {
        isStopped = true;
    }

    public void ResetAll()
    {
        speed = StartSpeed;
        isStopped = false;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isStopped = true;
    }

    private void FixedUpdate()
    {
        if (isStopped) return;

        var dir = new Vector2(transform.localScale.x, 0);
        var vel = dir * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + vel);

        if ((rb.position.x < MinPosPoint.position.x && dir.x < 0)
            || (rb.position.x > MaxPosPoint.position.x && dir.x > 0))
        {
            TurnBack();
        }
    }

    private void TurnBack()
    {
        var scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }
}
