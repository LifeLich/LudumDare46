using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : SimpleItem, IInteractive
{
    [SerializeField] GameObject SpikeUp;
    void Start()
    {
        GameControllor.singelton.objects.Add(transform.position, this.gameObject);
        SaveFrezze();
        SpikeUp.SetActive(true);
    }

    public override void frezze()
    {
        frozen = true;
        SpikeUp.SetActive(true);
    }

    public override void unFrezze()
    {
        frozen = false;
        SpikeUp.SetActive(false);
    }

    void IInteractive.Interact(GameObject interactor)
    {
        if (!frozen)
        {
            frozen = true;
            SpikeUp.SetActive(true);
            interactor.GetComponent<Character_Base>().Die(100,this);
        }
    }
}
