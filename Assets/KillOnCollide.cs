using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnCollide : Frezzeble, IInteractive
{
    void IInteractive.Interact(GameObject interactor)
    {
        if (!frozen)
        {
            frozen = true;
            interactor.GetComponent<Character_Base>().Die(100, this);
        }
    }
}
