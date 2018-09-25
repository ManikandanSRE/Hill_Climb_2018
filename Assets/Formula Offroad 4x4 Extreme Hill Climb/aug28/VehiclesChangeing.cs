using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehiclesChangeing : MonoBehaviour {


    public RawImage SelectionPad;
    public List<Sprite> ItemList = new List<Sprite>();
    public static int itemspot = 0;

    public Button BuyButton;

    public void LeftSelectionButton()
    {
        if (itemspot > 0)
        {
            itemspot--;
            SelectionPad.texture = ItemList[itemspot].texture;

            if (PlayerPrefs.GetInt(ItemList[itemspot].name) == 0)
            {
                BuyButton.interactable = true;
            }
            else
            {
                BuyButton.interactable = false;
            }
        }
    }
    public void RightSelectionButton()
    {
        if (itemspot < ItemList.Count - 1)
        {
            itemspot++;
            SelectionPad.texture = ItemList[itemspot].texture;
        }
    }


    

}
