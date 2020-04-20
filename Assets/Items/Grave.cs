using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : Frezzeble, IInteractive
{
    [SerializeField] SpriteRenderer face;
    [SerializeField] Sprite[] states;
    [SerializeField] AudioClip soundSource;
    private void Start()
    {
        GameControllor.singelton.objects.Add(transform.position, this.gameObject);
        frozen = mainFrozen;
        SaveFrezze();
        Invoke("springFace0", 0.05f);
    }

    void IInteractive.Interact(GameObject interactor)
    {
        if (!frozen)
        {
            if (MetaData.runnorType == MetaData.RunnorType.Respawn)
            {
                Runner cb = interactor.GetComponent<Runner>();
                if (cb != null)
                {
                    if (cb.respawnPoint != (Vector2)this.transform.position)
                    {
                        AudioSource.PlayClipAtPoint(soundSource, transform.position);
                        cb.respawnPoint = this.transform.position;
                    }
                }
                
            }
        }
    }
    bool upGo = true;
    int nState = 0;
    private void springFace0()
    {
        if (upGo)
        {
            nState++;
            if (nState == states.Length-1)
            {
                upGo = false;
            }
        }
        else
        {
            nState--;
            if (nState == 0)
            {
                upGo = true;
            }
        }
        face.sprite = states[nState];
        float time = Random.Range(0.4f , 0.8f);
        Invoke("springFace0", time);
    }
    
}
