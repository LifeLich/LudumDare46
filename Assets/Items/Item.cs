using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public int MaxAmount = 3;
    public int amount = 3;
    public GameObject prefap;
    public Sprite face;
    public Color color = new Color(1,1,1,1);

    internal void resetAmount()
    {
        if (MetaData.runnorType == MetaData.RunnorType.DoubleBuild)
        {
            amount = MaxAmount*2;
        }
        else
        {
            amount = MaxAmount;
        }
    }
}

