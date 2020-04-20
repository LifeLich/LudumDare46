using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] Canvas CanvasMain;
    [SerializeField] Canvas CanvasCharectorSelect;
    [SerializeField] Canvas CanvasLevelSelect;
    [SerializeField] TextMeshProUGUI crystalsText;


    public static MenuController singelton;
    // Start is called before the first frame update
    private void Awake()
    {
        if (singelton != null)
        {
            Destroy(this.gameObject);
        }
        singelton = this;
    }

    void Start()
    {
        OpenMain();
        UpdateCrystalCount();
    }

    public void UpdateCrystalCount()
    {
        crystalsText.text = "" + MetaData.singelton.crystals;
    }

    public void OpenMain()
    {
        DeActiveAll();
        CanvasMain.gameObject.SetActive(true);
    }
    public void OpenCharectorSelect()
    {
        DeActiveAll();
        CanvasCharectorSelect.gameObject.SetActive(true);
    }
    public void OpenLevelSelect()
    {
        DeActiveAll();
        CanvasLevelSelect.gameObject.SetActive(true);
    }
    private void DeActiveAll()
    {
        CanvasMain.gameObject.SetActive(false);
        CanvasCharectorSelect.gameObject.SetActive(false);
        CanvasLevelSelect.gameObject.SetActive(false);
    }
    public void SetScreen(int screen)
    {
        MetaData.singelton.SetScreen(screen);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
