using System;

namespace Services.Analytic
{
    public interface IAdsShower
    {
        void ShowInterstitial();
        void ShowVideo(Action successShow);
    }
}