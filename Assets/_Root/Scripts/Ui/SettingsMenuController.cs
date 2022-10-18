using Profile;
using Tool;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class SettingsMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/settingsMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly UnityAction _onClose;
        private readonly SettingsMenuView _view;


        public SettingsMenuController(Transform placeForUi, ProfilePlayer profilePlayer, UnityAction onClose)
        {
            _profilePlayer = profilePlayer;
            _onClose = onClose;

            _view = LoadView(placeForUi);
            _view.Init(ToMain);
        }


        private SettingsMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<SettingsMenuView>();
        }

        private void ToMain() {
            // _profilePlayer.CurrentCar.Speed += 1 
            _onClose();
        }
    }
}
