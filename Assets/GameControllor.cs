using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControllor : MonoBehaviour
{
    //obejct
    public Dictionary<Vector2, GameObject> objects = new Dictionary<Vector2, GameObject>();
    public List<GameObject> plazed = new List<GameObject>();
    public List<Frezzeble> frezzeble = new List<Frezzeble>();

    //Items
    public ButtonController CurrentSelected;
    public List<Item> Items = new List<Item>();

    //Other
    public Runner runner;
    public static GameControllor singelton;
    [SerializeField] TextMeshProUGUI RunnonButton;
    public int crystals;
    [SerializeField] TextMeshProUGUI crystalsText;

    public void UpdateCrystalCount()
    {
        if (crystalsText != null)
        {

            crystalsText.text = "" + crystals;
        }
    }

    private void Awake()
    {
        if (singelton != null)
        {
            Destroy(this.gameObject);
        }
        singelton = this;
    }

    private void Start()
    {
        crystals = 0;
        UpdateCrystalCount();
        Frezzeble.mainFrozen = true;
        StopRunning();
    }

    // Start is called before the first frame update
    public void StartRunning()
    {
        if (MetaData.runnorType == MetaData.RunnorType.Respawn)
        {
            runner.ResetRespawnPoint();
        }
        CurrentSelected = null;
        if (Frezzeble.mainFrozen)
        {
            UpdateCrystalCount();
            foreach (var nS in frezzeble)
            {
                if (nS != null)
                {
                    nS.unFrezze();
                }
                
            }
            Frezzeble.mainFrozen = false;
            RunnonButton.text = "Return To Place Items";
        }
        else
        {
            StopRunning();
        }
        
    }
    public void StopRunning()
    {
        if (RunnonButton != null)
        {
            RunnonButton.text = "Start Running";
        }
        
        CurrentSelected = null;
        foreach (var nS in frezzeble)
        {
            if (nS != null)
            {
            nS.frezze();
            }
        }
        Frezzeble.mainFrozen = true;
        crystals = 0;
    }

    public void ReturnToMenu()
    {
        MetaData.singelton.LoadScreen(0);
    }
}
