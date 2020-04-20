using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItem : Frezzeble
{
    protected SpriteRenderer face;
    private void Start()
    {
        GameControllor.singelton.objects.Add(transform.position, this.gameObject);
        frozen = mainFrozen;
        face = GetComponent<SpriteRenderer>();
        SaveFrezze();
    }
}
