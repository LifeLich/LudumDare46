using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiControllor : Frezzeble
{
    [SerializeField] TextMeshProUGUI SpeedUpText;

    int speed = 1;
    public void SpeedUp()
    {
        if (speed >= 4)
        {
            speed = 1;
        }
        else
        {
            speed++;
        }
        SetTimeText(speed);
        if (!frozen)
        {
            Time.timeScale = speed;
        }
    }

    private void SetTimeText(int i)
    {
        SpeedUpText.text = "SpeedUp \n" + i;
    }

    public override void frezze()
    {
        frozen = true;
        Time.timeScale = 1;
        SetTimeText(1);
    }

    public override void unFrezze()
    {
        frozen = false;
        Time.timeScale = speed;
        SetTimeText(speed);
    }
}
