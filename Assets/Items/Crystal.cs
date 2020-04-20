using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Frezzeble, IInteractive
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
            GameControllor.singelton.crystals += 1;
            GameControllor.singelton.UpdateCrystalCount();
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
