using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDestroyed : MonoBehaviour
{
    public RectTransform EasyPanel;
    public RectTransform NormalPanel;
    public RectTransform hardPanel;
    public RectTransform ExtremePanel;
    // Use this for initialization
    void Start()
    {
        EasyPanel.GetComponent<Button>().onClick.AddListener(Easydes);
        NormalPanel.GetComponent<Button>().onClick.AddListener(NormalDes);
        hardPanel.GetComponent<Button>().onClick.AddListener(HardDes);
        ExtremePanel.GetComponent<Button>().onClick.AddListener(ExtremeDes);


        
        
    }

    public void clickToStartForPanel()
    {


        Debug.Log("testing playerpref" + PlayerPrefs.HasKey("EasyPanel_" + PlayerPrefs.GetInt("selectedMap")));
        Debug.Log("testing playerpref" + PlayerPrefs.HasKey("NormalPanel_" + PlayerPrefs.GetInt("selectedMap")));
        Debug.Log("testing playerpref" + PlayerPrefs.HasKey("HardPanel_" + PlayerPrefs.GetInt("selectedMap")));
        Debug.Log("testing playerpref" + PlayerPrefs.HasKey("ExtremePanel_" + PlayerPrefs.GetInt("selectedMap")));

        if (PlayerPrefs.HasKey("EasyPanel_" + PlayerPrefs.GetInt("selectedMap")))
        {
            EasyPanel.gameObject.SetActive(false);
        }
        else
        {
            EasyPanel.gameObject.SetActive(true);
        }
        if (PlayerPrefs.HasKey("NormalPanel_" + PlayerPrefs.GetInt("selectedMap")))
        {
            NormalPanel.gameObject.SetActive(false);
        }
        else
        {
            NormalPanel.gameObject.SetActive(true);
        }
        if (PlayerPrefs.HasKey("HardPanel_" + PlayerPrefs.GetInt("selectedMap")))
        {
            hardPanel.gameObject.SetActive(false);
        }
        else
        {
            hardPanel.gameObject.SetActive(true);
        }
        if (PlayerPrefs.HasKey("ExtremePanel_" + PlayerPrefs.GetInt("selectedMap")))
        {
            ExtremePanel.gameObject.SetActive(false);
        }
        else
        {
            ExtremePanel.gameObject.SetActive(true);
        }
    }



    public void Easydes()
    {
        if (ShopForGoldCoin.GoldCoinAmount >= 50)
        {
            EasyPanel.gameObject.SetActive(false);
            PlayerPrefs.SetInt("EasyPanel_" + PlayerPrefs.GetInt("selectedMap"), 1);
            ShopForGoldCoin.GoldCoinAmount -= 50;
            PlayerPrefs.SetInt("Goldcoin_Godown", ShopForGoldCoin.GoldCoinAmount);
        }
        else EasyPanel.gameObject.SetActive(true);
    }

    public void NormalDes()
    {
        if (ShopForGoldCoin.GoldCoinAmount >= 100)
        {
            NormalPanel.gameObject.SetActive(false);
            PlayerPrefs.SetInt("NormalPanel_" + PlayerPrefs.GetInt("selectedMap"), 1);
            ShopForGoldCoin.GoldCoinAmount -= 100;
            PlayerPrefs.SetInt("Goldcoin_Godown", ShopForGoldCoin.GoldCoinAmount);
        }
        else NormalPanel.gameObject.SetActive(true);
    }

    public void HardDes()
    {
        if (ShopForGoldCoin.GoldCoinAmount >= 150)
        {
            hardPanel.gameObject.SetActive(false);
            PlayerPrefs.SetInt("HardPanel_" + PlayerPrefs.GetInt("selectedMap"), 1);
            ShopForGoldCoin.GoldCoinAmount -= 150;
            PlayerPrefs.SetInt("Goldcoin_Godown", ShopForGoldCoin.GoldCoinAmount);
        }
        else hardPanel.gameObject.SetActive(true);
    }

    public void ExtremeDes()
    {      
        if (ShopForGoldCoin.GoldCoinAmount >= 200)
        {
            ExtremePanel.gameObject.SetActive(false);
            PlayerPrefs.SetInt("ExtremePanel_" + PlayerPrefs.GetInt("selectedMap"), 1);
            ShopForGoldCoin.GoldCoinAmount -= 200;
            PlayerPrefs.SetInt("Goldcoin_Godown", ShopForGoldCoin.GoldCoinAmount);
        }
        else ExtremePanel.gameObject.SetActive(true);
    }

 public void resetprefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
