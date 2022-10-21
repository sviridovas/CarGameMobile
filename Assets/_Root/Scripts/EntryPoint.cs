using Profile;
using UnityEngine;
using Services.Analytics;
using Services.Ads.UnityAds;
using Services.IAP;

internal class EntryPoint : MonoBehaviour
{
    private const float SpeedCar = 15f;
    private const GameState InitialState = GameState.Start;

    [SerializeField] private Transform _placeForUi;

    private MainController _mainController;

    private void Start()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, InitialState);
        _mainController = new MainController(_placeForUi, profilePlayer);

        AnalyticsManager.Instance.SendMainMenuOpened();

        if (UnityAdsService.Instance.IsInitialized) 
            OnAdsInitialized();
        else 
            UnityAdsService.Instance.Initialized.AddListener(OnAdsInitialized);

        if (IAPService.Instance.IsInitialized) 
            OnIapInitialized();
        else 
        IAPService.Instance.Initialized.AddListener(OnIapInitialized);
    }

    private void OnDestroy()
    {
        UnityAdsService.Instance.Initialized.RemoveListener(OnAdsInitialized);
        _mainController.Dispose();
    }


    private void OnAdsInitialized() => UnityAdsService.Instance.InterstitialPlayer.Play();

    private void OnIapInitialized() => IAPService.Instance.Buy("product_1");
}
