#if ENABLE_ADMOB
using GoogleMobileAds.Api;
#endif
using System;
using UnityEngine;

public class adMobScript : MonoBehaviour
{
	private bool ADMOB_DEBUG;

	private bool interstitialRequested;

	private float adDisplayedTime = -60f;

	private float minDelayBetweenAds = 60f;

#if ENABLE_ADMOB
	private BannerView bannerView;

	private InterstitialAd interstitial;
#endif

	private void Awake()
	{
		string appId = "ca-app-pub-1487856159067139~9614634804";
#if ENABLE_ADMOB
		MobileAds.SetiOSAppPauseOnBackground(pause: true);
		MobileAds.Initialize(appId);
#endif
	}

#if ENABLE_ADMOB
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder().AddKeyword("game").TagForChildDirectedTreatment(tagForChildDirectedTreatment: false).Build();
	}
#endif

	public void RequestBanner()
	{
#if ENABLE_ADMOB
		string adUnitId = "ca-app-pub-1487856159067139/not-used";
		if (bannerView != null)
		{
			bannerView.Destroy();
		}
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdOpening += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		bannerView.LoadAd(createAdRequest());
#endif
	}

	public void DestroyBanner()
	{
#if ENABLE_ADMOB
		if (bannerView != null)
		{
			bannerView.Destroy();
		}
#endif
	}

	public void HandleAdLoaded(object sender, EventArgs args)
	{
		admobPrint("HandleAdLoaded event received.");
	}

#if ENABLE_ADMOB
	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		admobPrint("HandleFailedToReceiveAd event received with message: " + args.Message);
	}
#endif

	public void HandleAdOpened(object sender, EventArgs args)
	{
		admobPrint("HandleAdOpened event received");
	}

	public void HandleAdClosed(object sender, EventArgs args)
	{
		admobPrint("HandleAdClosed event received");
	}

	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		admobPrint("HandleAdLeftApplication event received");
	}

	public void RequestInterstitial()
	{
		if (!interstitialRequested)
		{
#if ENABLE_ADMOB
			string adUnitId = "ca-app-pub-1487856159067139/5044834409";
			if (interstitial != null)
			{
				interstitial.Destroy();
			}
			interstitial = new InterstitialAd(adUnitId);
			interstitial.OnAdLoaded += HandleInterstitialLoaded;
			interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
			interstitial.OnAdOpening += HandleInterstitialOpened;
			interstitial.OnAdClosed += HandleInterstitialClosed;
			interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
			interstitial.LoadAd(createAdRequest());
			interstitialRequested = true;
#endif
		}
	}

	public void ShowInterstitial()
	{
#if ENABLE_ADMOB
		if (Time.time - adDisplayedTime > minDelayBetweenAds)
		{
			if (interstitial.IsLoaded())
			{
				interstitial.Show();
				adDisplayedTime = Time.time;
			}
			else
			{
				admobPrint("Interstitial is not ready yet.");
			}
		}
#endif
	}

	public void HandleInterstitialLoaded(object sender, EventArgs args)
	{
		admobPrint("HandleInterstitialLoaded event received.");
	}

#if ENABLE_ADMOB
	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		admobPrint("HandleInterstitialFailedToLoad event received with message: " + args.Message);
		interstitialRequested = false;
	}
#endif

	public void HandleInterstitialOpened(object sender, EventArgs args)
	{
		admobPrint("HandleInterstitialOpened event received");
		interstitialRequested = false;
	}

	public void HandleInterstitialClosed(object sender, EventArgs args)
	{
		admobPrint("HandleInterstitialClosed event received");
		interstitialRequested = false;
	}

	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
	{
		admobPrint("HandleInterstitialLeftApplication event received");
	}

	private void admobPrint(string msg)
	{
		if (ADMOB_DEBUG)
		{
			MonoBehaviour.print(msg);
		}
	}
}
