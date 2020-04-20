using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Frezzeble, IInteractive
{

    [SerializeField] AudioClip soundSource;

    void IInteractive.Interact(GameObject interactor)
    {
        if (!frozen)
        {
            AudioSource.PlayClipAtPoint(soundSource, transform.position);
            Invoke("LoadScreen", 0.03f);
        }
    }
    bool hit = true;
    private void LoadScreen()
    {
        if (hit)
        {
            hit = false;
            Time.timeScale = 1;
            MetaData.singelton.crystals += 0 + GameControllor.singelton.crystals;
            MetaData.singelton.SetScreen(0);
            MetaData.singelton.LoadScreen();
        }
        
    }
}
