using Profile;
using UnityEngine;
using Services.Analytics;
using Services.Ads.UnityAds;

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
    }

    private void OnDestroy()
    {
        UnityAdsService.Instance.Initialized.RemoveListener(OnAdsInitialized);
        _mainController.Dispose();
    }


    private void OnAdsInitialized() => UnityAdsService.Instance.InterstitialPlayer.Play();
}
