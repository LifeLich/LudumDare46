using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresureGate : Frezzeble, IInteractive
{
    [SerializeField] GameObject Presure;
    [SerializeField] GameObject Gate;

    [SerializeField] AudioClip soundSource;
    [SerializeField] bool defaultState = false;
    bool open = false;
    void IInteractive.Interact(GameObject interactor)
    {
        if (!frozen)
        {
            frozen = true;
            AudioSource.PlayClipAtPoint(soundSource, transform.position);
            open = !open;
            Gate.SetActive(!open);
            Presure.SetActive(false);
            Invoke("pause", 1f);
        }
    }
    private void pause()
    {
        frozen = false;
        Presure.SetActive(true);
    }

    public override void frezze()
    {
        frozen = true;
        open = defaultState;
        Gate.SetActive(!open);
        Presure.SetActive(true);
    }

    public override void unFrezze()
    {
        frozen = false;
        open = defaultState;
        Gate.SetActive(!open);
        Presure.SetActive(true);
    }
}
