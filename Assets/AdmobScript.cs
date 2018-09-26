using GoogleMobileAds.Api;
using UnityEngine;


public class AdmobScript : MonoBehaviour
{


    private BannerView bannerView;

    [SerializeField] private string AppId = "ca-app-pub-7338837470800808~7359101499";
    [SerializeField] private string bannerId = "ca-app-pub-7338837470800808/1120996205";
    [SerializeField] private string regularAdId = "ca-app-pub-7338837470800808/1018738635";


    void Awake()
    {
        MobileAds.Initialize(AppId);
    }

    public void OnClickRegularAdd()
    {
        this.RequestForRegularAdd();
    }
    public void OnClickBannerAdd()
    {
        this.RequestForBannerAdd();
    }

    private void RequestForRegularAdd()
    {
        InterstitialAd FullSizeAd = new InterstitialAd(regularAdId);

        AdRequest request = new AdRequest.Builder().Build();

        FullSizeAd.LoadAd(request);

    }
    private void RequestForBannerAdd()
    {
        BannerView bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

}

