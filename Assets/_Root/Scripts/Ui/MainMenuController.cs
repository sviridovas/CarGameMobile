using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        private SettingsMenuController _settingsMenuController;
        private readonly Transform _placeForUi;


        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;

            _view = LoadView(placeForUi);
            _view.Init(StartGame, OpenSettings);
        }

        protected override void OnDispose() { 
            _settingsMenuController?.Dispose();
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame() =>
            _profilePlayer.CurrentState.Value = GameState.Game;
        
        private void OpenSettings() {
            _view.gameObject.SetActive(false);

            _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer, OnCloseSettings);
        }
        private void OnCloseSettings() {
            _view.gameObject.SetActive(true);

            _settingsMenuController?.Dispose();
            _settingsMenuController = null;
        }
    }
}
