using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Base : Frezzeble
{
    [SerializeField]
    protected SpriteRenderer sR;
    [SerializeField]
    protected AudioClip deathSound;

    public bool MoveRight = true;
    public Vector2 startPoint;

    protected Rigidbody2D rb2d;
    public bool Alive = true;

    private void Awake()
    {
        startPoint = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        SaveFrezze();
        rb2d = GetComponent<Rigidbody2D>();
        GameControllor.singelton.objects.Add(transform.position, this.gameObject);
        Alive = true;
        SetFace();
    }

    public virtual void SetFace()
    {
        
    }

    protected int hp = 3;
    protected Frezzeble killer;
    public virtual void Die(int dam, Frezzeble killer)
    {
        hp -= dam;
        if (hp <= 0)
        {
            this.killer = killer;
            hp = 0;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Alive = false;
            rb2d.velocity = new Vector2(0, 0);
            this.gameObject.SetActive(false);
            Invoke("AfterDeath", 0.5f);
        }
    }
    public virtual void AfterDeath()
    {
        if (MetaData.runnorType != MetaData.RunnorType.Respawn)
        {
            Revive();
        }
    }

    public override void unFrezze()
    {
        frozen = false;
        Revive();
    }
    public override void frezze()
    {
        frozen = true;
        Revive();
    }
    public virtual void Revive()
    {
        this.gameObject.SetActive(true);
        Alive = true;
    }
    public delegate void ActionHandler();
    public event ActionHandler Flip;

    public void FlipChar(bool lookRight)
    {
        MoveRight = lookRight ? true : !MoveRight;
        sR.flipX = !MoveRight;
        if (Flip != null)
        {
            Flip.Invoke();
        }
    }
}
