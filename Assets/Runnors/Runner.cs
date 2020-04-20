using System;
using System.Collections.Generic;
using UnityEngine;


public class Runner : Character_Base
{
    [SerializeField] Sprite normalFace;
    [SerializeField] Sprite doubleBuildFace;
    [SerializeField] Sprite buildAndRunFace;
    [SerializeField] Sprite respanFace;

    void Start()
    {
        startPoint = transform.position;
        ResetRespawnPoint();
        rb2d = GetComponent<Rigidbody2D>();
        GameControllor.singelton.objects.Add(transform.position, this.gameObject);
        GameControllor.singelton.runner = this;
        Alive = true;
        SetFace();
    }

    public Vector2 respawnPoint;
    public void ResetRespawnPoint()
    {
        respawnPoint = startPoint;
    }

    public override void SetFace()
    {
        Sprite sprite = normalFace;
        switch (MetaData.runnorType)
        {
            case MetaData.RunnorType.normal:
                sprite = normalFace;
                break;
            case MetaData.RunnorType.DoubleBuild:
                sprite = doubleBuildFace;
                break;
            case MetaData.RunnorType.BuildAndRun:
                sprite = buildAndRunFace;
                break;
            case MetaData.RunnorType.Respawn:
                sprite = respanFace;
                break;
            default:
                break;
        }
        sR.sprite = sprite;
    }

    public override void Die(int dam, Frezzeble killer)
    {
        hp -= dam;
        if (hp <= 0)
        {
            this.killer = killer;
            killer.frezze();
            hp = 0;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Alive = false;
            rb2d.velocity = new Vector2(0, 0);
            Invoke("AfterDeath", 0.5f);
        }
    }
    public override void AfterDeath()
    {
        if (MetaData.runnorType == MetaData.RunnorType.Respawn)
        {
            killer.unFrezze();
            hp = 3;
            MoveRight = true;
            FlipChar(true);
            rb2d.velocity = new Vector2(0, 0);
            transform.position = respawnPoint;
            Alive = true;
        }
        else
        {
            GameControllor.singelton.StopRunning();
            Alive = true;
        }
    }
}

