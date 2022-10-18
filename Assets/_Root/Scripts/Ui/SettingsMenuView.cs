using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class SettingsMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonToMain;

        public void Init(UnityAction toMain) =>
            _buttonToMain.onClick.AddListener(toMain);

        public void OnDestroy() =>
            _buttonToMain.onClick.RemoveAllListeners();
    }
}
