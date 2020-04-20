using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnorMove : Frezzeble
{
    private Rigidbody2D rb2d;
    private BoxCollider2D bC2d;
    private Character_Base cB;

    //Movement
    float speed = 4;
    float moveVelocity;
    [SerializeField] LayerMask layerMask;

    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bC2d = GetComponent<BoxCollider2D>();
        cB = GetComponent<Character_Base>();
        SaveFrezze();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!frozen && cB.Alive)
        {
            Move();
        }
    }

    private void Move()
    {
        RaycastHit2D ray = Physics2D.BoxCast(bC2d.bounds.center, bC2d.bounds.size * new Vector2(1, 0.9f), 0f, transform.right * (cB.MoveRight ? 1 : -1), 0.05f, layerMask);

        Color color = Color.green;
        if (ray.collider != null)
        {
            color = Color.red;
            cB.FlipChar(false);
        }

        Debug.DrawRay(bC2d.bounds.center, transform.right * (cB.MoveRight ? 1 : -1) * (bC2d.bounds.extents.x + 0.02f), color);

        moveVelocity = cB.MoveRight ? speed : -speed;
        velocity = rb2d.velocity;

        //this is here to prevent a bug where the runnor just frezzes at a location
        if (!frozen && velocity.x == 0 && velocity.y == 0)
        {
            transform.position += (transform.up -transform.forward)/100;
        }
        rb2d.velocity = new Vector2(moveVelocity, velocity.y);
    }

    public override void frezze()
    {
        cB.MoveRight = true;
        cB.FlipChar(true);
        rb2d.velocity = new Vector2(0, 0);
        transform.position = cB.startPoint;
        frozen = true;
    }
}
