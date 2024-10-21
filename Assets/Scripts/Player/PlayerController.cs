using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    private Vector2 _startPosition = new Vector2(0f, -2f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = _startPosition;    
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}

