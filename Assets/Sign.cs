using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Frezzeble, IInteractive
{

    [SerializeField] SpriteRenderer face;
    BoxCollider2D bC2d;
    [SerializeField] AudioClip soundSource;
    private void Start()
    {
        GameControllor.singelton.objects.Add(transform.position, this.gameObject);
        bC2d = GetComponent<BoxCollider2D>();
        frozen = mainFrozen;
        SaveFrezze();
    }

    void IInteractive.Interact(GameObject interactor)
    {
        if (!frozen)
        {
            AudioSource.PlayClipAtPoint(soundSource, transform.position);
            Character_Base cb = interactor.GetComponent<Character_Base>();
            if (cb != null)
            {
                cb.FlipChar(false);
            }
            face.enabled = false;
            bC2d.enabled = false;
        }
    }

    public override void frezze()
    {
        frozen = true;
        face.enabled = true;
        bC2d.enabled = true;
    }

    public override void unFrezze()
    {
        frozen = false;
        face.enabled = true;
        bC2d.enabled = true;
    }
}
