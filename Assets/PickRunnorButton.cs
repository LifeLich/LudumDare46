using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickRunnorButton : MonoBehaviour
{
    [SerializeField] int num;
    bool locked = true;
    [SerializeField] int Cost;

    [SerializeField] GameObject Lock;
    [SerializeField] TextMeshProUGUI LockCost;
    private void Start()
    {
        LockCost.text = ""+Cost;
        if (Cost == 0)
        {
            MetaData.singelton.unlockeds[num] = true;
        }
        bool status = MetaData.singelton.unlockeds[num];
        locked = !status;
        Lock.SetActive(!status);
    }

    public void Clicked()
    {
        MetaData md = MetaData.singelton;
        if (locked)
        {
            if (md.crystals >= Cost)
            {
                md.crystals -= Cost;
                MenuController.singelton.UpdateCrystalCount();
                md.unlockeds[num] = true;
                locked = false;
                Lock.SetActive(false);
            }
        }
        else
        {
            md.SetRunnor(num);
            md.LoadScreen();
        }
    }
}
