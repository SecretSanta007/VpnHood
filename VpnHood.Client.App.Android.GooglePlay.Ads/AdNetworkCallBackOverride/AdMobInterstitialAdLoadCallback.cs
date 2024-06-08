﻿using Android.Gms.Ads.Interstitial;
using Android.Runtime;

namespace VpnHood.Client.App.Droid.GooglePlay.Ads.AdNetworkCallBackOverride
{
    public abstract class AdMobInterstitialAdLoadCallback : InterstitialAdLoadCallback
    {
        private static Delegate? _cbOnAdLoaded;

        // ReSharper disable once UnusedMember.Local
        private static Delegate GetOnAdLoadedHandler()
        {
            return _cbOnAdLoaded ??= JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)OnAdLoadedNative);
        }

        private static void OnAdLoadedNative(IntPtr env, IntPtr nativeThis, IntPtr nativeP0)
        {
            var interstitialAdLoadCallback = GetObject<AdMobInterstitialAdLoadCallback>(env, nativeThis, JniHandleOwnership.DoNotTransfer);
            var interstitialAd = GetObject<InterstitialAd>(nativeP0, JniHandleOwnership.DoNotTransfer);
            if (interstitialAd != null)
                interstitialAdLoadCallback?.OnAdLoaded(interstitialAd);
        }

        // ReSharper disable once StringLiteralTypo
        [Register("onAdLoaded", "(Lcom/google/android/gms/ads/interstitial/InterstitialAd;)V", "GetOnAdLoadedHandler")]
        protected virtual void OnAdLoaded(InterstitialAd interstitialAd)
        {
        }
    }
}