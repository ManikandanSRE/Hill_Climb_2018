using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopForGoldCoin : MonoBehaviour
{
    public Image simage;
    public Image ChangepanaelImage;

    [Header("ModeSelectionPanel")]

    public Image ModeSelectionPanelVehicleImage;
    public Image ModeSelectionPanelMapImage;

    [Header("ColourPanel")]
    public Button ChangeButton;
    public Button ChangePanelLeftButton;
    public Button ChangePanelRightButton;
    public RawImage ChangePanelRawImage;
    public Button changePanelSelectButton;
    private int changePanelCarCount;

    [Header("Main Panel")]
    public InputField TypeGoldAmount;
    public Text GoldGodownValueText;

    public static int GoldCoinAmount;
    int RawimageOfCar;
    int RawimageOfMap;
    public Button SelectingCarButtonOnRawImage;

    public Text RawimageOfCarAmountText;
    public Text RawimageOfMapsAmountText;

    public Button BuyButton;
    public Button SelectButtonCar;

    public Button BuyButtonForMaps;
    public Button SelectButtonMaps;

    public int LastselectedCarNumber;

    //public List<GameObject> CarPrefabs = new List<GameObject>();
    public RawImage SelectionPad;                                    //CarList
    public List<Sprite> ItemList = new List<Sprite>();
    public static int itemspot = 0;

    public RawImage SelectionPadMaps;                                  //MapsList
    public List<Sprite> MapsItemList = new List<Sprite>();
    private int Mapsitemspot = 0;


    List<int> tagNames = new List<int>();

    //public List<Map>  = new List<Map>();

    // Use this for initialization
    void Start()
    {
        ModeSelectionPanelVehicleImage.sprite = ItemList[PlayerPrefs.GetInt("selectedCar")];
        ModeSelectionPanelMapImage.sprite = MapsItemList[PlayerPrefs.GetInt("selectedMap")];
        ModeSelectionPanelVehicleImage.preserveAspect = true;
        ModeSelectionPanelMapImage.preserveAspect = true;

        simage.preserveAspect = true;
        ChangepanaelImage.preserveAspect = true;

        itemspot = 0;
        Mapsitemspot = 0;
        GoldCoinAmount = PlayerPrefs.GetInt("Goldcoin_Godown");
        GoldGodownValueText.text = "Gold Coin : " + GoldCoinAmount;

        SelectionPad.texture = ItemList[itemspot].texture;
        simage.sprite = ItemList[itemspot];
        SelectionPadMaps.texture = MapsItemList[Mapsitemspot].texture;

        BuyButton.gameObject.SetActive(false);
        if (itemspot == PlayerPrefs.GetInt("selectedCar"))
        {
            SelectButtonCar.gameObject.SetActive(false);
        }
        else
        {
            SelectButtonCar.gameObject.SetActive(true);
        }
        RawimageOfCarAmountText.text = "";


        BuyButtonForMaps.gameObject.SetActive(false);
        if (Mapsitemspot == PlayerPrefs.GetInt("selectedMap"))
        {
            SelectButtonMaps.gameObject.SetActive(false);
        }
        else
        {
            SelectButtonMaps.gameObject.SetActive(true);
        }
        RawimageOfMapsAmountText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        CarInShop();
        MapInShop();

    }

    public void CarInShop()
    {
        PlayerPrefs.SetInt("CarShop", 0);
        RawimageOfCar = PlayerPrefs.GetInt("CarShop");

        if (PlayerPrefs.GetInt("Goldcoin_Godown") >= 5 && RawimageOfCar == 0)
        {

            BuyButton.interactable = true;
        }
        else
        {
            BuyButton.interactable = false;
        }

    }

    public void MapInShop()
    {

        PlayerPrefs.SetInt("MapShop", 0);
        RawimageOfCar = PlayerPrefs.GetInt("MapShop");

        if (PlayerPrefs.GetInt("Goldcoin_Godown") >= 3 && RawimageOfMap == 0)
        {
            BuyButtonForMaps.interactable = true;
        }
        else
        {
            BuyButtonForMaps.interactable = false;
        }
    }

    public void BuyCar()
    {
        GoldCoinAmount -= 5;
        RawimageOfCarAmountText.text = " ";
        BuyButton.gameObject.SetActive(false);

        tagNames.Clear();
        for (int i = itemspot; i < itemspot + 10; i++)
        {
            if (!ItemList[i].texture.name.Contains("empty"))
            {
                tagNames.Add(i);
            }
        }


        Debug.Log("tagCount " + tagNames.Count);
        if (tagNames.Count > 1)
        {
            ChangeButton.gameObject.SetActive(true);
            SelectButtonCar.gameObject.SetActive(false);
        }

        else
        {
            SelectButtonCar.gameObject.SetActive(true);
            ChangeButton.gameObject.SetActive(false);
        }

        GoldGodownValueText.text = "Gold Coin : " + GoldCoinAmount;
        PlayerPrefs.SetInt(ItemList[itemspot].texture.name, 1);
        PlayerPrefs.SetInt("Goldcoin_Godown", GoldCoinAmount);
    }

    public void BuyMaps()
    {
        GoldCoinAmount -= 3;
        RawimageOfMapsAmountText.text = " ";
        BuyButtonForMaps.gameObject.SetActive(false);
        SelectButtonMaps.gameObject.SetActive(true);
        GoldGodownValueText.text = "Gold Coin : " + GoldCoinAmount;
        PlayerPrefs.SetInt(MapsItemList[Mapsitemspot].texture.name, 1);
        PlayerPrefs.SetInt("Goldcoin_Godown", GoldCoinAmount);
    }

    public void LeftSelectionButton()
    {
        if (itemspot > 0)
        {
            itemspot = itemspot - 10;
            SelectionPad.texture = ItemList[itemspot].texture;
            simage.sprite = ItemList[itemspot];
            if (PlayerPrefs.GetInt(ItemList[itemspot].texture.name) == 0)
            {
                BuyButton.gameObject.SetActive(true);
                SelectButtonCar.gameObject.SetActive(false);
                SelectingCarButtonOnRawImage.interactable = false;
                RawimageOfCarAmountText.text = "5$";
            }
            else
            {
                BuyButton.gameObject.SetActive(false);

                tagNames.Clear();
                for (int i = itemspot; i < itemspot + 10; i++)
                {
                    if (!ItemList[i].texture.name.Contains("empty"))
                    {
                        tagNames.Add(i);
                    }
                }
                Debug.Log("tagCount " + tagNames.Count);
                if (tagNames.Count > 1)
                {
                    //Change Skin button show
                    ChangeButton.gameObject.SetActive(true);
                    SelectButtonCar.gameObject.SetActive(false);
                    ChangePanelRawImage.texture = ItemList[itemspot].texture;
                    ChangepanaelImage.sprite = ItemList[itemspot];
                    changePanelCarCount = 0;
                    if (itemspot == PlayerPrefs.GetInt("selectedCar"))
                    {
                        changePanelSelectButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        changePanelSelectButton.gameObject.SetActive(true);
                    }
                }
                else if (itemspot == PlayerPrefs.GetInt("selectedCar"))
                {
                    ChangeButton.gameObject.SetActive(false);
                    SelectButtonCar.gameObject.SetActive(false);
                }
                else
                {
                    ChangeButton.gameObject.SetActive(false);
                    SelectButtonCar.gameObject.SetActive(true);
                }
                RawimageOfCarAmountText.text = " ";
            }

        }
    }
    public void RightSelectionButton()
    {
        if (itemspot < ItemList.Count - 10)
        {
            itemspot = itemspot + 10;
            SelectionPad.texture = ItemList[itemspot].texture;
            simage.sprite = ItemList[itemspot];
            if (PlayerPrefs.GetInt(ItemList[itemspot].texture.name) == 0)
            {
                BuyButton.gameObject.SetActive(true);
                SelectButtonCar.gameObject.SetActive(false);
                RawimageOfCarAmountText.text = "5$";
                ChangeButton.gameObject.SetActive(false);
            }
            else
            {
                BuyButton.gameObject.SetActive(false);
                tagNames.Clear();
                for (int i = itemspot; i < itemspot + 10; i++)
                {
                    if (!ItemList[i].texture.name.Contains("empty"))
                    {
                        tagNames.Add(i);
                    }
                }


                Debug.Log("tagCount " + tagNames.Count);
                if (tagNames.Count > 1)
                {
                    //Change Skin button show
                    ChangeButton.gameObject.SetActive(true);
                    SelectButtonCar.gameObject.SetActive(false);
                    ChangePanelRawImage.texture = ItemList[itemspot].texture;
                    ChangepanaelImage.sprite = ItemList[itemspot];
                    changePanelCarCount = 0;
                    if (itemspot == PlayerPrefs.GetInt("selectedCar"))
                    {
                        changePanelSelectButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        changePanelSelectButton.gameObject.SetActive(true);
                    }
                }
                else if (itemspot == PlayerPrefs.GetInt("selectedCar"))
                {
                    ChangeButton.gameObject.SetActive(false);
                    SelectButtonCar.gameObject.SetActive(false);
                }
                else
                {
                    ChangeButton.gameObject.SetActive(false);
                    SelectButtonCar.gameObject.SetActive(true);
                }
                SelectingCarButtonOnRawImage.interactable = true;
                RawimageOfCarAmountText.text = "";
            }
        }
    }
    public void LeftSelectionButtonForMap()
    {
        if (Mapsitemspot > 0)
        {
            Mapsitemspot--;
            SelectionPadMaps.texture = MapsItemList[Mapsitemspot].texture;
            if (PlayerPrefs.GetInt(MapsItemList[Mapsitemspot].texture.name) == 0)
            {
                BuyButtonForMaps.gameObject.SetActive(true);
                SelectButtonMaps.gameObject.SetActive(false);
                RawimageOfMapsAmountText.text = "3$";
            }
            else
            {
                BuyButtonForMaps.gameObject.SetActive(false);
                if (Mapsitemspot == PlayerPrefs.GetInt("selectedMap"))
                {
                    SelectButtonMaps.gameObject.SetActive(false);
                }
                else
                {
                    SelectButtonMaps.gameObject.SetActive(true);
                }
                RawimageOfMapsAmountText.text = " ";
            }
        }
    }
    public void RightSelectionButtonForMap()
    {

        Debug.Log(Mapsitemspot);
        if (Mapsitemspot < MapsItemList.Count - 1)
        {
            Mapsitemspot++;
            SelectionPadMaps.texture = MapsItemList[Mapsitemspot].texture;
            Debug.Log(PlayerPrefs.GetInt(MapsItemList[Mapsitemspot].texture.name));
            if (PlayerPrefs.GetInt(MapsItemList[Mapsitemspot].texture.name) == 0)
            {
                BuyButtonForMaps.gameObject.SetActive(true);
                SelectButtonMaps.gameObject.SetActive(false);
            }
            else
            {
                BuyButtonForMaps.gameObject.SetActive(false);
                if (Mapsitemspot == PlayerPrefs.GetInt("selectedMap"))
                {
                    SelectButtonMaps.gameObject.SetActive(false);
                }
                else
                {
                    SelectButtonMaps.gameObject.SetActive(true);
                }
            }

        }
    }


    public void SelectCar()
    {
        if (PlayerPrefs.GetInt(ItemList[itemspot].texture.name) == 1)
        {
            PlayerPrefs.SetInt("selectedCar", itemspot);
            ModeSelectionPanelVehicleImage.sprite = ItemList[PlayerPrefs.GetInt("selectedCar")];
            SelectButtonCar.gameObject.SetActive(false);
        }
    }

    public void SelectMap()
    {
        Debug.Log(MapsItemList[Mapsitemspot].texture.name);
        Debug.Log(PlayerPrefs.GetInt(MapsItemList[Mapsitemspot].texture.name));
        if (PlayerPrefs.GetInt(MapsItemList[Mapsitemspot].texture.name) == 1)
        {
            PlayerPrefs.SetInt("selectedMap", Mapsitemspot);
            
            ModeSelectionPanelMapImage.sprite = MapsItemList[PlayerPrefs.GetInt("selectedMap")];
            SelectButtonMaps.gameObject.SetActive(false);           
        }
        PlayerPrefs.Save();
    }

    public void GoldPurchase()
    {
        PlayerPrefs.SetInt("Goldcoin_Godown", PlayerPrefs.GetInt("Goldcoin_Godown") + Convert.ToInt32(TypeGoldAmount.text));
        Start();
    }

    public void changePanelLeftButtonClick()
    {
        if (changePanelCarCount >= 1)
        {
            changePanelCarCount--;
            ChangePanelRawImage.texture = ItemList[tagNames[changePanelCarCount]].texture;
            ChangepanaelImage.sprite = ItemList[tagNames[changePanelCarCount]];
            if (tagNames[changePanelCarCount] == PlayerPrefs.GetInt("selectedCar"))
            {
                changePanelSelectButton.gameObject.SetActive(false);
            }
            else
            {
                changePanelSelectButton.gameObject.SetActive(true);
            }
        }
    }

    public void changePanelRightButtonClick()
    {
        if (changePanelCarCount < tagNames.Count - 1)
        {
            changePanelCarCount++;
            ChangePanelRawImage.texture = ItemList[tagNames[changePanelCarCount]].texture;
            ChangepanaelImage.sprite = ItemList[tagNames[changePanelCarCount]];
            if (tagNames[changePanelCarCount] == PlayerPrefs.GetInt("selectedCar"))
            {
                changePanelSelectButton.gameObject.SetActive(false);
            }
            else
            {
                changePanelSelectButton.gameObject.SetActive(true);
            }
        }
    }

    public void ColourChangePanelOpener()
    {
        changePanelCarCount = 0;
        ChangePanelRawImage.texture = ItemList[tagNames[changePanelCarCount]].texture;
        ChangepanaelImage.sprite = ItemList[tagNames[changePanelCarCount]];
    }


    public void SelectionButtonOnColourChangePanel()
    {
        PlayerPrefs.SetInt("selectedCar", tagNames[changePanelCarCount]);
        ModeSelectionPanelVehicleImage.sprite = ItemList[PlayerPrefs.GetInt("selectedCar")];

        changePanelSelectButton.gameObject.SetActive(false);
    }
}
