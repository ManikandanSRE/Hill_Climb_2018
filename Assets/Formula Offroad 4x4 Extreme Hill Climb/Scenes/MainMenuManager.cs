using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [Header("Terms and Conditions")]
    public GameObject termspanel;


    [Header("Google AD")]
    InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;


    [Header("Score")]
    public Text GoldCoinInMainPanel;
    public Text GoldCoinInCarShopPanel;
    public Text GoldCoinInMapShopPanel;
    public Text EasyHighScore;
    public Text NormalHighScore;
    public Text HardHighScore;
    public Text ExtremeHighScore;


    [Header("LeaderBoard")]
    public Text EasyHighScoreText;
    public Text NormalHighScoreText;
    public Text HardHighScoreText;
    public Text ExtremeHighScoreText;


    [Header("Top10 Score")]
    public List<Text> Top10HighScores = new List<Text>();


    [Header("Sound Controls")]
    public bool SoundOn;
    public Button OnOffButton;
    public Sprite OnImage;
    public Sprite OffImage;
    public static bool SoundManager;
    AudioSource audioSource;
    public Scrollbar MusicScroller;


    [Header("Shop Attrributes")]
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
    public Text GoldCoinInCarPanel;
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

    //public RawImage SelectionPad;                                    
    public List<Sprite> ItemList = new List<Sprite>();
    public static int itemspot = 0;
    public RawImage SelectionPadMaps;
    public List<Sprite> MapsItemList = new List<Sprite>();
    private int Mapsitemspot = 0;
    List<int> tagNames = new List<int>();


    [Header("Panel Destroyer")]
   // public RectTransform EasyPanel;
    public RectTransform NormalPanel;
    public RectTransform hardPanel;
    public RectTransform ExtremePanel;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("GameSetted"))
        {
            resetPlayerPrefs();
        }
    }

    void Start()
    {
        InitializeAD();

        UpdateGoldCoin();

        SetupPanelDestroyer();

        SetupAudio();

        SetupShop();
      
        SettingScores();
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    public void SettingScores()
    {
        EasyHighScore.text = "HighScore \n " + PlayerPrefs.GetInt("HighScore_EASY");
        NormalHighScore.text = "HighScore\n " + PlayerPrefs.GetInt("HighScore_NORMAL");
        HardHighScore.text = "HighScore \n " + PlayerPrefs.GetInt("HighScore_HARD");
        ExtremeHighScore.text = "HighScore \n " + PlayerPrefs.GetInt("HighScore_EXTREMEHARD");
    }

    public void resetPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("EasyHighScores") && !PlayerPrefs.HasKey("NormalHighScores") && !PlayerPrefs.HasKey("HardHighScores") && !PlayerPrefs.HasKey("ExtremeHighScores"))
        {
            PlayerPrefs.SetString("EasyHighScores", "0,0,0,0,0,0,0,0,0,0");
            PlayerPrefs.SetString("NormalHighScores", "0,0,0,0,0,0,0,0,0,0");
            PlayerPrefs.SetString("HardHighScores", "0,0,0,0,0,0,0,0,0,0");
            PlayerPrefs.SetString("ExtremeHighScores", "0,0,0,0,0,0,0,0,0,0");
        }
        if (!PlayerPrefs.HasKey("Goldcoin_Godown"))                 //shopGold Reset       
        {
            PlayerPrefs.SetInt("Goldcoin_Godown", 1000);
        }

        //PlayerPrefs.SetInt("Goldcoin_Godown", 0);    //for reseting goldgudown value
        if (!PlayerPrefs.HasKey("termspanel"))
        {
            termspanel.SetActive(true);
        }
        else
        {
            termspanel.SetActive(false);
        }

        if (!PlayerPrefs.HasKey("HighScore_EASY"))                    //highscore reset
        {
            PlayerPrefs.SetInt("HighScore_EASY", 0);
        }
        if (!PlayerPrefs.HasKey("HighScore_NORMAL"))
        {
            PlayerPrefs.SetInt("HighScore_NORMAL", 0);
        }
        if (!PlayerPrefs.HasKey("HighScore_HARD"))
        {
            PlayerPrefs.SetInt("HighScore_HARD", 0);
        }
        if (!PlayerPrefs.HasKey("HighScore_EXTREMEHARD"))
        {
            PlayerPrefs.SetInt("HighScore_EXTREMEHARD", 0);
        }

        if (!PlayerPrefs.HasKey(ItemList[0].texture.name))
        {
            PlayerPrefs.SetInt(ItemList[0].texture.name, 1);
        }

        if (!PlayerPrefs.HasKey(MapsItemList[0].texture.name))
        {
            PlayerPrefs.SetInt(MapsItemList[0].texture.name, 1);
        }

        if (!PlayerPrefs.HasKey("selectedCar"))
        {
            PlayerPrefs.SetInt("selectedCar", 0);
        }

        if (!PlayerPrefs.HasKey("selectedMap"))
        {
            PlayerPrefs.SetInt("selectedMap", 0);
        }


        PlayerPrefs.SetInt("GameSetted", 0);
    }

    public void GetHighScoreValues(string LevelName)
    {

        switch (LevelName)
        {
            case "Easy":
                gamemanager.EasyArray = PlayerPrefs.GetString("EasyHighScores").Split(',');
                for (int i = 0; i < gamemanager.EasyArray.Length; i++)
                {
                    Top10HighScores[i].text = gamemanager.EasyArray[i];
                }

                break;
            case "Normal":

                gamemanager.NormalArray = PlayerPrefs.GetString("NormalHighScores").Split(',');
                for (int i = 0; i < gamemanager.NormalArray.Length; i++)
                {
                    Top10HighScores[i].text = gamemanager.NormalArray[i];
                }
                break;
            case "Hard":

                gamemanager.HardArray = PlayerPrefs.GetString("HardHighScores").Split(',');


                for (int i = 0; i < gamemanager.HardArray.Length; i++)
                {
                    Top10HighScores[i].text = gamemanager.HardArray[i];
                }

                break;
            case "Extreme":

                gamemanager.ExtremeArray = PlayerPrefs.GetString("ExtremeHighScores").Split(',');
                for (int i = 0; i < gamemanager.ExtremeArray.Length; i++)
                {
                    Top10HighScores[i].text = gamemanager.ExtremeArray[i];
                }

                break;
        }
    }

    #region Shop
    void SetupShop()
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
            //SelectionPad.texture = ItemList[itemspot].texture;
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
            //SelectionPad.texture = ItemList[itemspot].texture;
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

    #endregion

    //Panel Destroyer
    #region Panel Methods
    void SetupPanelDestroyer()
    {
       // EasyPanel.GetComponent<Button>().onClick.AddListener(Easydes);
        NormalPanel.GetComponent<Button>().onClick.AddListener(NormalDes);
        hardPanel.GetComponent<Button>().onClick.AddListener(HardDes);
        ExtremePanel.GetComponent<Button>().onClick.AddListener(ExtremeDes);
        clickToStartForPanel();
    }


    public void clickToStartForPanel()
    {
       // if (PlayerPrefs.HasKey("EasyPanel_" + PlayerPrefs.GetInt("selectedMap")))
       // {
       //     EasyPanel.gameObject.SetActive(false);
       // }
       //
       // else
       // {
       //     EasyPanel.gameObject.SetActive(true);
       // }
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



   //public void Easydes()
   //{
   //    Debug.Log(ShopForGoldCoin.GoldCoinAmount);
   //    if (GoldCoinAmount >= 50)
   //    {
   //        EasyPanel.gameObject.SetActive(false);
   //        PlayerPrefs.SetInt("EasyPanel_" + PlayerPrefs.GetInt("selectedMap"), 1);
   //        GoldCoinAmount -= 50;
   //        PlayerPrefs.SetInt("Goldcoin_Godown", GoldCoinAmount);
   //
   //    }
   //    else
   //    {
   //        EasyPanel.gameObject.SetActive(true);
   //    }
   //
   //    UpdateGoldCoin();
   //}

    public void NormalDes()
    {
        if (GoldCoinAmount >= 100)
        {
            NormalPanel.gameObject.SetActive(false);
            PlayerPrefs.SetInt("NormalPanel_" + PlayerPrefs.GetInt("selectedMap"), 1);
            GoldCoinAmount -= 100;
            PlayerPrefs.SetInt("Goldcoin_Godown", GoldCoinAmount);
        }
        else
        {
            NormalPanel.gameObject.SetActive(true);
        }

        UpdateGoldCoin();
    }

    public void HardDes()
    {
        if (GoldCoinAmount >= 150)
        {
            hardPanel.gameObject.SetActive(false);
            PlayerPrefs.SetInt("HardPanel_" + PlayerPrefs.GetInt("selectedMap"), 1);
            GoldCoinAmount -= 150;
            PlayerPrefs.SetInt("Goldcoin_Godown", GoldCoinAmount);
        }
        else
        {
            hardPanel.gameObject.SetActive(true);
        }

        UpdateGoldCoin();
    }

    public void ExtremeDes()
    {
        if (GoldCoinAmount >= 200)
        {
            ExtremePanel.gameObject.SetActive(false);
            PlayerPrefs.SetInt("ExtremePanel_" + PlayerPrefs.GetInt("selectedMap"), 1);
            GoldCoinAmount -= 200;
            PlayerPrefs.SetInt("Goldcoin_Godown", GoldCoinAmount);
        }
        else
        {
            ExtremePanel.gameObject.SetActive(true);
        }

        UpdateGoldCoin();
    }

    public void resetprefs()
    {
        PlayerPrefs.DeleteAll();
    }

    #endregion
    #region Google AD

    //Intialise ADMob
    void InitializeAD()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        
        //double up the goldcoins
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        this.RequestRewardBasedVideo();  //videdo Admob



    }
    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {

        ScoreBoardManager.GoldCoins = ScoreBoardManager.GoldCoins * 2;
        PlayerPrefs.SetInt("Goldcoin_Godown", PlayerPrefs.GetInt("Goldcoin_Godown") + ScoreBoardManager.GoldCoins);
        ScoreBoardManager.GoldCoins = 0;
    }

    public void GoldCoinVideoADMOB()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
    }
    #endregion
    #region Audio Methods
    void SetupAudio()
    {
        OnOffButton.image.preserveAspect = true;
        audioSource = GetComponent<AudioSource>();          //sound

        if (!gamemanager.SoundIsOn)
        {
            OnOffButton.image.sprite = OffImage;
        }
        else
        {
            OnOffButton.image.sprite = OnImage;
        }

        audioSource.volume = gamemanager.MusicSoundRise;   //music       
        MusicScroller.value = gamemanager.MusicSoundRise;

    }
    public void SoundOnOffController()
    {
        gamemanager.SoundIsOn = !gamemanager.SoundIsOn;
        if (!gamemanager.SoundIsOn)
        {
            OnOffButton.image.sprite = OffImage;
            PlayerPrefs.SetInt("SoundSet", 0);
            gamemanager.SoundIsOn = false;
        }
        if (gamemanager.SoundIsOn)
        {
            OnOffButton.image.sprite = OnImage;
            PlayerPrefs.SetInt("SoundSet", 1);
            gamemanager.SoundIsOn = true;
        }
    }

    public void OnMusicValueChanged()
    {

        PlayerPrefs.SetFloat("MusicSet", MusicScroller.value);
        gamemanager.MusicSoundRise = MusicScroller.value;
        audioSource.volume = gamemanager.MusicSoundRise;
    }
    #endregion

    public void UpdateGoldCoin()
    {
        GoldCoinInMainPanel.text = "Gold Coin : " + PlayerPrefs.GetInt("Goldcoin_Godown");
        GoldCoinInCarShopPanel.text = "Gold Coin : " + PlayerPrefs.GetInt("Goldcoin_Godown");
        GoldCoinInMapShopPanel.text = "Gold Coin : " + PlayerPrefs.GetInt("Goldcoin_Godown");
    }
   
    public void SelectedLevel(int carspeed)

    {

        gamemanager.carSpeed = carspeed;

    }

    public void SelectedLevelName(string mode)
    {
        gamemanager.GameModeAccessSettingUp = mode;
        SceneManager.LoadSceneAsync(2);
    }

    public void UrlOpener(string url)
    {
        Application.OpenURL(url);
    }

    public void AcceptPressed()
    {
        PlayerPrefs.SetInt("termspanel", 1);
        termspanel.SetActive(false);
    }

    public void DeclinePressed()
    {
        Application.Quit();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("yes your exit now");
    }



}
