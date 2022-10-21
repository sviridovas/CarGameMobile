using UnityEngine;
using Services.Analytics.UnityAnalytics;

namespace Services.Analytics
{
    internal class AnalyticsManager : MonoBehaviour
    {
        private static AnalyticsManager _instance;
        public static AnalyticsManager Instance => _instance ??= FindObjectOfType<AnalyticsManager>();

        private IAnalyticsService[] _services;


        private void Awake() 
        {
            _instance ??= this;
            
            _services = new IAnalyticsService[]
            {
                new UnityAnalyticsService()
            };
        }


        public void SendMainMenuOpened() =>
            SendEvent("MainMenuOpened");

        public void SendPlayPressed() =>
            SendEvent("PlayPressed");

        private void SendEvent(string eventName)
        {
            for (int i = 0; i < _services.Length; i++)
                _services[i].SendEvent(eventName);
        }
    }
}
