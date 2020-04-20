using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : SimpleItem, IInteractive
{
    [SerializeField] Sprite[] states;
    [SerializeField] AudioClip soundSource;
    int force = 15;

    int uses = 2;

    public override void frezze()
    {
        uses = 2;
        frozen = true;
    }

    void IInteractive.Interact(GameObject interactor)
    {
        if (!frozen)
        {
            if (uses > 0)
            {


        AudioSource.PlayClipAtPoint(soundSource, transform.position);
        
        Rigidbody2D rb2d = interactor.GetComponent<Rigidbody2D>();

        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

        rb2d.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        Invoke("springFace1", 0.03f);
            }
        }
    }

    private void springFace1()
    {
        face.sprite = states[1];
        Invoke("springFace2", 0.05f);
    }
    private void springFace2()
    {
        face.sprite = states[2];
        Invoke("springFace0", 0.5f);
    }
    private void springFace0()
    {
        face.sprite = states[0];
    }
}
