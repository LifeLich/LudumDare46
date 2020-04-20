using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Frezzeble, IInteractive
{
    Rigidbody2D rb2d;
    [SerializeField] SpriteRenderer[] arms;
    [SerializeField] GameObject armsHolder;
    [SerializeField] Sprite[] armsSprites;
    [SerializeField] Character_Base cB;

    public void Flip()
    {
        if (!cB.MoveRight)
        {
            armsHolder.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            armsHolder.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Start()
    {
        SaveFrezze();
        rb2d = GetComponent<Rigidbody2D>();
        cB = GetComponent<Character_Base>();
        
        cB.Flip += Flip;
        Invoke("moveArms", 0.05f);
    }

    void IInteractive.Interact(GameObject interactor)
    {
        if (!frozen)
        {
            frozen = true;
            interactor.GetComponent<Character_Base>().Die(100, this);
            cB.Die(100, this);
        }
    }

    private void moveArms()
    {
        foreach (var arm in arms)
        {
            int i = Random.Range(-3, armsSprites.Length);
            if (i >= 0)
            {
                arm.sprite = armsSprites[i];
            }
            
        }
        float time = Random.Range(0.4f, 0.8f);
        Invoke("moveArms", time);
    }
}
