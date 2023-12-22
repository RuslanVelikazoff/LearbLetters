using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdID = "Interstitial_Android";
    [SerializeField] private string iOSAdID = "Interstitial_iOS";

    private string adID;

    private void Awake()
    {
        adID = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iOSAdID
            : androidAdID;

        LoadAd1();
    }

    public void LoadAd1()
    {
        Debug.Log("Loading ad: " + adID);
        Advertisement.Load(adID, this);
    }

    public void ShowAD()
    {
        Debug.Log("Showing Ad: " + adID);
        Advertisement.Show(adID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd1();
    }
}
