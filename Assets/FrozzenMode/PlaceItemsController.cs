using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PlaceItemsController : Frezzeble
{
    public bool Place;
    public GameObject Cursor;
    public SpriteRenderer CursorShadow;
    
    [SerializeField] GameObject ButtonController;
    [SerializeField] GameObject ButtonPrefap;
    [SerializeField] GameObject ResetItemsButton;

    List<ButtonController> buttons = new List<ButtonController>();

    public static PlaceItemsController singelton;
    // Start is called before the first frame update
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
        Cursor.transform.position = new Vector3(0, 0, -20);
        SaveFrezze();
        SetupItems();
    }

    private void SetupItems()
    {
        List<Item> Items = GameControllor.singelton.Items;
        foreach (var item in Items)
        {
            if (item.prefap.name != "Grave" || MetaData.runnorType == MetaData.RunnorType.Respawn)
            {
                item.resetAmount();
                GameObject pre = Instantiate(ButtonPrefap, new Vector2(0, 0), Quaternion.identity, ButtonController.transform);
                ButtonController bc = pre.GetComponent<ButtonController>();
                bc.setup(item);
                buttons.Add(bc);
            }
        }
    }


    public Grid grid;
    // Update is called once per frame
    void Update()
    {
        bool frozenBool = frozen;
        if (MetaData.runnorType == MetaData.RunnorType.BuildAndRun)
        {
            if (frozen)
            {
                frozenBool = false;
            }
            else
            {
                frozenBool = true;
            }
        }
        ButtonController CurrentSelected = GameControllor.singelton.CurrentSelected;
        if (CurrentSelected != null && !IsMouseOverUI() && frozenBool)
        {
            if (CurrentSelected.item.prefap != null)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector3Int cellPosition = grid.WorldToCell(mousePosition);
                mousePosition = grid.GetCellCenterWorld(cellPosition);


                float radius = 0.1f;
                Tilemap[] tm = grid.GetComponentsInChildren<Tilemap>();

                if (tm[0].GetTile(cellPosition) == null && tm[1].GetTile(cellPosition) == null)
                {
                    Cursor.transform.position = mousePosition;
                    if (!GameControllor.singelton.objects.ContainsKey(mousePosition))
                    {
                        if (Input.GetMouseButtonDown(0) && CurrentSelected.item.amount > 0)
                        {
                            GameObject newObj = Instantiate(CurrentSelected.item.prefap, mousePosition, Quaternion.identity);
                            CurrentSelected.item.amount--;
                            CurrentSelected.UpdateCount();
                            GameControllor.singelton.plazed.Add(newObj);
                        }
                    }
                    else
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            GameObject gO = GameControllor.singelton.objects[mousePosition];
                            if (GameControllor.singelton.plazed.Contains(gO))
                            {
                                string itemName = gO.GetComponent<ItemBase>().itemName;
                                ButtonController bc2 = buttons.Find(x => itemName == x.item.prefap.GetComponent<ItemBase>().itemName);

                                bc2.item.amount++;
                                bc2.UpdateCount();

                                GameControllor.singelton.objects.Remove(mousePosition);
                                GameControllor.singelton.plazed.Add(gO);
                                Destroy(gO);
                            }
                            
                        }
                    }
                    
                }
            }
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }


    public void ResetItems()
    {
        GameControllor gc = GameControllor.singelton;

        int pI = 0 + gc.plazed.Count;
        for (int i = 0; i < pI; i++)
        {
            GameObject gobj = gc.plazed[0];
            gc.objects.Remove(gobj.transform.position);
            gc.plazed.Remove(gobj);
            Destroy(gobj.gameObject);
        }
        foreach (var item in GameControllor.singelton.Items)
        {
            item.resetAmount();
        }
        foreach (var b in buttons)
        {
            b.UpdateCount();
        }
    }

    public override void unFrezze()
    {
        frozen = false;

        if (MetaData.runnorType == MetaData.RunnorType.BuildAndRun)
        {
            ButtonController.SetActive(true);
            ResetItemsButton.SetActive(true);
        }
        else
        {
            Cursor.transform.position = new Vector3(0, 0, -20);
            ButtonController.SetActive(false);
            ResetItemsButton.SetActive(false);
        }
    }

    public override void frezze()
    {
        frozen = true;
        if (MetaData.runnorType == MetaData.RunnorType.BuildAndRun)
        {
            Cursor.transform.position = new Vector3(0, 0, -20);
            ButtonController.SetActive(false);
            ResetItemsButton.SetActive(false);
        }
        else
        {
            ButtonController.SetActive(true);
            ResetItemsButton.SetActive(true);
        }
    }
}
