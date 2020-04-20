using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Item item;
    [SerializeField] TextMeshProUGUI amount;
    [SerializeField] Image face;
    [SerializeField] Image marker;
    [SerializeField] Image backgound;

    public void setup(Item item)
    {
        this.item = item;

        face.sprite = item.face;
        backgound.color = item.color;
        UpdateCount();
        marker.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    }

    public void UpdateCount()
    {
        amount.text = "" + item.amount;
    }

    public void Click()
    {
        marker.color = new Color(1,1,0,1);
        if (GameControllor.singelton.CurrentSelected != null)
        {
            GameControllor.singelton.CurrentSelected.marker.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
        if (item.amount > 0) {
            GameControllor.singelton.CurrentSelected = this;
            PlaceItemsController.singelton.CursorShadow.sprite = item.face;
        }
    }
}
