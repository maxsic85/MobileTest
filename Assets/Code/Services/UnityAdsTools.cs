using System;
using UnityEngine;
using UnityEngine.Advertisements;
namespace Services.Analytic
{
    public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsShowListener
    {
        private string _gameId = "4700847";
        private string _rewardPlace = "SpeedUpMaxUnit";
        private string _interstitialPlace = "123";
        private Action _callbackSuccessShowVideo;

        private void Start()
        {
            Advertisement.Initialize(_gameId, true);
        }
        public void OnUnityAdsShowClick(string placementId)
        {
            throw new NotImplementedException();
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
                _callbackSuccessShowVideo?.Invoke();
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            throw new NotImplementedException();
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            throw new NotImplementedException();
        }

        public void ShowInterstitial()
        {
            _callbackSuccessShowVideo = null;
            Advertisement.Show(_interstitialPlace);
        }

        public void ShowVideo(Action successShow)
        {
            _callbackSuccessShowVideo = successShow;
            Advertisement.Show(_rewardPlace);
        }

    }
}